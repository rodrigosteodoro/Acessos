using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Acessos
{
    public partial class frmVisualizarDiferenca : Telerik.WinControls.UI.RadForm
    {
        public class DuplicataInfo
        {
            public Produto ProdutoExistente { get; set; }
            public  Produto ProdutoImportado { get; set; }
            public List<string> DiferencasEncontradas { get; set; } = new List<string>();
            public string TipoDuplicata { get; set; }
            public AcaoDuplicata AcaoSugerida { get; set; }
        }

        public enum AcaoDuplicata
        {
            ManterExistente = 0,
            SubstituirExistente = 1,
            CriarNovoProduto = 2,
            IgnorarImportacao = 3
        }

        private DuplicataInfo _duplicata;
        public AcaoDuplicata AcaoSelecionada { get; private set; }

        public frmVisualizarDiferenca(DuplicataInfo duplicata)
        {
            _duplicata = duplicata;
            InitializeComponent();
            ConfigurarFormularioCompleto();
            CarregarDadosComparacao();
        }

        private void ConfigurarFormularioCompleto()
        {
            lblTitulo.Text = $"Diferenças - {_duplicata.ProdutoImportado.CodigoProduto}";
            lblSubtitulo.Text = $"Tipo: {_duplicata.TipoDuplicata} | Ação Sugerida: {ObterDescricaoAcaoSugerida(_duplicata.AcaoSugerida)}";

            ConfigurarComboBoxAcoes();
            ConfigurarEventos();
            ConfigurarEstilosDataGridViews();
        }

        private void ConfigurarComboBoxAcoes()
        {
            cmbAcaoRecomendada.DataSource = Enum.GetValues(typeof(AcaoDuplicata));
            cmbAcaoRecomendada.SelectedItem = _duplicata.AcaoSugerida;
        }

        private void ConfigurarEventos()
        {
            btnAplicarAcao.Click += BtnAplicarAcao_Click;
            btnFechar.Click += BtnFechar_Click;
            cmbAcaoRecomendada.SelectedIndexChanged += CmbAcaoRecomendada_SelectedIndexChanged;

            // Vincular eventos de rolagem sincronizada
            dgvProdutoImportado.Scroll += (s, e) => SincronizarRolagem(dgvProdutoImportado, dgvProdutoExistente);
            dgvProdutoExistente.Scroll += (s, e) => SincronizarRolagem(dgvProdutoExistente, dgvProdutoImportado);
        }

        private void SincronizarRolagem(DataGridView origem, DataGridView destino)
        {
            destino.FirstDisplayedScrollingRowIndex = origem.FirstDisplayedScrollingRowIndex;
        }

        private void ConfigurarEstilosDataGridViews()
        {
            ConfigurarDataGridView(dgvProdutoImportado, Color.FromArgb(40, 167, 69)); // Verde
            ConfigurarDataGridView(dgvProdutoExistente, Color.FromArgb(220, 53, 69)); // Vermelho
        }

        private void ConfigurarDataGridView(DataGridView dgv, Color corCabecalho)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = corCabecalho;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersHeight = 30;

            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 123, 255);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);

            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CarregarDadosComparacao()
        {
            CarregarDadosProdutoImportado();
            CarregarDadosProdutoExistente();
            CarregarDiferencasDetalhadas();
            CarregarResumoCompleto();
        }

        private void CarregarDadosProdutoImportado()
        {
            dgvProdutoImportado.Rows.Clear();
            var produto = _duplicata.ProdutoImportado;

            AdicionarLinhaDados(dgvProdutoImportado, "Código", produto.CodigoProduto);
            AdicionarLinhaDados(dgvProdutoImportado, "Nome", produto.Nome);
            AdicionarLinhaDados(dgvProdutoImportado, "Descrição", produto.Descricao ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Categoria", produto.Categoria);
            AdicionarLinhaDados(dgvProdutoImportado, "Preço Custo", produto.PrecoCusto.ToString("C2", CultureInfo.CurrentCulture));
            AdicionarLinhaDados(dgvProdutoImportado, "Preço Venda", produto.PrecoVenda.ToString("C2", CultureInfo.CurrentCulture));
            AdicionarLinhaDados(dgvProdutoImportado, "Margem Lucro", produto.MargemLucro.ToString("F2") + "%");
            AdicionarLinhaDados(dgvProdutoImportado, "Quantidade Estoque", produto.QuantidadeAtual.ToString("N2"));
            AdicionarLinhaDados(dgvProdutoImportado, "Unidade Medida", produto.UnidadeMedida);
            AdicionarLinhaDados(dgvProdutoImportado, "Peso", produto.Peso.ToString("N3") + " kg" ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Volume", produto.Volume.ToString("N3") + " m³" ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Validade", produto.DataValidade?.ToString("dd/MM/yyyy") ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Subcategoria", produto.Subcategoria ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Marca", produto.Marca ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Código Barras", produto.CodigoBarras ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Data Cadastro", produto.DataCadastro.ToString("dd/MM/yyyy"));
            AdicionarLinhaDados(dgvProdutoImportado, "Data Atualização", produto.UltimaAlteracao.ToString("dd/MM/yyyy"));
            AdicionarLinhaDados(dgvProdutoImportado, "Ativo", produto.Ativo ? "Sim" : "Não");
            AdicionarLinhaDados(dgvProdutoImportado, "Fornecedor", produto.NomeFornecedor ?? "-");
            AdicionarLinhaDados(dgvProdutoImportado, "Lote", produto.Lote ?? "-");
        }

        private void CarregarDadosProdutoExistente()
        {
            dgvProdutoExistente.Rows.Clear();
            var produto = _duplicata.ProdutoExistente;

            AdicionarLinhaDados(dgvProdutoExistente, "Código", produto.CodigoProduto);
            AdicionarLinhaDados(dgvProdutoExistente, "Nome", produto.Nome);
            AdicionarLinhaDados(dgvProdutoExistente, "Descrição", produto.Descricao ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Categoria", produto.Categoria);
            AdicionarLinhaDados(dgvProdutoExistente, "Preço Custo", produto.PrecoCusto.ToString("C2", CultureInfo.CurrentCulture));
            AdicionarLinhaDados(dgvProdutoExistente, "Preço Venda", produto.PrecoVenda.ToString("C2", CultureInfo.CurrentCulture));
            AdicionarLinhaDados(dgvProdutoExistente, "Margem Lucro", produto.MargemLucro.ToString("F2") + "%");
            AdicionarLinhaDados(dgvProdutoExistente, "Quantidade Estoque", produto.QuantidadeAtual.ToString("N2"));
            AdicionarLinhaDados(dgvProdutoExistente, "Unidade Medida", produto.UnidadeMedida);
            AdicionarLinhaDados(dgvProdutoExistente, "Peso", produto.Peso.ToString("N3") + " kg" ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Volume", produto.Volume.ToString("N3") + " m³" ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Validade", produto.DataValidade?.ToString("dd/MM/yyyy") ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Subcategoria", produto.Subcategoria ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Marca", produto.Marca ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Código Barras", produto.CodigoBarras ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Data Cadastro", produto.DataCadastro.ToString("dd/MM/yyyy"));
            AdicionarLinhaDados(dgvProdutoExistente, "Data Atualização", produto.UltimaAlteracao.ToString("dd/MM/yyyy"));
            AdicionarLinhaDados(dgvProdutoExistente, "Ativo", produto.Ativo ? "Sim" : "Não");
            AdicionarLinhaDados(dgvProdutoExistente, "Fornecedor", produto.NomeFornecedor ?? "-");
            AdicionarLinhaDados(dgvProdutoExistente, "Lote", produto.Lote ?? "-");

            DestacarDiferencas();
        }

        private void AdicionarLinhaDados(DataGridView dgv, string campo, string valor)
        {
            int rowIndex = dgv.Rows.Add();
            dgv.Rows[rowIndex].Cells[0].Value = campo;
            dgv.Rows[rowIndex].Cells[1].Value = valor;
        }

        private void DestacarDiferencas()
        {
            for (int i = 0; i < dgvProdutoImportado.Rows.Count; i++)
            {
                var campo = dgvProdutoImportado.Rows[i].Cells[0].Value?.ToString();
                var valorImportado = dgvProdutoImportado.Rows[i].Cells[1].Value?.ToString();
                var valorExistente = dgvProdutoExistente.Rows[i].Cells[1].Value?.ToString();

                if (valorImportado != valorExistente)
                {
                    dgvProdutoImportado.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205); // Amarelo claro
                    dgvProdutoImportado.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                    dgvProdutoExistente.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 205);
                    dgvProdutoExistente.Rows[i].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                }
            }
        }

        private void CarregarDiferencasDetalhadas()
        {
            lstDiferencas.Items.Clear();

            if (_duplicata.DiferencasEncontradas.Count == 0)
            {
                lstDiferencas.Items.Add("Nenhuma diferença encontrada nos dados principais.");
                return;
            }

            lstDiferencas.Items.Add($"=== DIFERENÇAS ENCONTRADAS ({_duplicata.DiferencasEncontradas.Count}) ===");
            lstDiferencas.Items.Add("");

            foreach (var diferenca in _duplicata.DiferencasEncontradas)
            {
                lstDiferencas.Items.Add($"• {diferenca}");
            }

            lstDiferencas.Items.Add("");
            lstDiferencas.Items.Add($"Tipo de Duplicata: {_duplicata.TipoDuplicata}");
            lstDiferencas.Items.Add($"Ação Sugerida: {ObterDescricaoAcaoSugerida(_duplicata.AcaoSugerida)}");
        }

        private void CarregarResumoCompleto()
        {
            rtbResumo.Clear();

            rtbResumo.SelectionFont = new Font("Segoe UI", 14F, FontStyle.Bold);
            rtbResumo.SelectionColor = Color.FromArgb(52, 58, 64);
            rtbResumo.AppendText("ANÁLISE DE DUPLICATA\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbResumo.SelectionColor = Color.FromArgb(108, 117, 125);
            rtbResumo.AppendText($"Produto: {_duplicata.ProdutoImportado.CodigoProduto} - {_duplicata.ProdutoImportado.Nome}\n");
            rtbResumo.AppendText($"Data da Análise: {DateTime.Now:dd/MM/yyyy HH:mm:ss}\n\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbResumo.SelectionColor = Color.FromArgb(52, 58, 64);
            rtbResumo.AppendText("INFORMAÇÕES DA DUPLICATA\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbResumo.SelectionColor = Color.FromArgb(0, 123, 255);
            rtbResumo.AppendText($"Tipo: {_duplicata.TipoDuplicata}\n");
            rtbResumo.AppendText($"Ação Sugerida: {ObterDescricaoAcaoSugerida(_duplicata.AcaoSugerida)}\n");
            rtbResumo.AppendText($"Diferenças Encontradas: {_duplicata.DiferencasEncontradas.Count}\n\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbResumo.SelectionColor = Color.FromArgb(40, 167, 69);
            rtbResumo.AppendText("PRODUTO IMPORTADO\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbResumo.SelectionColor = Color.Black;
            AdicionarResumoBasicoProduto(_duplicata.ProdutoImportado);

            rtbResumo.SelectionFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbResumo.SelectionColor = Color.FromArgb(220, 53, 69);
            rtbResumo.AppendText("\nPRODUTO EXISTENTE\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbResumo.SelectionColor = Color.Black;
            AdicionarResumoBasicoProduto(_duplicata.ProdutoExistente);

            if (_duplicata.DiferencasEncontradas.Count > 0)
            {
                rtbResumo.SelectionFont = new Font("Segoe UI", 12F, FontStyle.Bold);
                rtbResumo.SelectionColor = Color.FromArgb(255, 193, 7);
                rtbResumo.AppendText("\nDIFERENÇAS IDENTIFICADAS\n");

                rtbResumo.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
                rtbResumo.SelectionColor = Color.FromArgb(220, 53, 69);

                foreach (var diferenca in _duplicata.DiferencasEncontradas)
                {
                    rtbResumo.AppendText($"• {diferenca}\n");
                }
            }

            rtbResumo.SelectionFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            rtbResumo.SelectionColor = Color.FromArgb(0, 123, 255);
            rtbResumo.AppendText("\nRECOMENDAÇÃO\n");

            rtbResumo.SelectionFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            rtbResumo.SelectionColor = Color.Black;
            rtbResumo.AppendText(ObterRecomendacaoDetalhada(_duplicata.AcaoSugerida));
        }

        private void AdicionarResumoBasicoProduto(Produto produto)
        {
            rtbResumo.AppendText($"Código: {produto.CodigoProduto}\n");
            rtbResumo.AppendText($"Nome: {produto.Nome}\n");
            rtbResumo.AppendText($"Preço Venda: {produto.PrecoVenda:C2}\n");
            rtbResumo.AppendText($"Estoque: {produto.QuantidadeAtual:N2}\n");
            rtbResumo.AppendText($"Categoria: {produto.Categoria}\n");
            rtbResumo.AppendText($"Marca: {produto.Marca ?? "-"}\n");
            rtbResumo.AppendText($"Ativo: {(produto.Ativo ? "Sim" : "Não")}\n\n");
        }

        private string ObterRecomendacaoDetalhada(AcaoDuplicata acao)
        {
            return acao switch
            {
                AcaoDuplicata.ManterExistente =>
                    "Recomenda-se manter o produto existente no banco de dados. " +
                    "O produto importado será descartado.",

                AcaoDuplicata.SubstituirExistente =>
                    "Recomenda-se substituir o produto existente pelos dados do produto importado. " +
                    "Todas as informações do produto serão atualizadas.",

                AcaoDuplicata.CriarNovoProduto =>
                    "Recomenda-se criar um novo produto com os dados importados. " +
                    "O código do produto será modificado para evitar conflitos.",

                AcaoDuplicata.IgnorarImportacao =>
                    "Recomenda-se ignorar completamente o produto importado. " +
                    "Nenhuma ação será realizada com este item.",

                _ => "Nenhuma recomendação específica disponível."
            };
        }

        private string ObterDescricaoAcaoSugerida(AcaoDuplicata acao)
        {
            return acao switch
            {
                AcaoDuplicata.ManterExistente => "Manter Produto Existente",
                AcaoDuplicata.SubstituirExistente => "Substituir Produto Existente",
                AcaoDuplicata.CriarNovoProduto => "Criar Novo Produto",
                AcaoDuplicata.IgnorarImportacao => "Ignorar Importação",
                _ => "Ação Desconhecida"
            };
        }

        private void CmbAcaoRecomendada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAcaoRecomendada.SelectedItem != null)
            {
                AcaoSelecionada = (AcaoDuplicata)cmbAcaoRecomendada.SelectedItem;
            }
        }

        private void BtnAplicarAcao_Click(object sender, EventArgs e)
        {
            var acao = (AcaoDuplicata)cmbAcaoRecomendada.SelectedItem;
            AcaoSelecionada = acao;

            var mensagem = $"A ação '{ObterDescricaoAcaoSugerida(acao)}' será aplicada a este produto.\n\nDeseja confirmar?";
            var resultado = MessageBox.Show(mensagem, "Confirmar Ação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
