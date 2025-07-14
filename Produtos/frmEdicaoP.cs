using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Acessos
{
    public partial class frmEdicaoP : Form
    {
        private ProdutoDAL produtoDAL;
        private Fornecedor fornecedorDAL;
        private IProdutos produtoAtual;
        private List<IProdutos> listaProdutos;
        private bool modoEdicao = false;
        private bool calculandoMargem = false;

        public frmEdicaoP()
        {
            InitializeComponent();
            produtoDAL = new ProdutoDAL();
            fornecedorDAL = new Fornecedor();
            produtoAtual = new Produto();
            listaProdutos = new List<IProdutos>();
        }

        private void frmEdicaoP_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                _ = CarregarFornecedores();
                _ = CarregarProdutos();
                DefinirEstadoInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o formulário: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
           // dtpValidade.Value = DateTime.Now;
            pictureBoxProduto.AllowDrop = true;
            pictureBoxProduto.DragEnter += PictureBoxProduto_DragEnter;
            pictureBoxProduto.DragDrop += PictureBoxProduto_DragDrop;
            ConfigurarGrid();
        }

        private void ConfigurarGrid()
        {
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.Columns.Clear();

            dgvProdutos.Columns.Add("ID", "ID");
            dgvProdutos.Columns["ID"].Width = 50;    
            //dgvProdutos.Columns["ID"].Visible = false; // Oculta a coluna ID
            dgvProdutos.Columns["ID"].DataPropertyName = "ID";

            dgvProdutos.Columns.Add("CodigoProduto", "Código");
            dgvProdutos.Columns["CodigoProduto"].Width = 80;
            dgvProdutos.Columns["CodigoProduto"].DataPropertyName = "CodigoProduto";

            dgvProdutos.Columns.Add("Nome", "Nome do Produto");
            dgvProdutos.Columns["Nome"].Width = 200;
            dgvProdutos.Columns["Nome"].DataPropertyName = "Nome";

            dgvProdutos.Columns.Add("Categoria", "Categoria");
            dgvProdutos.Columns["Categoria"].Width = 100;
            dgvProdutos.Columns["Categoria"].DataPropertyName = "Categoria";

            dgvProdutos.Columns.Add("PrecoVenda", "Preço Venda");
            dgvProdutos.Columns["PrecoVenda"].Width = 80;
            dgvProdutos.Columns["PrecoVenda"].DataPropertyName = "PrecoVenda";
            dgvProdutos.Columns["PrecoVenda"].DefaultCellStyle.Format = "C2";

            dgvProdutos.Columns.Add("QuantidadeAtual", "Estoque");
            dgvProdutos.Columns["QuantidadeAtual"].Width = 70;
            dgvProdutos.Columns["QuantidadeAtual"].DataPropertyName = "QuantidadeAtual";

            dgvProdutos.Columns.Add("Ativo", "Ativo");
            dgvProdutos.Columns["Ativo"].Width = 50;
            dgvProdutos.Columns["Ativo"].DataPropertyName = "Ativo";
        }

        private async Task CarregarFornecedores()
        {
            try
            {
                var fornecedores = await fornecedorDAL.ObterTodosFornecedoresAsync();
                cmbFornecedor.DataSource = fornecedores;
                cmbFornecedor.DisplayMember = "RazaoSocial";
                cmbFornecedor.ValueMember = "ID";
                cmbFornecedor.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar fornecedores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task CarregarProdutos(string filtro = "")
        {
            try
            {
                if (string.IsNullOrWhiteSpace(filtro))
                {
                    listaProdutos = await produtoDAL.ObterTodosProdutos();
                }
                else
                {
                    listaProdutos = await produtoDAL.BuscarProdutos(filtro);
                }

                dgvProdutos.DataSource = listaProdutos;

                if (dgvProdutos.Rows.Count > 0)
                {
                    dgvProdutos.CurrentCell = dgvProdutos.Rows[0].Cells[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DefinirEstadoInicial()
        {
            modoEdicao = false;
            HabilitarCampos(false);

            btnAtualizar.Enabled = false;
            btnNovo.Enabled = true;
            btnLimpar.Enabled = true;
            btnExcluir.Enabled = false;
            btnEditar.Enabled = false;
            btnFechar.Enabled = true;
        }

        #endregion

        #region Eventos do Grid e Busca

        private void dgvProdutos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProdutos.CurrentRow != null && dgvProdutos.CurrentRow.DataBoundItem != null && !modoEdicao)
            {
                var produto = (IProdutos)dgvProdutos.CurrentRow.DataBoundItem;
                _ = CarregarProdutoSelecionado(produto);
            }
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvProdutos.Rows[e.RowIndex].DataBoundItem != null)
            {
                var produto = (IProdutos)dgvProdutos.Rows[e.RowIndex].DataBoundItem;
                _ = CarregarProdutoSelecionado(produto);

                if (!modoEdicao)
                {
                    btnEditar_Click(sender, e);
                }
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (txtBusca.Text.Length >= 3 || string.IsNullOrWhiteSpace(txtBusca.Text))
            {
                _ = CarregarProdutos(txtBusca.Text);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            _ = CarregarProdutos(txtBusca.Text);
        }

        private async Task CarregarProdutoSelecionado(IProdutos produto)
        {
            try
            {
                if (produto != null && produto.ID > 0)
                {
                    produtoAtual = await produtoDAL.ObterProdutoPorId(produto.ID);
                    if (produtoAtual != null)
                    {
                        PreencherCampos(produtoAtual);
                        btnEditar.Enabled = true;
                        btnExcluir.Enabled = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produto: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region Eventos dos Botões

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                PreencherObjetoProduto();

                if (await produtoDAL.AtualizarProduto(produtoAtual))
                {
                    MessageBox.Show("Produto atualizado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    modoEdicao = false;
                    HabilitarCampos(false);

                    btnAtualizar.Enabled = false;
                    btnEditar.Enabled = true;
                    btnExcluir.Enabled = true;

                    await CarregarProdutos(txtBusca.Text);
                    SelecionarProdutoNoGrid(produtoAtual.ID);
                    AtualizarLabelsData();
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar produto. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarAlteracoesPendentes())
                {
                    var resultado = MessageBox.Show("Existem alterações não salvas. Deseja continuar?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                        return;
                }

                using (var frmCadastro = new frmProdutos())
                {
                    if (frmCadastro.ShowDialog() == DialogResult.OK)
                    {
                     await  CarregarProdutos(txtBusca.Text);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir cadastro: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modoEdicao)
                {
                    var resultado = MessageBox.Show("Deseja cancelar a edição e limpar os campos?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        modoEdicao = false;
                        HabilitarCampos(false);
                        btnAtualizar.Enabled = false;
                        btnEditar.Enabled = false;
                        btnExcluir.Enabled = false;
                    }
                    else
                    {
                        return;
                    }
                }

                LimparCampos();
                produtoAtual = new Produto();
                dgvProdutos.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao limpar campos: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (produtoAtual == null || produtoAtual.ID == 0)
                {
                    MessageBox.Show("Nenhum produto selecionado para exclusão.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var resultado = MessageBox.Show(
                    $"Deseja realmente excluir o produto '{produtoAtual.Nome}'?\n\nEsta ação não poderá ser desfeita.",
                    "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    if (await produtoDAL.ExcluirProduto(produtoAtual.ID))
                    {
                        MessageBox.Show("Produto excluído com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LimparCampos();
                        produtoAtual = new Produto();
                        modoEdicao = false;

                        btnAtualizar.Enabled = false;
                        btnEditar.Enabled = false;
                        btnExcluir.Enabled = false;

                        await CarregarProdutos(txtBusca.Text);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir produto. Tente novamente.",
                            "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao excluir: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (produtoAtual == null || produtoAtual.ID == 0)
                {
                    MessageBox.Show("Selecione um produto para editar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                modoEdicao = true;
                HabilitarCampos(true);

                btnAtualizar.Enabled = true;
                btnEditar.Enabled = false;
                btnExcluir.Enabled = false;

                txtNome.Focus();

                MessageBox.Show("Modo de edição ativado. Faça as alterações e clique em Atualizar.",
                    "Modo Edição", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao ativar edição: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            try
            {
                if (VerificarAlteracoesPendentes())
                {
                    var resultado = MessageBox.Show("Existem alterações não salvas. Deseja sair mesmo assim?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                        return;
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao fechar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btImportar_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmImportacaoProdutos>();
        }

        #endregion

        #region Eventos de Cálculo de Preços

        private void numPrecoCusto_ValueChanged(object sender, EventArgs e)
        {
            if (!calculandoMargem && modoEdicao)
                CalcularPrecoVenda();
        }

        private void numPrecoVenda_ValueChanged(object sender, EventArgs e)
        {
            if (!calculandoMargem && modoEdicao)
                CalcularMargemLucro();
        }

        private void numMargemLucro_ValueChanged(object sender, EventArgs e)
        {
            if (!calculandoMargem && modoEdicao)
                CalcularPrecoVenda();
        }

        private void CalcularPrecoVenda()
        {
            try
            {
                calculandoMargem = true;

                if (numPrecoCusto.Value > 0 && numMargemLucro.Value > 0)
                {
                    var precoVenda = numPrecoCusto.Value * (1 + (numMargemLucro.Value / 100));
                    numPrecoVenda.Value = Math.Round(precoVenda, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no cálculo: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                calculandoMargem = false;
            }
        }

        private void CalcularMargemLucro()
        {
            try
            {
                calculandoMargem = true;

                if (numPrecoCusto.Value > 0 && numPrecoVenda.Value > 0)
                {
                    var margem = ((numPrecoVenda.Value - numPrecoCusto.Value) / numPrecoCusto.Value) * 100;
                    numMargemLucro.Value = Math.Round(margem, 2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro no cálculo: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                calculandoMargem = false;
            }
        }

        #endregion

        #region Eventos de Promoção

        private void chkPromocaoAtiva_CheckedChanged(object sender, EventArgs e)
        {
            bool promocaoAtiva = chkPromocaoAtiva.Checked;

            numPrecoPromocional.Enabled = promocaoAtiva && modoEdicao;
            dtpInicioPromocao.Enabled = promocaoAtiva && modoEdicao;
            dtpFimPromocao.Enabled = promocaoAtiva && modoEdicao;

            if (!promocaoAtiva)
            {
                numPrecoPromocional.Value = 0;
            }
        }

        #endregion

        #region Eventos de Imagem

        private void btnCarregarImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modoEdicao)
                {
                    MessageBox.Show("Ative o modo de edição primeiro.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Arquivos de Imagem|*.jpg;*.jpeg;*.png;*.bmp;*.gif|Todos os Arquivos|*.*";
                    openFileDialog.Title = "Selecionar Imagem do Produto";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        CarregarImagemDoArquivo(openFileDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!modoEdicao)
                {
                    MessageBox.Show("Ative o modo de edição primeiro.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                pictureBoxProduto.Image = null;
                produtoAtual.Imagem = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao remover imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBoxProduto_DragEnter(object sender, DragEventArgs e)
        {
            if (modoEdicao && e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void PictureBoxProduto_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                if (!modoEdicao)
                    return;

                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files.Length > 0 && IsImageFile(files[0]))
                {
                    CarregarImagemDoArquivo(files[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsImageFile(string fileName)
        {
            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };
            string extension = Path.GetExtension(fileName).ToLower();
            return Array.Exists(validExtensions, ext => ext == extension);
        }

        private void CarregarImagemDoArquivo(string caminhoArquivo)
        {
            try
            {
                using (var image = Image.FromFile(caminhoArquivo))
                {
                    var imagemRedimensionada = RedimensionarImagem(image, 300, 300);
                    pictureBoxProduto.Image = imagemRedimensionada;
                    produtoAtual.Imagem = ImagemParaBytes(imagemRedimensionada);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao processar imagem: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Image RedimensionarImagem(Image imagemOriginal, int larguraMaxima, int alturaMaxima)
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

        private byte[] ImagemParaBytes(Image imagem)
        {
            using (var ms = new MemoryStream())
            {
                imagem.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

        private Image BytesParaImagem(byte[] bytes)
        {
            if (bytes == null || bytes.Length == 0)
                return null;

            using (var ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }
        }

        #endregion

        #region Métodos de Validação e Manipulação

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (cmbFornecedor.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um fornecedor.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbFornecedor.Focus();
                return false;
            }

            if (cmbUnidadeMedida.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma unidade de medida.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbUnidadeMedida.Focus();
                return false;
            }

            if (numMargemLucro.Value <= 0)
            {
                MessageBox.Show("A margem de lucro é obrigatória e deve ser maior que zero.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                numMargemLucro.Focus();
                return false;
            }

            if (chkPromocaoAtiva.Checked)
            {
                if (numPrecoPromocional.Value <= 0)
                {
                    MessageBox.Show("Informe o preço promocional.",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    numPrecoPromocional.Focus();
                    return false;
                }

                if (dtpFimPromocao.Value <= dtpInicioPromocao.Value)
                {
                    MessageBox.Show("A data fim da promoção deve ser posterior à data de início.",
                        "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFimPromocao.Focus();
                    return false;
                }
            }

            return true;
        }

        private void PreencherObjetoProduto()
        {
            produtoAtual.CodigoProduto = txtCodigoProduto.Text.Trim();
            produtoAtual.CodigoBarras = txtCodigoBarras.Text.Trim();
            produtoAtual.Nome = txtNome.Text.Trim();
            produtoAtual.Descricao = txtDescricao.Text.Trim();

            // Novos campos da interface
           // produtoAtual.Peso = numPeso.Value;
          //  produtoAtual.Volume = numVolume.Value;
          //  produtoAtual.DataValidade = dtpValidade.Value;
           // produtoAtual.Lote = txtLote.Text.Trim();

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

            // Novos campos da interface
           // numPeso.Value = produto.Peso;
           // numVolume.Value = produto.Volume;
           // dtpValidade.Value = produto.DataValidade != DateTime.MinValue ? produto.DataValidade : DateTime.Now;
           // txtLote.Text = produto.Lote ?? "";

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
            if (produto.Imagem != null && produto.Imagem.Length > 0)
            {
                pictureBoxProduto.Image = BytesParaImagem(produto.Imagem);
            }
            else
            {
                pictureBoxProduto.Image = null;
            }

            // Complementares
            chkAtivo.Checked = produto.Ativo;
            txtObservacoes.Text = produto.Observacoes ?? "";
            txtSKU.Text = produto.SKU ?? "";

            AtualizarLabelsData();
        }

        private void LimparCampos()
        {
            txtCodigoProduto.Text = "";
            txtCodigoBarras.Text = "";
            txtNome.Text = "";
            txtDescricao.Text = "";
          //  numPeso.Value = 0;
          //  numVolume.Value = 0;
          //  dtpValidade.Value = DateTime.Now;
          //  txtLote.Text = "";
            txtCategoria.Text = "";
            txtSubcategoria.Text = "";
            txtMarca.Text = "";
            cmbFornecedor.SelectedIndex = -1;
            cmbUnidadeMedida.SelectedIndex = 0;
            cmbTipoProduto.SelectedIndex = 0;
            numQuantidadeAtual.Value = 0;
            numEstoqueMinimo.Value = 0;
            numEstoqueMaximo.Value = 0;
            txtLocalizacaoEstoque.Text = "";
            chkPermiteEstoqueNegativo.Checked = false;
            numPrecoCusto.Value = 0;
            numPrecoVenda.Value = 0;
            numMargemLucro.Value = 0;
            chkPromocaoAtiva.Checked = false;
            numPrecoPromocional.Value = 0;
            dtpInicioPromocao.Value = DateTime.Now;
            dtpFimPromocao.Value = DateTime.Now.AddDays(30);
            cmbOrigemProduto.SelectedIndex = 0;
            txtNCM.Text = "";
            txtCFOP.Text = "";
            txtCSTCSOSN.Text = "";
            numICMS.Value = 0;
            numPIS.Value = 0;
            numCOFINS.Value = 0;
            numIPI.Value = 0;
            pictureBoxProduto.Image = null;
            chkAtivo.Checked = true;
            txtObservacoes.Text = "";
            txtSKU.Text = "";
            AtualizarLabelsData();
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

        private void HabilitarCampos(bool habilitar)
        {
            txtCodigoBarras.Enabled = habilitar;
            txtNome.Enabled = habilitar;
            txtDescricao.Enabled = habilitar;
          //  numPeso.Enabled = habilitar;
           // numVolume.Enabled = habilitar;
          //  dtpValidade.Enabled = habilitar;
          //  txtLote.Enabled = habilitar;
            txtCategoria.Enabled = habilitar;
            txtSubcategoria.Enabled = habilitar;
            txtMarca.Enabled = habilitar;
            cmbFornecedor.Enabled = habilitar;
            cmbUnidadeMedida.Enabled = habilitar;
            cmbTipoProduto.Enabled = habilitar;
            numQuantidadeAtual.Enabled = habilitar;
            numEstoqueMinimo.Enabled = habilitar;
            numEstoqueMaximo.Enabled = habilitar;
            txtLocalizacaoEstoque.Enabled = habilitar;
            chkPermiteEstoqueNegativo.Enabled = habilitar;
            numPrecoCusto.Enabled = habilitar;
            numPrecoVenda.Enabled = habilitar;
            numMargemLucro.Enabled = habilitar;
            chkPromocaoAtiva.Enabled = habilitar;
            bool promocaoHabilitada = habilitar && chkPromocaoAtiva.Checked;
            numPrecoPromocional.Enabled = promocaoHabilitada;
            dtpInicioPromocao.Enabled = promocaoHabilitada;
            dtpFimPromocao.Enabled = promocaoHabilitada;
            cmbOrigemProduto.Enabled = habilitar;
            txtNCM.Enabled = habilitar;
            txtCFOP.Enabled = habilitar;
            txtCSTCSOSN.Enabled = habilitar;
            numICMS.Enabled = habilitar;
            numPIS.Enabled = habilitar;
            numCOFINS.Enabled = habilitar;
            numIPI.Enabled = habilitar;
            btnCarregarImagem.Enabled = habilitar;
            btnRemoverImagem.Enabled = habilitar;
            chkAtivo.Enabled = habilitar;
            txtObservacoes.Enabled = habilitar;
            txtSKU.Enabled = habilitar;
        }

        private bool VerificarAlteracoesPendentes()
        {
            return modoEdicao;
        }

        private void SelecionarProdutoNoGrid(int produtoId)
        {
            foreach (DataGridViewRow row in dgvProdutos.Rows)
            {
                if (row.DataBoundItem is IProdutos produto && produto.ID == produtoId)
                {
                    dgvProdutos.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        #endregion

       
    }
}
