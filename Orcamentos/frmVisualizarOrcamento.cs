using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using Telerik.WinControls.UI;

namespace Acessos
{
    public partial class frmVisualizarOrcamento : Telerik.WinControls.UI.RadForm
    {
        private OrcamentoRepository repository;
        private Orcamento orcamentoAtual;
        private string connectionString;
        private readonly Orcamento _orcamento;
        ClienteRepository clienteRepository;

        public frmVisualizarOrcamento(Orcamento orcamento)
        {
            InitializeComponent();
            _orcamento = orcamento;
            CarregarDadosOrcamento();
            orcamentoAtual = orcamento;
           repository = new OrcamentoRepository();
            clienteRepository = new ClienteRepository();          
        }

        public frmVisualizarOrcamento(string conexao)
        {
            InitializeComponent();
            connectionString = conexao;
            repository = new OrcamentoRepository();
        }

        private void VisualizarOrcamento_Load(object sender, EventArgs e)
        {
            if (orcamentoAtual != null)
            {
                CarregarDadosOrcamento();
            }
            else
            {
                MessageBox.Show("Nenhum orçamento foi fornecido para visualização.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void CarregarDadosOrcamento()
        {
            try
            {
                MostrarProgresso(true);

                // Carregar dados completos do orçamento se necessário
                if (orcamentoAtual.Cliente == null && orcamentoAtual.ClienteID > 0)
                {
                    var clientes = await clienteRepository.ObterTodosClientesAsync(); // Aguarda a conclusão da tarefa
                    orcamentoAtual.Cliente = clientes.FirstOrDefault(c => c.ID == orcamentoAtual.ClienteID);
                }

                // Preencher informações do cabeçalho
                PreencherCabecalho();

                // Preencher dados do cliente
                PreencherDadosCliente();

                // Configurar e carregar grid de itens
                ConfigurarGridItens();
                CarregarItensGrid();

                // Calcular e exibir totais
                CalcularTotais();

                MostrarProgresso(false);
            }
            catch (Exception ex)
            {
                MostrarProgresso(false);
                MessageBox.Show($"Erro ao carregar dados do orçamento: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PreencherCabecalho()
        {
            lblNumeroOrcamento.Text = $"Orçamento Nº: {orcamentoAtual.CodigoOrcamento}";
            lblDataOrcamento.Text = $"Data: {orcamentoAtual.DataCriacao:dd/MM/yyyy}";

            // Configurar status com ícone e cor
            ConfigurarStatus();
        }

        private void ConfigurarStatus()
        {
            string statusTexto = ObterDescricaoStatus(orcamentoAtual.Status);
            lblStatus.Text = $"Status: {statusTexto}";

            switch (orcamentoAtual.Status)
            {
                case StatusOrcamento.Novo:
                    iconStatus.Text = "🆕";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(52, 152, 219);
                    break;
                case StatusOrcamento.Pendente:
                    iconStatus.Text = "⏳";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(241, 196, 15);
                    break;
                case StatusOrcamento.Aprovado:
                    iconStatus.Text = "✅";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
                    break;
                case StatusOrcamento.Rejeitado:
                    iconStatus.Text = "❌";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
                    break;
                case StatusOrcamento.Cancelado:
                    iconStatus.Text = "🚫";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(149, 165, 166);
                    break;
                case StatusOrcamento.Expirado:
                    iconStatus.Text = "⏰";
                    lblStatus.ForeColor = System.Drawing.Color.FromArgb(230, 126, 34);
                    break;
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

        private void PreencherDadosCliente()
        {
            if (orcamentoAtual.Cliente != null)
            {
                lblCliente.Text = $"Cliente: {orcamentoAtual.Cliente.Nome ?? "Não informado"}";

                // Montar endereço completo
                string enderecoCompleto = MontarEnderecoCompleto(orcamentoAtual.Cliente);
                lblEndereco.Text = $"🏠 Endereço: {enderecoCompleto}";

                // Telefone e email (campos não existem na classe Cliente atual, mas podem ser adicionados)
                lblTelefone.Text = "📞 Telefone: Não informado";
                lblEmail.Text = "📧 Email: Não informado";
            }
            else
            {
                lblCliente.Text = "Cliente: Não informado";
                lblEndereco.Text = "🏠 Endereço: Não informado";
                lblTelefone.Text = "📞 Telefone: Não informado";
                lblEmail.Text = "📧 Email: Não informado";
            }
        }

        private string MontarEnderecoCompleto(ICliente cliente)
        {
            var partes = new[]
            {
                cliente.Endereco,
                cliente.Numero,
                cliente.Bairro,
                cliente.Localidade,
                cliente.UF
            }.Where(p => !string.IsNullOrEmpty(p));

            return string.Join(", ", partes);
        }

        private void ConfigurarGridItens()
        {
            dgvItens.MasterTemplate.Columns.Clear();
            dgvItens.MasterTemplate.AutoGenerateColumns = false;

            // Configurar colunas
            dgvItens.MasterTemplate.Columns.Add(new GridViewTextBoxColumn("DescricaoProduto")
            {
                HeaderText = "Produto/Serviço",
                Width = 300,
                FieldName = "DescricaoProduto"
            });

            dgvItens.MasterTemplate.Columns.Add(new GridViewDecimalColumn("Quantidade")
            {
                HeaderText = "Qtd",
                Width = 80,
                FieldName = "Quantidade",
                FormatString = "{0:N2}"
            });

            dgvItens.MasterTemplate.Columns.Add(new GridViewDecimalColumn("PrecoUnitario")
            {
                HeaderText = "Preço Unit.",
                Width = 100,
                FieldName = "PrecoUnitario",
                FormatString = "{0:C2}"
            });

            dgvItens.MasterTemplate.Columns.Add(new GridViewDecimalColumn("Desconto")
            {
                HeaderText = "Desc. %",
                Width = 80,
                FieldName = "Desconto",
                FormatString = "{0:N2}"
            });

            dgvItens.MasterTemplate.Columns.Add(new GridViewDecimalColumn("Total")
            {
                HeaderText = "Total",
                Width = 120,
                FieldName = "Total",
                FormatString = "{0:C2}"
            });

            // Configurações gerais
            dgvItens.ReadOnly = true;
            dgvItens.AllowAddNewRow = false;
            dgvItens.AllowDeleteRow = false;
            dgvItens.ShowGroupPanel = false;
            dgvItens.EnableGrouping = false;
        }

        private void CarregarItensGrid()
        {
            var itensAtivos = orcamentoAtual.Itens.Where(i => i.Ativo).ToList();
            dgvItens.DataSource = itensAtivos;
        }

        private void CalcularTotais()
        {
            lblSubtotal.Text = $"Subtotal: {orcamentoAtual.Subtotal:C2}";
            lblSubtotal.Visible = orcamentoAtual.DescontoGeral > 0;

            lblDesconto.Text = $"Desconto: {orcamentoAtual.ValorDesconto:C2} ({orcamentoAtual.DescontoGeral:N2}%)";
            lblDesconto.Visible = orcamentoAtual.DescontoGeral > 0;

            lblValorTotal.Text = $"Total: {orcamentoAtual.ValorTotal:C2}";
        }

        #region ‑---- Eventos de Botões ---------------------------------------------

        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

      
        private async void btnImprimir_Click(object sender, System.EventArgs e)
        {
            try
            {
                MostrarProgresso(true);

                // Gerar PDF temporário para impressão
                string tempPdfPath = await GerarPDFTemporario();

                if (!string.IsNullOrEmpty(tempPdfPath) && File.Exists(tempPdfPath))
                {
                    // Abrir PDF no visualizador padrão para impressão
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = tempPdfPath,
                        UseShellExecute = true
                    });
                }
                else
                {
                    MessageBox.Show("Erro ao gerar arquivo para impressão.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao imprimir: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarProgresso(false);
            }
        }

      
        private async void btnSalvarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "Arquivos PDF (*.pdf)|*.pdf";
                    saveDialog.Title = "Salvar Orçamento em PDF";
                    saveDialog.FileName = $"Orcamento_{orcamentoAtual.CodigoOrcamento}_{DateTime.Now:yyyyMMdd}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        MostrarProgresso(true);

                        await Task.Run(() => GerarPDF(saveDialog.FileName));

                        MessageBox.Show($"PDF salvo com sucesso em:\n{saveDialog.FileName}",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Perguntar se deseja abrir o arquivo
                        if (MessageBox.Show("Deseja abrir o arquivo PDF?", "Abrir Arquivo",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar PDF: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MostrarProgresso(false);
            }
        }

        private void MostrarProgresso(bool mostrar)
        {
            progressBar.Visible = mostrar;
            if (mostrar)
            {
                progressBar.StartWaiting();
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            }
            else
            {
                progressBar.StopWaiting();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        #endregion

        #region ‑---- Geração de PDF -----------------------------------------------

        [Obsolete]
        private async Task<string> GerarPDFTemporario()
        {
            return await Task.Run(() =>
            {
                string tempPath = Path.Combine(Path.GetTempPath(),
                    $"Orcamento_{orcamentoAtual.CodigoOrcamento}_{DateTime.Now:yyyyMMddHHmmss}.pdf");
                GerarPDF(tempPath);
                return tempPath;
            });
        }

        [Obsolete]
        private void GerarPDF(string caminhoArquivo)
        {
            try
            {
                // Criar documento MigraDoc
                Document document = CriarDocumento();

                // Renderizar para PDF
                PdfDocumentRenderer renderer = new PdfDocumentRenderer(true);
                renderer.Document = document;
                renderer.RenderDocument();

                // Salvar arquivo
                renderer.PdfDocument.Save(caminhoArquivo);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar PDF: {ex.Message}", ex);
            }
        }

        private Document CriarDocumento()
        {
            // Criar novo documento
            Document document = new Document();
            document.Info.Title = $"Orçamento {orcamentoAtual.CodigoOrcamento}";
            document.Info.Subject = "Orçamento de Produtos/Serviços";
            document.Info.Author = "Sistema de Orçamentos";
            // Remover a linha problemática: document.Info.Creator = "Sistema de Orçamentos";

            // Propriedades válidas do DocumentInfo:
            document.Info.Keywords = "orçamento, vendas, produtos, serviços";

            // Definir estilos
            DefinirEstilos(document);

            // Adicionar seção
            Section section = document.AddSection();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.LeftMargin = "2cm";
            section.PageSetup.RightMargin = "2cm";
            section.PageSetup.TopMargin = "2cm";
            section.PageSetup.BottomMargin = "2cm";

            // Adicionar conteúdo
            AdicionarCabecalho(section);
            AdicionarDadosOrcamento(section);
            AdicionarDadosCliente(section);
            AdicionarItensOrcamento(section);
            AdicionarTotais(section);
            AdicionarObservacoes(section);
            AdicionarRodape(section);

            return document;
        }

        private void DefinirEstilos(Document document)
        {
            // Estilo para título
            Style style = document.Styles["Heading1"];
            style.Font.Name = "Arial";
            style.Font.Size = 16;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkBlue;
            style.ParagraphFormat.SpaceAfter = "0.5cm";

            // Estilo para subtítulo
            style = document.Styles["Heading2"];
            style.Font.Name = "Arial";
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.Font.Color = Colors.DarkGray;
            style.ParagraphFormat.SpaceBefore = "0.3cm";
            style.ParagraphFormat.SpaceAfter = "0.2cm";

            // Estilo para texto normal
            style = document.Styles["Normal"];
            style.Font.Name = "Arial";
            style.Font.Size = 10;
        }

        private void AdicionarCabecalho(Section section)
        {
            Paragraph paragraph = section.AddParagraph("ORÇAMENTO", "Heading1");
            paragraph.Format.Alignment = ParagraphAlignment.Center;

            paragraph = section.AddParagraph();
            paragraph.AddText($"Número: {orcamentoAtual.CodigoOrcamento}");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 12;
            paragraph.Format.Font.Bold = true;
        }

        private void AdicionarDadosOrcamento(Section section)
        {
            section.AddParagraph("Dados do Orçamento", "Heading2");

            Table table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0.25;
            table.Borders.Color = Colors.Gray;
            table.Rows.LeftIndent = 0;

            // Definir colunas
            Column column = table.AddColumn("4cm");
            column = table.AddColumn("6cm");

            // Adicionar linhas
            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Data de Criação:");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[1].AddParagraph(orcamentoAtual.DataCriacao.ToString("dd/MM/yyyy"));

            row = table.AddRow();
            row.Cells[0].AddParagraph("Validade:");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[1].AddParagraph(orcamentoAtual.DataValidade?.ToString("dd/MM/yyyy") ?? "Não informada");

            row = table.AddRow();
            row.Cells[0].AddParagraph("Status:");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[1].AddParagraph(ObterDescricaoStatus(orcamentoAtual.Status));
        }

        private void AdicionarDadosCliente(Section section)
        {
            section.AddParagraph("Dados do Cliente", "Heading2");

            if (orcamentoAtual.Cliente != null)
            {
                Table table = section.AddTable();
                table.Style = "Table";
                table.Borders.Width = 0.25;
                table.Borders.Color = Colors.Gray;

                Column column = table.AddColumn("4cm");
                column = table.AddColumn("10cm");

                Row row = table.AddRow();
                row.Cells[0].AddParagraph("Nome:");
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[1].AddParagraph(orcamentoAtual.Cliente.Nome ?? "Não informado");

                row = table.AddRow();
                row.Cells[0].AddParagraph("CPF/CNPJ:");
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[1].AddParagraph(orcamentoAtual.Cliente.CPFCNPJ ?? "Não informado");

                row = table.AddRow();
                row.Cells[0].AddParagraph("Endereço:");
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[1].AddParagraph(MontarEnderecoCompleto(orcamentoAtual.Cliente));
            }
            else
            {
                section.AddParagraph("Cliente não informado.");
            }
        }

        private void AdicionarItensOrcamento(Section section)
        {
            section.AddParagraph("Itens do Orçamento", "Heading2");

            Table table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0.25;
            table.Borders.Color = Colors.Gray;
            table.Rows.LeftIndent = 0;

            // Definir colunas
            Column column = table.AddColumn("6cm");
            column = table.AddColumn("2cm");
            column = table.AddColumn("2.5cm");
            column = table.AddColumn("1.5cm");
            column = table.AddColumn("2.5cm");

            // Cabeçalho
            Row row = table.AddRow();
            row.HeadingFormat = true;
            row.Format.Font.Bold = true;
            row.Shading.Color = Colors.LightGray;
            row.Cells[0].AddParagraph("Produto/Serviço");
            row.Cells[1].AddParagraph("Qtd");
            row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[2].AddParagraph("Preço Unit.");
            row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[3].AddParagraph("Desc. %");
            row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
            row.Cells[4].AddParagraph("Total");
            row.Cells[4].Format.Alignment = ParagraphAlignment.Right;

            // Itens
            foreach (var item in orcamentoAtual.Itens.Where(i => i.Ativo))
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph(item.DescricaoProduto ?? "");
                row.Cells[1].AddParagraph(item.Quantidade.ToString("N2"));
                row.Cells[1].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[2].AddParagraph(item.PrecoUnitario.ToString("C2"));
                row.Cells[2].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[3].AddParagraph(item.Desconto.ToString("N2"));
                row.Cells[3].Format.Alignment = ParagraphAlignment.Center;
                row.Cells[4].AddParagraph(item.Total.ToString("C2"));
                row.Cells[4].Format.Alignment = ParagraphAlignment.Right;
            }
        }

        private void AdicionarTotais(Section section)
        {
            section.AddParagraph("Resumo Financeiro", "Heading2");

            Table table = section.AddTable();
            table.Style = "Table";
            table.Borders.Width = 0.25;
            table.Borders.Color = Colors.Gray;

            Column column = table.AddColumn("10cm");
            column = table.AddColumn("4cm");

            Row row = table.AddRow();
            row.Cells[0].AddParagraph("Subtotal:");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[1].AddParagraph(orcamentoAtual.Subtotal.ToString("C2"));
            row.Cells[1].Format.Alignment = ParagraphAlignment.Right;

            if (orcamentoAtual.DescontoGeral > 0)
            {
                row = table.AddRow();
                row.Cells[0].AddParagraph($"Desconto ({orcamentoAtual.DescontoGeral:N2}%):");
                row.Cells[0].Format.Font.Bold = true;
                row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[1].AddParagraph($"- {orcamentoAtual.ValorDesconto:C2}");
                row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
                row.Cells[1].Format.Font.Color = Colors.Red;
            }

            row = table.AddRow();
            row.Cells[0].AddParagraph("VALOR TOTAL:");
            row.Cells[0].Format.Font.Bold = true;
            row.Cells[0].Format.Font.Size = 12;
            row.Cells[0].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[1].AddParagraph(orcamentoAtual.ValorTotal.ToString("C2"));
            row.Cells[1].Format.Font.Bold = true;
            row.Cells[1].Format.Font.Size = 12;
            row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[1].Format.Font.Color = Colors.DarkGreen;
            row.Shading.Color = Colors.LightGreen;
        }

        private void AdicionarObservacoes(Section section)
        {
            if (!string.IsNullOrEmpty(orcamentoAtual.Observacoes))
            {
                section.AddParagraph("Observações", "Heading2");
                Paragraph paragraph = section.AddParagraph(orcamentoAtual.Observacoes);
                paragraph.Format.Borders.Top.Width = 0.5;
                paragraph.Format.Borders.Top.Color = Colors.Gray;
                paragraph.Format.SpaceBefore = "0.2cm";
                paragraph.Format.SpaceAfter = "0.5cm";
            }
        }

        private void AdicionarRodape(Section section)
        {
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.SpaceBefore = "1cm";
            paragraph.Format.Borders.Top.Width = 0.5;
            paragraph.Format.Borders.Top.Color = Colors.Gray;
            paragraph.AddText($"Documento gerado em {DateTime.Now:dd/MM/yyyy HH:mm}");
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Format.Font.Size = 8;
            paragraph.Format.Font.Color = Colors.Gray;
        }

        #endregion
    }
}
