using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Acessos
{
    public partial class frmHistoricoOrcamento : Telerik.WinControls.UI.RadForm
    {
        private OrcamentoRepository repository;
        private List<Orcamento> historicoOrcamentos;
        private List<OrcamentoHistorico> historicoOrcamentosFiltrados;
        private int? clienteIdFiltro;
        private OrcamentoHistorico historico;
        SqlConnection conexao= new SqlConnection(ConnectionManager.GetConnectionString("Admin"));

        public frmHistoricoOrcamento(int? clienteId = null)
        {
            InitializeComponent();
            repository = new OrcamentoRepository();
            historico = new OrcamentoHistorico();
            clienteIdFiltro = clienteId;
            ConfigurarGrid();
        }

        private void frmHistoricoOrcamento_Load(object sender, EventArgs e)
        {
            CarregarHistorico();

            // Ajustar título baseado no filtro
            if (clienteIdFiltro.HasValue)
            {
                lblTitulo.Text = "Histórico de Orçamentos - Cliente Específico";
            }
        }

        private void ConfigurarGrid()
        {
            dgvHistorico.AutoGenerateColumns = false;
            dgvHistorico.Columns.Clear();

            // Configurar colunas do grid
            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "ID",
                Width = 60,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoOrcamento",
                HeaderText = "Código",
                DataPropertyName = "CodigoOrcamento",
                Width = 120
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomeCliente",
                HeaderText = "Cliente",
                DataPropertyName = "NomeCliente",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCriacao",
                HeaderText = "Data Criação",
                DataPropertyName = "DataCriacao",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataValidade",
                HeaderText = "Validade",
                DataPropertyName = "DataValidade",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ValorTotal",
                HeaderText = "Valor Total",
                DataPropertyName = "ValorTotal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "C2",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "StatusDescricao",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UltimaModificacao",
                HeaderText = "Última Modificação",
                DataPropertyName = "UltimaModificacao",
                Width = 130,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "dd/MM/yyyy HH:mm",
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            // Configurações gerais do grid
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.MultiSelect = false;
            dgvHistorico.ReadOnly = true;
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.RowHeadersVisible = false;
            dgvHistorico.EnableHeadersVisualStyles = false;
            dgvHistorico.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
            dgvHistorico.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);

            // Adicionar evento de duplo clique
            dgvHistorico.CellDoubleClick += DgvHistorico_CellDoubleClick;

            // Adicionar menu de contexto
            AdicionarMenuContexto();
        }

        private void AdicionarMenuContexto()
        {
            var contextMenu = new ContextMenuStrip();

            var menuVisualizar = new ToolStripMenuItem("Visualizar Orçamento");
            menuVisualizar.Click += (s, e) => VisualizarOrcamento();
            contextMenu.Items.Add(menuVisualizar);

            contextMenu.Items.Add(new ToolStripSeparator());

            var menuExportarSelecionado = new ToolStripMenuItem("Exportar Selecionado");
            menuExportarSelecionado.Click += (s, e) => ExportarOrcamentoSelecionado();
            contextMenu.Items.Add(menuExportarSelecionado);

            var menuExportarTodos = new ToolStripMenuItem("Exportar Todos");
            menuExportarTodos.Click += (s, e) => btnExportar_Click(null, null);
            contextMenu.Items.Add(menuExportarTodos);

            dgvHistorico.ContextMenuStrip = contextMenu;
        }

        private void CarregarHistorico()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                historicoOrcamentosFiltrados = historico.ObterHistoricoPorUsuarioId(conexao, clienteIdFiltro);

                var dadosExibicao = historicoOrcamentosFiltrados.Select(h => new
                {
                    h.Id,
                    h.OrcamentoId,
                    h.UsuarioId,
                    h.DataAlteracao,
                    h.Acao,
                    h.Detalhes
                }).ToList();


                dgvHistorico.DataSource = dadosExibicao;
                AplicarCoresStatus();
                lblTotalRegistros.Text = $"Total de registros: {historicoOrcamentosFiltrados.Count}";

                Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show($"Erro ao carregar histórico: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string ObterDescricaoStatus(StatusOrcamento status)
        {
            return status switch
            {
                StatusOrcamento.Novo => "Novo",
                StatusOrcamento.Pendente => "Pendente",
                StatusOrcamento.Aprovado => "Aprovado",
                StatusOrcamento.Rejeitado => "Rejeitado",
                StatusOrcamento.Cancelado => "Cancelado",
                StatusOrcamento.Expirado => "Expirado",
                _ => "Desconhecido"
            };
        }

        private void AplicarCoresStatus()
        {
            foreach (DataGridViewRow row in dgvHistorico.Rows)
            {
                if (row.Cells["StatusDescricao"].Value != null)
                {
                    string status = row.Cells["StatusDescricao"].Value.ToString();

                    switch (status)
                    {
                        case "Novo":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightBlue;
                            break;
                        case "Pendente":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                            break;
                        case "Aprovado":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
                            break;
                        case "Rejeitado":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                            break;
                        case "Cancelado":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
                            break;
                        case "Expirado":
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.Wheat;
                            break;
                    }
                }
            }
        }

        private void DgvHistorico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                VisualizarOrcamento();
            }
        }

        private void VisualizarOrcamento()
        {
            if (dgvHistorico.CurrentRow?.Cells["ID"].Value != null)
            {
                int orcamentoId = Convert.ToInt32(dgvHistorico.CurrentRow.Cells["ID"].Value);
                var orcamento = historicoOrcamentos.FirstOrDefault(o => o.ID == orcamentoId);

                if (orcamento != null)
                {
                    using (var frmDetalhes = new frmVisualizarOrcamento(orcamento))
                    {
                        frmDetalhes.ShowDialog();
                    }
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarHistorico();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (historicoOrcamentos == null || !historicoOrcamentos.Any())
            {
                MessageBox.Show("Não há dados para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Arquivos CSV (*.csv)|*.csv|Arquivos Excel (*.xlsx)|*.xlsx";
                saveDialog.Title = "Exportar Histórico de Orçamentos";
                saveDialog.FileName = $"HistoricoOrcamentos_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if (saveDialog.FilterIndex == 1) // CSV
                        {
                            ExportarParaCSV(saveDialog.FileName);
                        }
                        else // Excel
                        {
                            ExportarParaExcel(saveDialog.FileName);
                        }

                        MessageBox.Show($"Dados exportados com sucesso para:\n{saveDialog.FileName}",
                            "Exportação Concluída", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao exportar dados: {ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ExportarParaCSV(string arquivo)
        {
            var csv = new StringBuilder();

            // Cabeçalho
            csv.AppendLine("ID;Código;Cliente;Data Criação;Validade;Valor Total;Status;Última Modificação;Observações");

            // Dados
            foreach (var orcamento in historicoOrcamentos)
            {
                csv.AppendLine($"{orcamento.ID};" +
                              $"{orcamento.CodigoOrcamento};" +
                              $"{orcamento.Cliente?.Nome ?? ""};" +
                              $"{orcamento.DataCriacao:dd/MM/yyyy};" +
                              $"{orcamento.DataValidade?.ToString("dd/MM/yyyy") ?? ""};" +
                              $"{orcamento.ValorTotal:F2};" +
                              $"{ObterDescricaoStatus(orcamento.Status)};" +
                              $"{orcamento.UltimaModificacao:dd/MM/yyyy HH:mm};" +
                              $"{orcamento.Observacoes?.Replace(";", ",") ?? ""}");
            }

            File.WriteAllText(arquivo, csv.ToString(), Encoding.UTF8);
        }

        private void ExportarParaExcel(string arquivo)
        {
            // Implementação básica para Excel usando CSV com separador de tabulação
            var excel = new StringBuilder();

            // Cabeçalho
            excel.AppendLine("ID\tCódigo\tCliente\tData Criação\tValidade\tValor Total\tStatus\tÚltima Modificação\tObservações");

            // Dados
            foreach (var orcamento in historicoOrcamentos)
            {
                excel.AppendLine($"{orcamento.ID}\t" +
                                $"{orcamento.CodigoOrcamento}\t" +
                                $"{orcamento.Cliente?.Nome ?? ""}\t" +
                                $"{orcamento.DataCriacao:dd/MM/yyyy}\t" +
                                $"{orcamento.DataValidade?.ToString("dd/MM/yyyy") ?? ""}\t" +
                                $"{orcamento.ValorTotal:F2}\t" +
                                $"{ObterDescricaoStatus(orcamento.Status)}\t" +
                                $"{orcamento.UltimaModificacao:dd/MM/yyyy HH:mm}\t" +
                                $"{orcamento.Observacoes?.Replace("\t", " ") ?? ""}");
            }

            File.WriteAllText(arquivo, excel.ToString(), Encoding.UTF8);
        }

        private void ExportarOrcamentoSelecionado()
        {
            if (dgvHistorico.CurrentRow?.Cells["ID"].Value != null)
            {
                int orcamentoId = Convert.ToInt32(dgvHistorico.CurrentRow.Cells["ID"].Value);
                var orcamento = historicoOrcamentos.FirstOrDefault(o => o.ID == orcamentoId);

                if (orcamento != null)
                {
                    using (var saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                        saveDialog.Title = "Exportar Orçamento Selecionado";
                        saveDialog.FileName = $"Orcamento_{orcamento.CodigoOrcamento}_{DateTime.Now:yyyyMMdd}";

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                ExportarOrcamentoIndividual(orcamento, saveDialog.FileName);
                                MessageBox.Show($"Orçamento exportado com sucesso!", "Exportação Concluída",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Erro ao exportar orçamento: {ex.Message}", "Erro",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void ExportarOrcamentoIndividual(Orcamento orcamento, string arquivo)
        {
            var csv = new StringBuilder();

            // Cabeçalho do orçamento
            csv.AppendLine($"ORÇAMENTO: {orcamento.CodigoOrcamento}");
            csv.AppendLine($"CLIENTE: {orcamento.Cliente?.Nome ?? ""}");
            csv.AppendLine($"DATA: {orcamento.DataCriacao:dd/MM/yyyy}");
            csv.AppendLine($"VALIDADE: {orcamento.DataValidade?.ToString("dd/MM/yyyy") ?? ""}");
            csv.AppendLine($"STATUS: {ObterDescricaoStatus(orcamento.Status)}");
            csv.AppendLine("");

            // Itens
            csv.AppendLine("ITENS DO ORÇAMENTO:");
            csv.AppendLine("Produto;Quantidade;Preço Unitário;Desconto;Total");

            foreach (var item in orcamento.Itens.Where(i => i.Ativo))
            {
                csv.AppendLine($"{item.DescricaoProduto};" +
                              $"{item.Quantidade};" +
                              $"{item.PrecoUnitario:F2};" +
                              $"{item.Desconto:F2};" +
                              $"{item.Total:F2}");
            }

            csv.AppendLine("");
            csv.AppendLine($"SUBTOTAL:;{orcamento.Subtotal:F2}");
            csv.AppendLine($"DESCONTO GERAL:;{orcamento.DescontoGeral:F2}%");
            csv.AppendLine($"VALOR TOTAL:;{orcamento.ValorTotal:F2}");

            if (!string.IsNullOrEmpty(orcamento.Observacoes))
            {
                csv.AppendLine("");
                csv.AppendLine($"OBSERVAÇÕES: {orcamento.Observacoes}");
            }

            File.WriteAllText(arquivo, csv.ToString(), Encoding.UTF8);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.F5:
                    btnAtualizar_Click(null, null);
                    return true;

                case Keys.Escape:
                    btnFechar_Click(null, null);
                    return true;

                case Keys.Enter:
                    if (dgvHistorico.Focused && dgvHistorico.CurrentRow != null)
                    {
                        VisualizarOrcamento();
                        return true;
                    }
                    break;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
