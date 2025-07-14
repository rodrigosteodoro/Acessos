using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acessos
{
    public partial class frmProdutos : Telerik.WinControls.UI.RadForm
    {
        private ProdutoDAL produtoDAL;
        private Fornecedor fornecedorDAL;
        private IProdutos produtoAtual;
        private bool modoEdicao = false;
        private bool calculandoMargem = false;

        public frmProdutos()
        {
            InitializeComponent();
            produtoDAL = new ProdutoDAL();
            fornecedorDAL = new Fornecedor();
            produtoAtual = new Produto();
            ConfigurarEventosImagem();
        }

        private async void frmProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                await CarregarFornecedores();
                await ResetarFormularioAsync();
            }
            catch (Exception ex)
            {
                Mensagens.Erro("Erro ao carregar o formulário", ex.Message);
            }
        }

        #region Configuração Inicial

        private void ConfigurarFormulario()
        {
            cmbUnidadeMedida.SelectedIndex = 0;
            cmbTipoProduto.SelectedIndex = 0;
            cmbOrigemProduto.SelectedIndex = 0;
            dtpInicioPromocao.Value = DateTime.Now;
            dtpFimPromocao.Value = DateTime.Now.AddDays(30);
        }

        private void ConfigurarEventosImagem()
        {
            pictureBoxProduto.AllowDrop = true;
            pictureBoxProduto.DragEnter += (s, e) => ImagemUtils.PictureBoxProduto_DragEnter(s, e);
            pictureBoxProduto.DragDrop += (s, e) => CarregarImagemDoArquivo(ImagemUtils.ObterArquivoArrastado(e));
        }        

        private async Task ResetarFormularioAsync()
        {
            LimparCampos();
            await GerarCodigoProdutoAsync();
            produtoAtual = new Produto();
            modoEdicao = false;
            btnEditar.Enabled = false;
            AtualizarLabelsData();
        }
        private async Task CarregarFornecedores()
        {
            try
            {
                var fornecedores = await fornecedorDAL.ObterTodosFornecedoresAsync() ?? new List<Fornecedor>();
                cmbFornecedor.DataSource = fornecedores;
                cmbFornecedor.DisplayMember = "RazaoSocial";
                cmbFornecedor.ValueMember = "ID";

                // Só selecione índice se houver itens
                if (fornecedores.Count > 0)
                    cmbFornecedor.SelectedIndex = 0;
                else
                    cmbFornecedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task GerarCodigoProdutoAsync()
        {
            try
            {
                var proximoCodigo = await produtoDAL.ObterProximoCodigo();
                txtCodigoProduto.Text = proximoCodigo.ToString("D6");
            }
            catch (Exception ex)
            {
                txtCodigoProduto.Text = "000001";
                Mensagens.Aviso("Erro ao gerar código", ex.Message);
            }
        }

        #endregion

        #region Eventos dos Botões

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var erros = ValidarCampos();
                if (erros.Count > 0)
                {
                    Mensagens.Validacao(erros);
                    return;
                }

                PreencherObjetoProduto();

                bool sucesso;
                string mensagem;

                if (modoEdicao)
                {
                    sucesso = await produtoDAL.AtualizarProduto(produtoAtual);
                    mensagem = "Produto atualizado com sucesso!";
                }
                else
                {
                    var novoId = await produtoDAL.InserirProduto(produtoAtual);
                    produtoAtual.ID = novoId;
                    sucesso = novoId > 0;
                    mensagem = "Produto cadastrado com sucesso!";
                }

                if (sucesso)
                {
                    Mensagens.Sucesso(mensagem);
                    await ResetarFormularioAsync();
                    btnEditar.Enabled = true;
                }
                else
                {
                    Mensagens.Erro("Erro ao salvar produto", "Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                Mensagens.Erro("Erro ao salvar", ex.Message);
            }
        }

        private async void btnNovo_Click(object sender, EventArgs e)
        {           
            await ResetarFormularioAsync();
            txtNome.Focus();
        }

        private async void btnLimpar_Click(object sender, EventArgs e)
        {
            if (Mensagens.Confirmacao("Deseja realmente limpar todos os campos?"))
                await ResetarFormularioAsync();
        }      

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (produtoAtual == null || produtoAtual.ID == 0)
            {
                Mensagens.Aviso("Nenhum produto carregado para edição.");
                return;
            }

            modoEdicao = true;
            txtNome.Focus();
            Mensagens.Aviso("Modo de edição ativado. Faça as alterações e clique em Salvar.");
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();           
        }

        #endregion

        #region Eventos de Cálculo de Preços

        private void numPrecoCusto_ValueChanged(object sender, EventArgs e)
        {
            CalculoPrecoOuMargem(() => CalcularPrecoVenda());
        }

        private void numPrecoVenda_ValueChanged(object sender, EventArgs e)
        {
            CalculoPrecoOuMargem(() => CalcularMargemLucro());
        }

        private void numMargemLucro_ValueChanged(object sender, EventArgs e)
        {
            CalculoPrecoOuMargem(() => CalcularPrecoVenda());
        }

        private void CalculoPrecoOuMargem(Action acao)
        {
            if (calculandoMargem) return;
            try
            {
                calculandoMargem = true;
                acao();
            }
            catch (Exception ex)
            {
                Mensagens.Aviso("Erro no cálculo", ex.Message);
            }
            finally
            {
                calculandoMargem = false;
            }
        }

        private void CalcularPrecoVenda()
        {
            if (numPrecoCusto.Value > 0 && numMargemLucro.Value > 0)
            {
                var precoVenda = numPrecoCusto.Value * (1 + (numMargemLucro.Value / 100));
                numPrecoVenda.Value = Math.Round(precoVenda, 2);
            }
        }

        private void CalcularMargemLucro()
        {
            if (numPrecoCusto.Value > 0 && numPrecoVenda.Value > 0)
            {
                var margem = ((numPrecoVenda.Value - numPrecoCusto.Value) / numPrecoCusto.Value) * 100;
                numMargemLucro.Value = Math.Round(margem, 2);
            }
        }

        #endregion

        #region Eventos de Promoção

        private void chkPromocaoAtiva_CheckedChanged(object sender, EventArgs e)
        {
            bool promocaoAtiva = chkPromocaoAtiva.Checked;
            numPrecoPromocional.Enabled = promocaoAtiva;
            dtpInicioPromocao.Enabled = promocaoAtiva;
            dtpFimPromocao.Enabled = promocaoAtiva;
            if (!promocaoAtiva) numPrecoPromocional.Value = 0;
        }

        #endregion

        #region Eventos de Imagem

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos os Arquivos|*.*";
                    openFileDialog.Title = "Selecionar Imagem do Produto";
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                        CarregarImagemDoArquivo(openFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                Mensagens.Erro("Erro ao carregar imagem", ex.Message);
            }
        }

        private void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            pictureBoxProduto.Image = null;
            produtoAtual.Imagem = null;
        }

        private void CarregarImagemDoArquivo(string caminhoArquivo)
        {
            try
            {
                if (string.IsNullOrEmpty(caminhoArquivo) || !ImagemUtils.IsImageFile(caminhoArquivo))
                    return;

                using (var image = Image.FromFile(caminhoArquivo))
                {
                    var imagemRedimensionada = ImagemUtils.RedimensionarImagem(image, 300, 300);
                    pictureBoxProduto.Image = imagemRedimensionada;
                    produtoAtual.Imagem = ImagemUtils.ImagemParaBytes(imagemRedimensionada);
                }
            }
            catch (Exception ex)
            {
                Mensagens.Erro("Erro ao processar imagem", ex.Message);
            }
        }

        #endregion

        #region Métodos de Validação e Manipulação

        private List<string> ValidarCampos()
        {
            var erros = new List<string>();
            if (string.IsNullOrWhiteSpace(txtNome.Text))
                erros.Add("O campo Nome é obrigatório.");
            if (cmbFornecedor.SelectedIndex == -1)
                erros.Add("Selecione um fornecedor.");
            if (cmbUnidadeMedida.SelectedIndex == -1)
                erros.Add("Selecione uma unidade de medida.");
            if (numMargemLucro.Value <= 0)
                erros.Add("A margem de lucro é obrigatória e deve ser maior que zero.");

            if (chkPromocaoAtiva.Checked)
            {
                if (numPrecoPromocional.Value <= 0)
                    erros.Add("Informe o preço promocional.");
                if (dtpFimPromocao.Value <= dtpInicioPromocao.Value)
                    erros.Add("A data fim da promoção deve ser posterior à data de início.");
            }
            return erros;
        }

        private void PreencherObjetoProduto()
        {
            produtoAtual.CodigoProduto = txtCodigoProduto.Text.Trim();
            produtoAtual.CodigoBarras = txtCodigoBarras.Text.Trim();
            produtoAtual.Nome = txtNome.Text.Trim();
            produtoAtual.Descricao = txtDescricao.Text.Trim();

            // Classificação
            produtoAtual.Categoria = txtCategoria.Text.Trim();
            produtoAtual.Subcategoria = txtSubcategoria.Text.Trim();
            produtoAtual.Marca = txtMarca.Text.Trim();
            produtoAtual.FornecedorID = (int)cmbFornecedor.SelectedValue;
            produtoAtual.NomeFornecedor = cmbFornecedor.Text;
            produtoAtual.UnidadeMedida = cmbUnidadeMedida.Text;
            produtoAtual.TipoProduto = cmbTipoProduto.Text;

            // Estoque
            produtoAtual.QuantidadeAtual = numQuantidadeAtual.Value;
            produtoAtual.EstoqueMinimo = numEstoqueMinimo.Value;
            produtoAtual.EstoqueMaximo = numEstoqueMaximo.Value;
            produtoAtual.LocalizacaoEstoque = txtLocalizacaoEstoque.Text.Trim();
            produtoAtual.PermiteEstoqueNegativo = chkPermiteEstoqueNegativo.Checked;

            // Preços
            produtoAtual.PrecoCusto = numPrecoCusto.Value;
            produtoAtual.PrecoVenda = numPrecoVenda.Value;
            produtoAtual.MargemLucro = numMargemLucro.Value;
            produtoAtual.PromocaoAtiva = chkPromocaoAtiva.Checked;
            produtoAtual.PrecoPromocional = chkPromocaoAtiva.Checked ? numPrecoPromocional.Value : (decimal?)null;
            produtoAtual.InicioPromocao = chkPromocaoAtiva.Checked ? dtpInicioPromocao.Value : (DateTime?)null;
            produtoAtual.FimPromocao = chkPromocaoAtiva.Checked ? dtpFimPromocao.Value : (DateTime?)null;

            // Tributação
            produtoAtual.OrigemProduto = cmbOrigemProduto.Text;
            produtoAtual.NCM = txtNCM.Text.Trim();
            produtoAtual.CFOP = txtCFOP.Text.Trim();
            produtoAtual.CSTCSOSN = txtCSTCSOSN.Text.Trim();
            produtoAtual.AliquotaICMS = numICMS.Value;
            produtoAtual.AliquotaPIS = numPIS.Value;
            produtoAtual.AliquotaCOFINS = numCOFINS.Value;
            produtoAtual.AliquotaIPI = numIPI.Value;

            // Imagem já preenchida nos métodos de imagem

            // Complementares
            produtoAtual.Ativo = chkAtivo.Checked;
            produtoAtual.Observacoes = txtObservacoes.Text.Trim();
            produtoAtual.SKU = txtSKU.Text.Trim();
            produtoAtual.UltimaAlteracao = DateTime.Now;
        }

        private void PreencherCampos(IProdutos produto)
        {
            if (produto == null) return;
            txtCodigoProduto.Text = produto.CodigoProduto ?? "";
            txtCodigoBarras.Text = produto.CodigoBarras ?? "";
            txtNome.Text = produto.Nome ?? "";
            txtDescricao.Text = produto.Descricao ?? "";

            // Classificação
            txtCategoria.Text = produto.Categoria ?? "";
            txtSubcategoria.Text = produto.Subcategoria ?? "";
            txtMarca.Text = produto.Marca ?? "";
            cmbFornecedor.SelectedValue = produto.FornecedorID;
            cmbUnidadeMedida.Text = produto.UnidadeMedida ?? "";
            cmbTipoProduto.Text = produto.TipoProduto ?? "";

            // Estoque
            numQuantidadeAtual.Value = produto.QuantidadeAtual;
            numEstoqueMinimo.Value = produto.EstoqueMinimo;
            numEstoqueMaximo.Value = produto.EstoqueMaximo;
            txtLocalizacaoEstoque.Text = produto.LocalizacaoEstoque ?? "";
            chkPermiteEstoqueNegativo.Checked = produto.PermiteEstoqueNegativo;

            // Preços
            numPrecoCusto.Value = produto.PrecoCusto;
            numPrecoVenda.Value = produto.PrecoVenda;
            numMargemLucro.Value = produto.MargemLucro;
            chkPromocaoAtiva.Checked = produto.PromocaoAtiva;
            numPrecoPromocional.Value = produto.PrecoPromocional ?? 0;
            if (produto.InicioPromocao.HasValue)
                dtpInicioPromocao.Value = produto.InicioPromocao.Value;
            if (produto.FimPromocao.HasValue)
                dtpFimPromocao.Value = produto.FimPromocao.Value;

            // Tributação
            cmbOrigemProduto.Text = produto.OrigemProduto ?? "";
            txtNCM.Text = produto.NCM ?? "";
            txtCFOP.Text = produto.CFOP ?? "";
            txtCSTCSOSN.Text = produto.CSTCSOSN ?? "";
            numICMS.Value = produto.AliquotaICMS;
            numPIS.Value = produto.AliquotaPIS;
            numCOFINS.Value = produto.AliquotaCOFINS;
            numIPI.Value = produto.AliquotaIPI;

            // Imagem
            pictureBoxProduto.Image = ImagemUtils.BytesParaImagem(produto.Imagem);

            // Complementares
            chkAtivo.Checked = produto.Ativo;
            txtObservacoes.Text = produto.Observacoes ?? "";
            txtSKU.Text = produto.SKU ?? "";

            AtualizarLabelsData();
        }

        private void LimparCampos()
        {
            foreach (Control c in this.Controls)
                LimparCamposRecursivo(c);
        }

        private void LimparCamposRecursivo(Control control)
        {
            if (control is TextBox) control.Text = "";
            else if (control is ComboBox cb) cb.SelectedIndex = 0;
            else if (control is NumericUpDown nud) nud.Value = 0;
            else if (control is CheckBox chk) chk.Checked = false;
            else if (control is PictureBox pb) pb.Image = null;
            else if (control is DateTimePicker dtp) dtp.Value = DateTime.Now;
            else
                foreach (Control child in control.Controls)
                    LimparCamposRecursivo(child);
        }

        private void AtualizarLabelsData()
        {
            if (produtoAtual != null && produtoAtual.ID > 0)
            {
                lblDataCadastro.Text = $"Data Cadastro: {produtoAtual.DataCadastro:dd/MM/yyyy}";
                lblUltimaAlteracao.Text = $"Última Alteração: {produtoAtual.UltimaAlteracao:dd/MM/yyyy HH:mm}";
            }
            else
            {
                lblDataCadastro.Text = "Data Cadastro: -";
                lblUltimaAlteracao.Text = "Última Alteração: -";
            }
        }

      
        #endregion

        #region Métodos Públicos para Integração

        public async void CarregarProduto(int produtoId)
        {
            try
            {
                var produto = await produtoDAL.ObterProdutoPorId(produtoId);
                if (produto != null)
                {
                    produtoAtual = produto;
                    PreencherCampos(produto);
                    modoEdicao = false;
                    btnEditar.Enabled = true;
                }
                else
                {
                    Mensagens.Aviso("Produto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Mensagens.Erro("Erro ao carregar produto", ex.Message);
            }
        }

        public async void CarregarProdutoPorCodigo(string codigo)
        {
            try
            {
                var produto = await produtoDAL.ObterProdutoPorCodigo(codigo);
                if (produto != null)
                {
                    produtoAtual = produto;
                    PreencherCampos(produto);
                    modoEdicao = false;
                    btnEditar.Enabled = true;
                }
                else
                {
                    Mensagens.Aviso("Produto não encontrado.");
                }
            }
            catch (Exception ex)
            {
                Mensagens.Erro("Erro ao carregar produto", ex.Message);
            }
        }

        #endregion

        private void btStock_Click(object sender, EventArgs e)
        {
            // Verifica se há alterações pendentes antes de abrir o formulário de edição
            FormManager.ShowForm<frmEdicaoP>();
        }
    }

    // Utilitário para mensagens
    public static class Mensagens
    {
        public static void Erro(string titulo, string mensagem) =>
            MessageBox.Show($"{titulo}: {mensagem}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static void Aviso(string mensagem) =>
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Aviso(string titulo, string mensagem) =>
            MessageBox.Show($"{titulo}: {mensagem}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Sucesso(string mensagem) =>
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

        public static void Validacao(List<string> erros) =>
            MessageBox.Show(string.Join(Environment.NewLine, erros), "Validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        public static bool Confirmacao(string mensagem) =>
            MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
    }

    // Utilitário para imagens
    public static class ImagemUtils
    {
        private static readonly HashSet<string> ExtensoesValidas = new HashSet<string> { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

        public static bool IsImageFile(string fileName)
        {
            string extension = Path.GetExtension(fileName).ToLower();
            return ExtensoesValidas.Contains(extension);
        }

        public static void PictureBoxProduto_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                    e.Effect = DragDropEffects.Copy;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        public static string ObterArquivoArrastado(DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                    return files[0];
            }
            return null;
        }

        public static Image RedimensionarImagem(Image imagemOriginal, int larguraMaxima, int alturaMaxima)
        {
            var proporcao = Math.Min((double)larguraMaxima / imagemOriginal.Width,
                                   (double)alturaMaxima / imagemOriginal.Height);

            var novaLargura = (int)(imagemOriginal.Width * proporcao);
            var novaAltura = (int)(imagemOriginal.Height * proporcao);

            var imagemRedimensionada = new Bitmap(novaLargura, novaAltura);

            using (var graphics = Graphics.FromImage(imagemRedimensionada))
            {
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                graphics.DrawImage(imagemOriginal, 0, 0, novaLargura, novaAltura);
            }
            return imagemRedimensionada;
        }

        public static byte[] ImagemParaBytes(Image imagem)
        {
            using (var ms = new MemoryStream())
            {
                imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        public static Image BytesParaImagem(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;
            using (var ms = new MemoryStream(bytes))
                return Image.FromStream(ms);
        }
    }
}
