using Acessos.Utils;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Acessos
{
    public partial class frmFornecedores : Form
    {
        #region Campos Privados
        private Timer validationTimer = new Timer();
        private Fornecedor fornecedorAtual;
        private bool modoCriacao;
        private Fornecedor fornecedor; // Instância da classe de acesso a dados
        private bool carregandoDados = false;
        #endregion

        #region Construtor
        public frmFornecedores()
        {
            InitializeComponent();
            InicializarComponentes();
        }

        private void InicializarComponentes()
        {
            fornecedor = new Fornecedor();

            // Configurar timer de validação
            validationTimer.Interval = 1500; // Reduzido para melhor UX
            validationTimer.Tick += ValidationTimer_Tick;

            // Configurar máscaras dos campos
            ConfigurarMascaras();
        }

        private void ConfigurarMascaras()
        {
            // Configurar máscara do telefone
            if (txtTelefone is MaskedTextBox)
            {
                ((MaskedTextBox)txtTelefone).Mask = "(00) 00000-0000";
            }

            // Configurar máscara do CEP
            if (txtCEP is MaskedTextBox)
            {
                ((MaskedTextBox)txtCEP).Mask = "00000-000";
            }
        }
        #endregion

        #region Eventos do Formulário
        private async void frmFornecedores_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                await CarregarFornecedoresAsync();
                InicializarEstadoFormulario();
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao carregar o formulário: {ex.Message}");
            }
        }

        private void InicializarEstadoFormulario()
        {
            HabilitarCampos(false);
            LimparCampos();
            AtualizarBotoes();
        }
        #endregion

        #region Configuração do Formulário
        private void ConfigurarFormulario()
        {
            ConfigurarDateTimePicker();
            ConfigurarComboBoxes();
            ConfigurarGrid();
            ConfigurarEventos();
        }

        private void ConfigurarDateTimePicker()
        {
            if (dtpDataFundacao != null)
            {
                dtpDataFundacao.Format = DateTimePickerFormat.Short;
                dtpDataFundacao.ShowCheckBox = true;
                dtpDataFundacao.Checked = false;
                dtpDataFundacao.MaxDate = DateTime.Now; // Não permite datas futuras
            }
        }

        private void ConfigurarComboBoxes()
        {
            // Configurar ComboBox Tipo Fornecedor
            if (cmbTipoFornecedor.Items.Count == 0)
            {
                cmbTipoFornecedor.Items.AddRange(new string[]
                {
                    "Selecione...",
                    "Produtos",
                    "Serviços",
                    "Produtos e Serviços",
                    "Matéria Prima",
                    "Equipamentos",
                    "Outros"
                });
            }
            cmbTipoFornecedor.SelectedIndex = 0;

            // Configurar ComboBox Status
            if (cmbStatus.Items.Count == 0)
            {
                cmbStatus.Items.AddRange(new string[]
                {
                    "Ativo",
                    "Inativo",
                    "Bloqueado",
                    "Pendente"
                });
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void ConfigurarGrid()
        {
            if (GridFornecedores != null)
            {
                GridFornecedores.AutoGenerateColumns = false;
                GridFornecedores.AllowUserToAddRows = false;
                GridFornecedores.AllowUserToDeleteRows = false;
                GridFornecedores.ReadOnly = true;
                GridFornecedores.MultiSelect = false;
                GridFornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                GridFornecedores.RowHeadersVisible = false;
                GridFornecedores.BackgroundColor = Color.White;
                GridFornecedores.BorderStyle = BorderStyle.Fixed3D;

                ConfigurarColunas();
            }
        }

        private void ConfigurarColunas()
        {
            GridFornecedores.Columns.Clear();

            // Coluna ID (oculta)
            var colID = new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "ID",
                Visible = false
            };
            GridFornecedores.Columns.Add(colID);

            // Coluna Razão Social
            var colRazaoSocial = new DataGridViewTextBoxColumn
            {
                Name = "RazaoSocial",
                HeaderText = "Razão Social",
                DataPropertyName = "RazaoSocial",
                Width = 200,
                MinimumWidth = 150
            };
            GridFornecedores.Columns.Add(colRazaoSocial);

            // Coluna Nome Fantasia
            var colNomeFantasia = new DataGridViewTextBoxColumn
            {
                Name = "NomeFantasia",
                HeaderText = "Nome Fantasia",
                DataPropertyName = "NomeFantasia",
                Width = 180,
                MinimumWidth = 120
            };
            GridFornecedores.Columns.Add(colNomeFantasia);

            // Coluna CNPJ
            var colCNPJ = new DataGridViewTextBoxColumn
            {
                Name = "CNPJ",
                HeaderText = "CNPJ",
                DataPropertyName = "CNPJFormatado", // Propriedade que retorna CNPJ formatado
                Width = 140,
                MinimumWidth = 120
            };
            GridFornecedores.Columns.Add(colCNPJ);

            // Coluna Telefone
            var colTelefone = new DataGridViewTextBoxColumn
            {
                Name = "Telefone",
                HeaderText = "Telefone",
                DataPropertyName = "TelefoneFormatado", // Propriedade que retorna telefone formatado
                Width = 130,
                MinimumWidth = 100
            };
            GridFornecedores.Columns.Add(colTelefone);

            // Coluna Status
            var colStatus = new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "Status",
                DataPropertyName = "Status",
                Width = 80,
                MinimumWidth = 60
            };
            GridFornecedores.Columns.Add(colStatus);
        }

        private void ConfigurarEventos()
        {
            // Eventos de validação em tempo real
            txtEmail.Leave += TxtEmail_Leave;
            txtTelefone.Leave += TxtTelefone_Leave;
            txtCEP.Leave += TxtCEP_Leave;

            // Eventos para limpar cores de validação
            txtCNPJ.Enter += (s, e) => ResetarCorCampo(txtCNPJ);
            txtEmail.Enter += (s, e) => ResetarCorCampo(txtEmail);
            txtTelefone.Enter += (s, e) => ResetarCorCampo(txtTelefone);
            txtCEP.Enter += (s, e) => ResetarCorCampo(txtCEP);
        }
        #endregion

        #region Eventos do Grid
        private void GridFornecedores_SelectionChanged(object sender, EventArgs e)
        {
            if (carregandoDados || GridFornecedores.SelectedRows.Count == 0)
                return;

            var fornecedor = GridFornecedores.SelectedRows[0].DataBoundItem as Fornecedor;
            if (fornecedor != null)
            {
                fornecedorAtual = fornecedor;
                PreencherCampos(fornecedor);
                AtualizarLabelsData(fornecedor);
                HabilitarCampos(false);
                AtualizarBotoes();
            }
        }

        private void GridFornecedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && GridFornecedores.Rows[e.RowIndex].DataBoundItem is Fornecedor fornecedor)
            {
                IniciarEdicao(fornecedor);
            }
        }

        private void IniciarEdicao(Fornecedor fornecedor)
        {
            fornecedorAtual = fornecedor;
            PreencherCampos(fornecedor);
            HabilitarCampos(true);
            modoCriacao = false;
            AtualizarBotoes();
            txtRazaoSocial.Focus();
        }
        #endregion

        #region Eventos dos Botões
        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (!ConfirmarAcaoSeNecessario())
                return;

            IniciarNovoCadastro();
        }

        private void IniciarNovoCadastro()
        {
            LimparCampos();
            HabilitarCampos(true);
            modoCriacao = true;
            fornecedorAtual = new Fornecedor();
            AtualizarBotoes();
            txtRazaoSocial.Focus();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecaoFornecedor())
                return;

            IniciarEdicao(fornecedorAtual);
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            await SalvarFornecedorAsync();
        }

        private async Task SalvarFornecedorAsync()
        {
            try
            {
                PreencherObjetoFornecedor();

                if (modoCriacao)
                {
                    await ProcessarNovoCadastro();
                }
                else
                {
                    await ProcessarAtualizacao();
                }

                await CarregarFornecedoresAsync();
                FinalizarOperacao();
                ExibirSucesso(modoCriacao ? "Fornecedor cadastrado com sucesso!" : "Fornecedor atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao salvar fornecedor: {ex.Message}");
            }
        }

        private async Task ProcessarNovoCadastro()
        {
            if (await fornecedor.FornecedorExistePorCNPJAsync(fornecedorAtual.CNPJ))
            {
                ExibirAviso("Já existe um fornecedor com este CNPJ.");
                txtCNPJ.Focus();
                return;
            }

            await fornecedor.InserirFornecedorAsync(fornecedorAtual);
        }

        private async Task ProcessarAtualizacao()
        {
            // Verificar se CNPJ não está sendo usado por outro fornecedor
            if (await fornecedor.CNPJExisteParaOutroFornecedorAsync(fornecedorAtual.CNPJ, fornecedorAtual.ID))
            {
                ExibirAviso("Este CNPJ já está sendo usado por outro fornecedor.");
                txtCNPJ.Focus();
                return;
            }

            await fornecedor.AtualizarFornecedorAsync(fornecedorAtual);
        }

        private void FinalizarOperacao()
        {
            LimparCampos();
            HabilitarCampos(false);
            AtualizarBotoes();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (ConfirmarCancelamento())
            {
                CancelarOperacao();
            }
        }

        private void CancelarOperacao()
        {
            if (fornecedorAtual != null && fornecedorAtual.ID > 0)
            {
                PreencherCampos(fornecedorAtual);
            }
            else
            {
                LimparCampos();
            }

            HabilitarCampos(false);
            AtualizarBotoes();
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            await CarregarFornecedoresAsync();
            ExibirSucesso("Lista de fornecedores atualizada!");
        }

        private async void btnInativar_Click(object sender, EventArgs e)
        {
            if (!ValidarSelecaoFornecedor())
                return;

            if (ConfirmarInativacao())
            {
                await InativarFornecedorAsync();
            }
        }

        private async Task InativarFornecedorAsync()
        {
            try
            {
                await fornecedor.InativarFornecedorAsync(fornecedorAtual.ID);
                ExibirSucesso("Fornecedor inativado com sucesso!");
                await CarregarFornecedoresAsync();
                LimparCampos();
                HabilitarCampos(false);
                AtualizarBotoes();
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao inativar fornecedor: {ex.Message}");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (ConfirmarSaida())
            {
                this.Close();
            }
        }
        #endregion

        #region Eventos de Validação
        private void txtCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCNPJ_TextChanged(object sender, EventArgs e)
        {
            if (txtCNPJ is MaskedTextBox maskedTextBox)
            {
                maskedTextBox.Mask = "00.000.000/0000-00";
            }
        }

        private void txtCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            validationTimer.Stop();
            validationTimer.Start();
        }

        private void ValidationTimer_Tick(object sender, EventArgs e)
        {
            validationTimer.Stop();
            ValidarCNPJEmTempoReal();
        }

        private void ValidarCNPJEmTempoReal()
        {
            string digits = new string(txtCNPJ.Text.Where(char.IsDigit).ToArray());

            if (digits.Length == 14)
            {
                if (Validador.ValidarCNPJ(digits))
                {
                    DefinirCorValidacao(txtCNPJ, true);
                }
                else
                {
                    DefinirCorValidacao(txtCNPJ, false);
                    ExibirAviso("CNPJ inválido!");
                }
            }
            else if (digits.Length > 0)
            {
                ResetarCorCampo(txtCNPJ);
            }
        }

        private void TxtEmail_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                bool emailValido = ValidarEmail(txtEmail.Text);
                DefinirCorValidacao(txtEmail, emailValido);

                if (!emailValido)
                {
                    ExibirAviso("Email inválido!");
                }
            }
        }

        private void TxtTelefone_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                string telefone = new string(txtTelefone.Text.Where(char.IsDigit).ToArray());
                bool telefoneValido = telefone.Length >= 10;
                DefinirCorValidacao(txtTelefone, telefoneValido);

                if (!telefoneValido)
                {
                    ExibirAviso("Telefone deve ter pelo menos 10 dígitos!");
                }
            }
        }

        private void TxtCEP_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtCEP.Text))
            {
                string cep = new string(txtCEP.Text.Where(char.IsDigit).ToArray());
                bool cepValido = cep.Length == 8;
                DefinirCorValidacao(txtCEP, cepValido);

                if (!cepValido)
                {
                    ExibirAviso("CEP deve ter 8 dígitos!");
                }
            }
        }
        #endregion

        #region Eventos de CEP
        private async void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            await BuscarCEPAsync();
        }

        private async Task BuscarCEPAsync()
        {
            try
            {
                string cepValue = txtCEP.Text?.Replace("_", "").Replace("-", "") ?? "";

                if (!ValidarCEPParaBusca(cepValue))
                    return;

                await ExecutarBuscaCEP(cepValue);
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao buscar CEP: {ex.Message}");
            }
            finally
            {
                RestaurarBotaoBuscarCEP();
            }
        }

        private bool ValidarCEPParaBusca(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
            {
                ExibirAviso("Por favor, informe um CEP válido com 8 dígitos.");
                txtCEP.Focus();
                return false;
            }
            return true;
        }

        private async Task ExecutarBuscaCEP(string cep)
        {
            ConfigurarBotaoBuscandoCEP();

            CEP cepUtil = new CEP();
            var enderecoInfo = await cepUtil.BuscarEnderecoPorCEP(cep);

            if (enderecoInfo != null)
            {
                PreencherEndereco(enderecoInfo);
                ExibirSucesso("Endereço encontrado e preenchido automaticamente!");
            }
            else
            {
                ExibirAviso("CEP não encontrado. Verifique o número informado.");
            }
        }

        private void ConfigurarBotaoBuscandoCEP()
        {
            btnBuscarCEP.Enabled = false;
            btnBuscarCEP.Text = "Buscando...";
        }

        private void RestaurarBotaoBuscarCEP()
        {
            btnBuscarCEP.Enabled = true;
            btnBuscarCEP.Text = "Buscar";
        }

        private void PreencherEndereco(EnderecoInfo enderecoInfo)
        {
            if (enderecoInfo == null)
                return;

            txtLogradouro.Text = enderecoInfo.Logradouro ?? "";
            txtBairro.Text = enderecoInfo.Bairro ?? "";
            txtLocalidade.Text = enderecoInfo.Localidade ?? "";
            txtUF.Text = enderecoInfo.UF ?? "";
            txtEstado.Text = enderecoInfo.Estado ?? "";
            txtRegiao.Text = enderecoInfo.Regiao ?? "";
            txtIBGE.Text = enderecoInfo.IBGE ?? "";

            // Manter o complemento se já estava preenchido
            if (string.IsNullOrWhiteSpace(txtComplemento.Text))
            {
                txtComplemento.Text = enderecoInfo.Complemento ?? "";
            }
        }
        #endregion

        #region Métodos de Negócio
        private async Task<List<Fornecedor>> ObterFornecedoresFiltradosAsync(string filtro = "")
        {
            if (string.IsNullOrWhiteSpace(filtro))
            {
                return await fornecedor.ObterTodosFornecedoresAsync();
            }

            return await fornecedor.BuscarFornecedoresAsync(filtro);
        }

        private void AplicarFiltroGrid(string filtro)
        {
            if (GridFornecedores.DataSource is List<Fornecedor> fornecedores)
            {
                var fornecedoresFiltrados = fornecedores.Where(f =>
                    f.RazaoSocial.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    f.NomeFantasia.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    f.CNPJ.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();

                GridFornecedores.DataSource = fornecedoresFiltrados;
                AtualizarContadorFornecedores(fornecedoresFiltrados.Count);
            }
        }

        private bool ValidarDuplicidadeCNPJ(string cnpj, int? idExcluir = null)
        {
            // Esta validação será feita de forma assíncrona no método de salvamento
            return true;
        }
        #endregion

        #region Métodos de Interface
        private void AtualizarBotoes()
        {
            bool temFornecedorSelecionado = fornecedorAtual != null && fornecedorAtual.ID > 0;
            bool modoEdicao = modoCriacao || (temFornecedorSelecionado && txtRazaoSocial.Enabled);

            btnNovo.Enabled = !modoEdicao;
            btnEditar.Enabled = temFornecedorSelecionado && !modoEdicao;
            btnSalvar.Enabled = modoEdicao;
           // btnCancelar.Enabled = modoEdicao;
            btnInativar.Enabled = temFornecedorSelecionado && !modoEdicao;
            btnAtualizar.Enabled = !modoEdicao;
        }

        private void HabilitarCampos(bool habilitar)
        {
            // Campos editáveis
            var camposEditaveis = new Control[]
            {
                txtRazaoSocial, txtNomeFantasia, txtCNPJ, dtpDataFundacao,
                txtTelefone, txtEmail, txtSite, txtEndereco, txtNumero,
                txtCEP, txtContato, cmbTipoFornecedor, cmbStatus,
                txtComplemento, txtObservacoes, btnBuscarCEP,txtCNPJ
            };

            foreach (var campo in camposEditaveis)
            {
                if (campo != null)
                    campo.Enabled = habilitar;
            }

            // Campos sempre readonly (preenchidos pela API)
            var camposReadonly = new Control[]
            {
                txtLogradouro, txtBairro, txtLocalidade, txtUF,
                txtEstado, txtRegiao, txtIBGE, txtCode
            };

            foreach (var campo in camposReadonly)
            {
                if (campo != null)
                    campo.Enabled = false;
            }

            //// Habilitar CNPJ apenas em modo criação
            //if (txtCNPJ != null)
            //    txtCNPJ.Enabled = habilitar && modoCriacao;
        }

        private void PreencherCampos(Fornecedor fornecedor)
        {
            if (fornecedor == null) return;

            txtCode.Text = fornecedor.ID > 0 ? fornecedor.ID.ToString() : "";
            txtRazaoSocial.Text = fornecedor.RazaoSocial ?? "";
            txtNomeFantasia.Text = fornecedor.NomeFantasia ?? "";
            txtCNPJ.Text = FormatarCNPJ(fornecedor.CNPJ);

            ConfigurarDataFundacao(fornecedor.DataFundacao);
            PreencherCamposTexto(fornecedor);
            ConfigurarComboBoxesComDados(fornecedor);
            ResetarCoresCampos();
        }

        private void ConfigurarDataFundacao(DateTime? dataFundacao)
        {
            if (dataFundacao.HasValue)
            {
                dtpDataFundacao.Value = dataFundacao.Value;
                dtpDataFundacao.Checked = true;
            }
            else
            {
                dtpDataFundacao.Checked = false;
            }
        }

        private void PreencherCamposTexto(Fornecedor fornecedor)
        {
            txtTelefone.Text = FormatarTelefone(fornecedor.Telefone);
            txtEmail.Text = fornecedor.Email ?? "";
            txtSite.Text = fornecedor.Site ?? "";
            txtEndereco.Text = fornecedor.Endereco ?? "";
            txtNumero.Text = fornecedor.Numero ?? "";
            txtCEP.Text = FormatarCEP(fornecedor.CEP);
            txtLogradouro.Text = fornecedor.Logradouro ?? "";
            txtBairro.Text = fornecedor.Bairro ?? "";
            txtLocalidade.Text = fornecedor.Localidade ?? "";
            txtUF.Text = fornecedor.UF ?? "";
            txtEstado.Text = fornecedor.Estado ?? "";
            txtRegiao.Text = fornecedor.Regiao ?? "";
            txtIBGE.Text = fornecedor.IBGE ?? "";
            txtComplemento.Text = fornecedor.Complemento ?? "";
            txtContato.Text = fornecedor.Contato ?? "";
            txtObservacoes.Text = fornecedor.Observacoes ?? "";
        }

        private void ConfigurarComboBoxesComDados(Fornecedor fornecedor)
        {
            // Configurar ComboBox Tipo Fornecedor
            if (!string.IsNullOrEmpty(fornecedor.TipoFornecedor))
            {
                int indexTipo = cmbTipoFornecedor.FindStringExact(fornecedor.TipoFornecedor);
                cmbTipoFornecedor.SelectedIndex = indexTipo >= 0 ? indexTipo : 0;
            }
            else
            {
                cmbTipoFornecedor.SelectedIndex = 0;
            }

            // Configurar ComboBox Status
            if (!string.IsNullOrEmpty(fornecedor.Status))
            {
                int indexStatus = cmbStatus.FindStringExact(fornecedor.Status);
                cmbStatus.SelectedIndex = indexStatus >= 0 ? indexStatus : 0;
            }
            else
            {
                cmbStatus.SelectedIndex = 0;
            }
        }

        private void LimparCampos()
        {
            var camposTexto = new TextBox[]
            {
                txtCode, txtRazaoSocial, txtNomeFantasia, txtEmail, txtSite, txtEndereco, txtNumero,
                 txtLogradouro, txtBairro, txtLocalidade, txtUF,
                txtEstado, txtRegiao, txtIBGE, txtComplemento, txtContato,
                txtObservacoes
            };

            foreach (var campo in camposTexto)
            {
                if (campo != null)
                    campo.Text = "";
                txtCNPJ.Clear();
                txtTelefone.Clear();
                txtCEP.Clear();
            }

            dtpDataFundacao.Checked = false;
            cmbTipoFornecedor.SelectedIndex = 0;
            cmbStatus.SelectedIndex = 0;

            AtualizarLabelsData(null);
            ResetarCoresCampos();
            fornecedorAtual = new Fornecedor();
        }

        private void AtualizarLabelsData(Fornecedor fornecedor)
        {
            if (fornecedor != null && fornecedor.ID > 0)
            {
                lbDataCriacao.Text = $"Fornecedor desde: {fornecedor.DataCadastro:dd/MM/yyyy}";
                lbMod.Text = $"Última Modificação: {fornecedor.UltimaModificacao:dd/MM/yyyy HH:mm}";
            }
            else
            {
                lbDataCriacao.Text = "Fornecedor desde: -";
                lbMod.Text = "Última Modificação: -";
            }
        }

        private void SelecionarFornecedorNoGrid(int fornecedorId)
        {
            foreach (DataGridViewRow row in GridFornecedores.Rows)
            {
                if (row.DataBoundItem is Fornecedor fornecedor && fornecedor.ID == fornecedorId)
                {
                    GridFornecedores.CurrentCell = row.Cells[0];
                    GridFornecedores.Rows[row.Index].Selected = true;
                    break;
                }
            }
        }
        #endregion

        #region Métodos de Dados
        private async Task CarregarFornecedoresAsync()
        {
            try
            {
                carregandoDados = true;
                var fornecedores = await fornecedor.ObterTodosFornecedoresAsync();

                GridFornecedores.DataSource = fornecedores;
                AtualizarContadorFornecedores(fornecedores.Count);
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao carregar fornecedores: {ex.Message}");
            }
            finally
            {
                carregandoDados = false;
            }
        }

        private void AtualizarContadorFornecedores(int total)
        {
            if (lbTotalFornecedores != null)
            {
                lbTotalFornecedores.Text = $"Total de Fornecedores: {total}";
            }
        }

        private bool ValidarCampos()
        {
            var validacoes = new List<(Func<bool> validacao, string mensagem, Control campo)>
            {
                (() => !string.IsNullOrWhiteSpace(txtRazaoSocial.Text),
                 "O campo Razão Social é obrigatório.", txtRazaoSocial),

                (() => !string.IsNullOrWhiteSpace(txtCNPJ.Text?.Replace("_", "").Replace(".", "").Replace("/", "").Replace("-", "")),
                 "O campo CNPJ é obrigatório.", txtCNPJ),

                (() => ValidarCNPJCompleto(),
                 "O CNPJ informado é inválido.", txtCNPJ),

                (() => string.IsNullOrWhiteSpace(txtEmail.Text) || ValidarEmail(txtEmail.Text),
                 "O email informado não é válido.", txtEmail),

                (() => ValidarTelefoneSePreenchido(),
                 "O telefone deve ter pelo menos 10 dígitos.", txtTelefone),

                (() => ValidarCEPSePreenchido(),
                 "O CEP deve ter 8 dígitos.", txtCEP)
            };

            foreach (var (validacao, mensagem, campo) in validacoes)
            {
                if (!validacao())
                {
                    ExibirAviso(mensagem);
                    campo?.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool ValidarCNPJCompleto()
        {
            string cnpj = new string(txtCNPJ.Text.Where(char.IsDigit).ToArray());
            return cnpj.Length == 14 && Validador.ValidarCNPJ(cnpj);
        }

        private bool ValidarTelefoneSePreenchido()
        {
            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
                return true;

            string telefone = new string(txtTelefone.Text.Where(char.IsDigit).ToArray());
            return telefone.Length >= 10;
        }

        private bool ValidarCEPSePreenchido()
        {
            if (string.IsNullOrWhiteSpace(txtCEP.Text))
                return true;

            string cep = new string(txtCEP.Text.Where(char.IsDigit).ToArray());
            return cep.Length == 8;
        }

        private bool ValidarEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void PreencherObjetoFornecedor()
        {
            fornecedorAtual.RazaoSocial = txtRazaoSocial.Text.Trim();
            fornecedorAtual.NomeFantasia = txtNomeFantasia.Text.Trim();
            fornecedorAtual.CNPJ = LimparCNPJ(txtCNPJ.Text);
            fornecedorAtual.DataFundacao = dtpDataFundacao.Checked ? dtpDataFundacao.Value : (DateTime?)null;
            fornecedorAtual.Telefone = LimparTelefone(txtTelefone.Text);
            fornecedorAtual.Email = txtEmail.Text.Trim();
            fornecedorAtual.Site = txtSite.Text.Trim();
            fornecedorAtual.Endereco = txtEndereco.Text.Trim();
            fornecedorAtual.Numero = txtNumero.Text.Trim();
            fornecedorAtual.CEP = LimparCEP(txtCEP.Text);
            fornecedorAtual.Logradouro = txtLogradouro.Text.Trim();
            fornecedorAtual.Bairro = txtBairro.Text.Trim();
            fornecedorAtual.Localidade = txtLocalidade.Text.Trim();
            fornecedorAtual.UF = txtUF.Text.Trim();
            fornecedorAtual.Estado = txtEstado.Text.Trim();
            fornecedorAtual.Regiao = txtRegiao.Text.Trim();
            fornecedorAtual.IBGE = txtIBGE.Text.Trim();
            fornecedorAtual.Complemento = txtComplemento.Text.Trim();
            fornecedorAtual.Contato = txtContato.Text.Trim();
            fornecedorAtual.TipoFornecedor = cmbTipoFornecedor.SelectedItem?.ToString() ?? "";
            fornecedorAtual.Status = cmbStatus.SelectedItem?.ToString() ?? "";
            fornecedorAtual.Observacoes = txtObservacoes.Text.Trim();

            // Atualizar data de modificação
            fornecedorAtual.UltimaModificacao = DateTime.Now;

            // Se é criação, definir data de cadastro
            if (modoCriacao)
            {
                fornecedorAtual.DataCadastro = DateTime.Now;
            }
        }
        #endregion

        #region Métodos Auxiliares
        private string LimparCNPJ(string cnpj)
        {
            return cnpj?.Replace("_", "").Replace(".", "").Replace("/", "").Replace("-", "") ?? "";
        }

        private string LimparTelefone(string telefone)
        {
            return telefone?.Replace("_", "").Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "") ?? "";
        }

        private string LimparCEP(string cep)
        {
            return cep?.Replace("_", "").Replace("-", "") ?? "";
        }

        private string FormatarCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
                return cnpj;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        private string FormatarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return telefone;

            string digits = new string(telefone.Where(char.IsDigit).ToArray());

            if (digits.Length == 11)
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 5)}-{digits.Substring(7, 4)}";
            else if (digits.Length == 10)
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 4)}-{digits.Substring(6, 4)}";

            return telefone;
        }

        private string FormatarCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
                return cep;

            return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
        }

        private void DefinirCorValidacao(Control campo, bool valido)
        {
            if (valido)
            {
                campo.BackColor = Color.LightGreen;
                campo.ForeColor = Color.Black;
            }
            else
            {
                campo.BackColor = Color.LightCoral;
                campo.ForeColor = Color.Black;
            }
        }

        private void ResetarCorCampo(Control campo)
        {
            campo.BackColor = SystemColors.Window;
            campo.ForeColor = SystemColors.WindowText;
        }

        private void ResetarCoresCampos()
        {
            var campos = new Control[] { txtCNPJ, txtEmail, txtTelefone, txtCEP };
            foreach (var campo in campos)
            {
                if (campo != null)
                    ResetarCorCampo(campo);
            }
        }
        #endregion

        #region Métodos de Validação e Confirmação
        private bool ValidarSelecaoFornecedor()
        {
            if (fornecedorAtual == null || fornecedorAtual.ID <= 0)
            {
                ExibirAviso("Selecione um fornecedor para realizar esta operação.");
                return false;
            }
            return true;
        }

        private bool ConfirmarAcaoSeNecessario()
        {
            if (txtRazaoSocial.Enabled) // Se está em modo de edição
            {
                return ConfirmarCancelamento();
            }
            return true;
        }

        private bool ConfirmarCancelamento()
        {
            return MessageBox.Show("Deseja cancelar as alterações?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmarInativacao()
        {
            return MessageBox.Show($"Confirma a inativação do fornecedor '{fornecedorAtual.RazaoSocial}'?",
                "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }

        private bool ConfirmarSaida()
        {
            if (txtRazaoSocial.Enabled) // Se está em modo de edição
            {
                return MessageBox.Show("Existem alterações não salvas. Deseja sair mesmo assim?",
                    "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            return true;
        }
        #endregion

        #region Métodos de Mensagens
        private void ExibirErro(string mensagem)
        {
            MessageBox.Show(mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ExibirAviso(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void ExibirSucesso(string mensagem)
        {
            MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region Funcionalidades Adicionais

        //// Método para buscar fornecedores
        //private async void txtBuscar_TextChanged(object sender, EventArgs e)
        //{
        //    if (txtBuscar != null && !carregandoDados)
        //    {
        //        string filtro = txtBuscar.Text.Trim();
        //        if (filtro.Length >= 3 || string.IsNullOrEmpty(filtro))
        //        {
        //            await BuscarFornecedoresAsync(filtro);
        //        }
        //    }
        //}

        private async Task BuscarFornecedoresAsync(string filtro)
        {
            try
            {
                carregandoDados = true;
                var fornecedores = await ObterFornecedoresFiltradosAsync(filtro);
                GridFornecedores.DataSource = fornecedores;
                AtualizarContadorFornecedores(fornecedores.Count);
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao buscar fornecedores: {ex.Message}");
            }
            finally
            {
                carregandoDados = false;
            }
        }

        // Método para exportar dados
        private void btnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                if (GridFornecedores.DataSource is List<Fornecedor> fornecedores && fornecedores.Count > 0)
                {
                    ExportarParaCSV(fornecedores);
                }
                else
                {
                    ExibirAviso("Não há dados para exportar.");
                }
            }
            catch (Exception ex)
            {
                ExibirErro($"Erro ao exportar dados: {ex.Message}");
            }
        }

        private void ExportarParaCSV(List<Fornecedor> fornecedores)
        {
            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv";
                saveFileDialog.Title = "Salvar lista de fornecedores";
                saveFileDialog.FileName = $"Fornecedores_{DateTime.Now:yyyyMMdd_HHmmss}.csv";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var csv = new StringBuilder();
                    csv.AppendLine("ID;Razão Social;Nome Fantasia;CNPJ;Telefone;Email;Status");

                    foreach (var fornecedor in fornecedores)
                    {
                        csv.AppendLine($"{fornecedor.ID};{fornecedor.RazaoSocial};{fornecedor.NomeFantasia};" +
                                     $"{FormatarCNPJ(fornecedor.CNPJ)};{FormatarTelefone(fornecedor.Telefone)};" +
                                     $"{fornecedor.Email};{fornecedor.Status}");
                    }

                    System.IO.File.WriteAllText(saveFileDialog.FileName, csv.ToString(), Encoding.UTF8);
                    ExibirSucesso("Dados exportados com sucesso!");
                }
            }
        }

        // Método para imprimir relatório
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Implementar funcionalidade de impressão
            ExibirAviso("Funcionalidade de impressão será implementada em breve.");
        }

        #endregion
               
    }
}
