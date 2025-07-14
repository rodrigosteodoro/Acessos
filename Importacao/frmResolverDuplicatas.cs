using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Acessos
{
    public partial class frmResolverDuplicatas : Form
    {
        internal class DuplicataInfo
        {
            internal string Codigo { get; set; }
            internal string Nome { get; set; }
            internal string TipoDuplicata { get; set; }
            internal string Diferencas { get; set; }
            internal AcaoDuplicata AcaoSelecionada { get; set; }
            internal Produto ProdutoExistente { get; set; }
            internal Produto ProdutoImportado { get; set; }
        }

        internal enum AcaoDuplicata
        {
            ManterExistente = 0,
            SubstituirExistente = 1,
            CriarNovoProduto = 2,
            IgnorarImportacao = 3
        }

        private List<DuplicataInfo> duplicatas;
        private List<Produto> produtosImportados;
        private List<Produto> produtosExistentes;
        public event Action<List<Produto>, List<string>> OnResolucaoConcluida;

        internal frmResolverDuplicatas(List<Produto> produtosImportados, List<Produto> produtosExistentes)
        {
            InitializeComponent();
            this.produtosImportados = produtosImportados;
            this.produtosExistentes = produtosExistentes;
            duplicatas = new List<DuplicataInfo>();
        }

        private void frmResolverDuplicatas_Load(object sender, EventArgs e)
        {
            ConfigurarEstilosDataGridView();
            IdentificarDuplicatas();
            CarregarDuplicatasNoGrid();
            AjustarLarguraColunas();
        }

        private void IdentificarDuplicatas()
        {
            // Identificar produtos com códigos duplicados
            var gruposDuplicatas = produtosImportados
                .GroupBy(p => p.CodigoProduto)
                .Where(g => g.Count() > 1);

            foreach (var grupo in gruposDuplicatas)
            {
                int contador = 1;
                foreach (var produto in grupo)
                {
                    duplicatas.Add(new DuplicataInfo
                    {
                        Codigo = produto.CodigoProduto,
                        Nome = produto.Nome,
                        TipoDuplicata = "Duplicata no Arquivo",
                        Diferencas = $"Item {contador} de {grupo.Count()} no mesmo arquivo",
                        ProdutoImportado = produto,
                        AcaoSelecionada = AcaoDuplicata.ManterExistente
                    });
                    contador++;
                }
            }

            // Identificar conflitos com produtos existentes
            foreach (var produtoImportado in produtosImportados)
            {
                var produtoExistente = produtosExistentes
                    .FirstOrDefault(p => p.CodigoProduto == produtoImportado.CodigoProduto);

                if (produtoExistente != null)
                {
                    string diferencas = IdentificarDiferencas(produtoExistente, produtoImportado);

                    duplicatas.Add(new DuplicataInfo
                    {
                        Codigo = produtoImportado.CodigoProduto,
                        Nome = produtoImportado.Nome,
                        TipoDuplicata = "Conflito com Existente",
                        Diferencas = diferencas,
                        ProdutoExistente = produtoExistente,
                        ProdutoImportado = produtoImportado,
                        AcaoSelecionada = AcaoDuplicata.ManterExistente
                    });
                }
            }
        }

        private string IdentificarDiferencas(Produto existente, Produto importado)
        {
            var diferencas = new List<string>();

            if (existente.Nome != importado.Nome)
                diferencas.Add($"Nome: '{existente.Nome}' vs '{importado.Nome}'");

            if (existente.PrecoVenda != importado.PrecoVenda)
                diferencas.Add($"Preço: {existente.PrecoVenda:C2} vs {importado.PrecoVenda:C2}");

            if (existente.Categoria != importado.Categoria)
                diferencas.Add($"Categoria: '{existente.Categoria}' vs '{importado.Categoria}'");

            if (existente.UnidadeMedida != importado.UnidadeMedida)
                diferencas.Add($"Unidade: '{existente.UnidadeMedida}' vs '{importado.UnidadeMedida}'");

            return diferencas.Any() ?
                string.Join("; ", diferencas) :
                "Produtos idênticos";
        }

        private void ConfigurarEstilosDataGridView()
        {
            dgvDuplicatas.EnableHeadersVisualStyles = false;
            dgvDuplicatas.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
            dgvDuplicatas.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvDuplicatas.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgvDuplicatas.ColumnHeadersHeight = 35;

            dgvDuplicatas.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dgvDuplicatas.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvDuplicatas.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dgvDuplicatas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        }

        private void CarregarDuplicatasNoGrid()
        {
            dgvDuplicatas.Rows.Clear();

            foreach (var duplicata in duplicatas)
            {
                int rowIndex = dgvDuplicatas.Rows.Add(
                    duplicata.Codigo,
                    duplicata.Nome,
                    duplicata.TipoDuplicata,
                    duplicata.Diferencas
                );

                // Configurar combobox de ações
                var cell = (DataGridViewComboBoxCell)dgvDuplicatas.Rows[rowIndex].Cells["colAcao"];
                cell.DataSource = Enum.GetValues(typeof(AcaoDuplicata));
                cell.Value = duplicata.AcaoSelecionada;

                // Configurar cor da linha
                ConfigurarCorLinha(dgvDuplicatas.Rows[rowIndex], duplicata.TipoDuplicata);
            }
        }

        private void ConfigurarCorLinha(DataGridViewRow row, string tipoDuplicata)
        {
            if (tipoDuplicata.Contains("Conflito"))
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205); // Amarelo claro
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.FromArgb(255, 230, 230); // Vermelho claro
                row.DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void AjustarLarguraColunas()
        {
            try
            {
                colCodigo.Width = 100;
                colNome.Width = 200;
                colTipoDuplicata.Width = 150;
                colDiferencas.Width = 350;
                colAcao.Width = 150;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao ajustar largura: {ex.Message}");
            }
        }

        private void dgvDuplicatas_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvDuplicatas.CurrentCell is DataGridViewComboBoxCell)
            {
                dgvDuplicatas.CommitEdit(DataGridViewDataErrorContexts.Commit);

                // Atualizar ação na lista de duplicatas
                int rowIndex = dgvDuplicatas.CurrentCell.RowIndex;
                if (rowIndex >= 0 && rowIndex < duplicatas.Count)
                {
                    var acao = (AcaoDuplicata)dgvDuplicatas.Rows[rowIndex].Cells["colAcao"].Value;
                    duplicatas[rowIndex].AcaoSelecionada = acao;
                }
            }
        }

        private void dgvDuplicatas_SelectionChanged(object sender, EventArgs e)
        {
            btnVisualizarDiferenca.Enabled = dgvDuplicatas.SelectedRows.Count > 0;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            if (ValidarAcoes())
            {
                AplicarAcoesSelecionadas();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool ValidarAcoes()
        {
            foreach (DataGridViewRow row in dgvDuplicatas.Rows)
            {
                if (row.Cells["colAcao"].Value == null)
                {
                    MessageBox.Show("Selecione uma ação para todas as duplicatas antes de continuar.",
                        "Ações Pendentes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }

        private void AplicarAcoesSelecionadas()
        {
            var erros = new List<string>();
            var produtosResolvidos = new List<Produto>();

            foreach (var duplicata in duplicatas)
            {
                try
                {
                    switch (duplicata.AcaoSelecionada)
                    {
                        case AcaoDuplicata.ManterExistente:
                            // Não faz nada, mantém o produto já existente
                            break;

                        case AcaoDuplicata.SubstituirExistente:
                            // Substitui todos os dados do existente pelo importado
                            AtualizarProdutoExistente(duplicata.ProdutoExistente, duplicata.ProdutoImportado, substituirTudo: true);
                            produtosResolvidos.Add(duplicata.ProdutoExistente);
                            break;

                        case AcaoDuplicata.CriarNovoProduto:
                            // Insere o produto importado como novo (deve gerar novo código se necessário)
                            var novoProduto = duplicata.ProdutoImportado.Clone(); // supondo que você tenha um método Clone()
                            novoProduto.CodigoProduto = GerarCodigoNovo(novoProduto.CodigoProduto);
                            produtosResolvidos.Add(novoProduto);
                            break;

                        case AcaoDuplicata.IgnorarImportacao:
                            // Não adiciona o produto importado
                            break;
                    }
                }
                catch (Exception ex)
                {
                    erros.Add($"Erro ao aplicar ação para o produto {duplicata.Codigo}: {ex.Message}");
                }
            }

            // Adiciona produtos importados que não eram duplicatas (novos)
            var codigosDuplicatas = duplicatas.Select(d => d.Codigo).ToHashSet();
            var novos = produtosImportados.Where(p => !codigosDuplicatas.Contains(p.CodigoProduto));
            produtosResolvidos.AddRange(novos);

            // Dispara o evento para o formulário de importação
            OnResolucaoConcluida?.Invoke(produtosResolvidos, erros);
        }
        private string GerarCodigoNovo(string codigoOriginal)
        {
            // Exemplo: adiciona sufixo "_NOVO" ou incrementa número
            return codigoOriginal + "_NOVO";
        }

        private void AtualizarProdutoExistente(Produto existente, Produto importado, bool substituirTudo = false)
        {
            // Atualiza somente campos que mudaram e não estão vazios/nulos no importado
            if (substituirTudo)
            {
                // Substitui todos os dados do existente pelo importado
                existente.Nome = importado.Nome;
                existente.Descricao = importado.Descricao;
                existente.Categoria = importado.Categoria;
                existente.Subcategoria = importado.Subcategoria;
                existente.Marca = importado.Marca;
                existente.PrecoCusto = importado.PrecoCusto;
                existente.PrecoVenda = importado.PrecoVenda;
                existente.MargemLucro = importado.MargemLucro;
                existente.QuantidadeAtual = importado.QuantidadeAtual;
                existente.UnidadeMedida = importado.UnidadeMedida;
                existente.Peso = importado.Peso;
                existente.Volume = importado.Volume;
                existente.DataValidade = importado.DataValidade;
                existente.Lote = importado.Lote;
                existente.NomeFornecedor = importado.NomeFornecedor;
                existente.FornecedorID = importado.FornecedorID;
                existente.Observacoes = importado.Observacoes;
                existente.Ativo = importado.Ativo;
                existente.UltimaAlteracao = DateTime.Now;              
                existente.OrigemProduto = importado.OrigemProduto;
                existente.NCM = importado.NCM;
                existente.CFOP = importado.CFOP;
                existente.CSTCSOSN = importado.CSTCSOSN;
                existente.AliquotaICMS = importado.AliquotaICMS;
                existente.AliquotaPIS = importado.AliquotaPIS;
                existente.AliquotaCOFINS = importado.AliquotaCOFINS;
                existente.AliquotaIPI = importado.AliquotaIPI;
                // Atualizar imagem se necessário
                if (importado.Imagem != null)
                    existente.Imagem = importado.Imagem;
            }
            else
            {
                // Só atualiza se o importado tiver valor diferente e não nulo/vazio
                if (!string.IsNullOrWhiteSpace(importado.Nome) && importado.Nome != existente.Nome)
                    existente.Nome = importado.Nome;
                if (!string.IsNullOrWhiteSpace(importado.Descricao) && importado.Descricao != existente.Descricao)
                    existente.Descricao = importado.Descricao;
                // Repita para os demais campos relevantes...
                existente.UltimaAlteracao = DateTime.Now;
            }
        }


        private void BtnAplicarTodas_Click(object sender, EventArgs e)
        {
            if (dgvDuplicatas.SelectedCells.Count == 0) return;

            int rowIndex = dgvDuplicatas.SelectedCells[0].RowIndex;
            if (rowIndex < 0 || rowIndex >= duplicatas.Count) return;

            var acaoSelecionada = (AcaoDuplicata)dgvDuplicatas.Rows[rowIndex].Cells["colAcao"].Value;

            AplicarAcaoGlobal(acaoSelecionada);
        }

        private void AplicarAcaoGlobal(AcaoDuplicata acao)
        {
            foreach (DataGridViewRow row in dgvDuplicatas.Rows)
            {
                row.Cells["colAcao"].Value = acao;

                // Atualizar lista de duplicatas
                int idx = row.Index;
                if (idx >= 0 && idx < duplicatas.Count)
                {
                    duplicatas[idx].AcaoSelecionada = acao;
                }
            }
            dgvDuplicatas.Refresh();
        }

        private void BtnVisualizarDiferenca_Click(object sender, EventArgs e)
        {
            if (dgvDuplicatas.SelectedRows.Count == 0) return;

            int rowIndex = dgvDuplicatas.SelectedRows[0].Index;
            if (rowIndex < 0 || rowIndex >= duplicatas.Count) return;

            var duplicata = duplicatas[rowIndex];

            if (duplicata.ProdutoExistente != null && duplicata.ProdutoImportado != null)
            {
                using (var frmDetalhes = new frmDetalhesDuplicata(
                    duplicata.ProdutoExistente,
                    duplicata.ProdutoImportado))
                {
                    frmDetalhes.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Nenhum detalhe disponível para esta duplicata.",
                    "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Método para obter as ações selecionadas (chamado pelo form de importação)
        internal Dictionary<string, AcaoDuplicata> ObterAcoesSelecionadas()
        {
            return duplicatas.ToDictionary(
                d => d.Codigo,
                d => d.AcaoSelecionada
            );
        }
    }

    internal class frmDetalhesDuplicata : Form
    {
        private Produto produtoExistente;
        private Produto produtoImportado;
        private Button btnFechar;

        internal frmDetalhesDuplicata(Produto existente, Produto importado)
        {
            produtoExistente = existente;
            produtoImportado = importado;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.btnFechar = new Button();
            this.SuspendLayout();

            // btnFechar
            this.btnFechar.Location = new Point(400, 350);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new Size(75, 23);
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new EventHandler(this.btnFechar_Click);

            // frmDetalhesDuplicata
            this.ClientSize = new Size(500, 400);
            this.Controls.Add(this.btnFechar);
            this.Text = "Detalhes da Duplicata";
            this.StartPosition = FormStartPosition.CenterParent;
            this.ResumeLayout(false);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Implementar interface de comparação detalhada
            e.Graphics.DrawString("COMPARAÇÃO DE PRODUTOS",
                new Font("Arial", 12, FontStyle.Bold),
                Brushes.Black, 20, 20);

            e.Graphics.DrawString($"Produto: {produtoExistente.CodigoProduto} - {produtoExistente.Nome}",
                new Font("Arial", 10), Brushes.Black, 20, 50);

            // Exibir diferenças
            int y = 80;
            y = ExibirDiferenca(e, "Nome", produtoExistente.Nome, produtoImportado.Nome, y);
            y = ExibirDiferenca(e, "Categoria", produtoExistente.Categoria, produtoImportado.Categoria, y);
            y = ExibirDiferenca(e, "Preço", produtoExistente.PrecoVenda.ToString("C2"), produtoImportado.PrecoVenda.ToString("C2"), y);
            y = ExibirDiferenca(e, "Unidade", produtoExistente.UnidadeMedida, produtoImportado.UnidadeMedida, y);
            y = ExibirDiferenca(e, "Estoque", produtoExistente.QuantidadeAtual.ToString(), produtoImportado.QuantidadeAtual.ToString(), y);
        }

        private int ExibirDiferenca(PaintEventArgs e, string campo, string valorExistente, string valorImportado, int y)
        {
            bool diferente = valorExistente != valorImportado;
            var cor = diferente ? Brushes.Red : Brushes.Black;

            e.Graphics.DrawString($"{campo}:",
                new Font("Arial", 9, FontStyle.Bold),
                cor, 30, y);

            e.Graphics.DrawString($"Existente: {valorExistente}",
                new Font("Arial", 9),
                cor, 120, y);

            e.Graphics.DrawString($"Importado: {valorImportado}",
                new Font("Arial", 9),
                cor, 280, y);

            return y + 25;
        }
    }
}
