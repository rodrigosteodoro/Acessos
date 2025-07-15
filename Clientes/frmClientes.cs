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
    public partial class frmClientes : Form
    {
        
        private Cliente clienteAtual;
        private bool modoEdicao = false;
        private bool modoCriacao = false;
        private Timer validationTimer = new Timer();
        private CEP cepService;
        private EnderecoInfo info;
        private ClienteRepository clienteDAL = new ClienteRepository();

        public frmClientes()
        {
            InitializeComponent();
            //
            validationTimer.Interval = 2000;
            validationTimer.Tick += ValidationTimer_Tick;
            //       
            clienteAtual = new Cliente();
            cepService = new CEP();
            info = new EnderecoInfo();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarFormulario();
                CarregarClientes();
                DefinirEstadoInicial();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar o formulário: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarFormulario()
        {
            // Configurar DateTimePicker
            if (dtpDataNascimento != null)
            {
                dtpDataNascimento.Format = DateTimePickerFormat.Short;
                dtpDataNascimento.ShowCheckBox = true;
                dtpDataNascimento.Checked = false;
            }

            // Configurar Grid
            if (GridClientes != null)
            {
                GridClientes.AutoGenerateColumns = false;
                GridClientes.AllowUserToAddRows = false;
                GridClientes.AllowUserToDeleteRows = false;
                GridClientes.ReadOnly = true;
                GridClientes.MultiSelect = false;
                GridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ConfigurarColunas();
            }

            // Configurar TabStop para campos que  Acessosem aceitar foco
            txtCPFCNPJ.TabStop = true;
            txtCEP.TabStop = true;
            txtRenda.TabStop = true;
            dtpDataNascimento.TabStop = true;
        }

        private void ConfigurarColunas()
        {
            GridClientes.Columns.Clear();

            GridClientes.Columns.Add("ID", "ID");
            GridClientes.Columns["ID"].Width = 30;
            GridClientes.Columns["ID"].DataPropertyName = "ID";
            GridClientes.Columns.Remove("ID");

            GridClientes.Columns.Add("Nome", "Nome");
            GridClientes.Columns["Nome"].Width = 200;
            GridClientes.Columns["Nome"].DataPropertyName = "Nome";


            GridClientes.Columns.Add("Telefone", "Telefone");
            GridClientes.Columns["Telefone"].Width = 120;
            GridClientes.Columns["Telefone"].DataPropertyName = "Telefone";

            GridClientes.Columns.Add("CPFCNPJ", "CPF/CNPJ");
            GridClientes.Columns["CPFCNPJ"].Width = 120;
            GridClientes.Columns["CPFCNPJ"].DataPropertyName = "CPFCNPJ";

            GridClientes.Columns.Add("DataNascimento", "Data Nasc.");
            GridClientes.Columns["DataNascimento"].Width = 100;
            GridClientes.Columns["DataNascimento"].DataPropertyName = "DataNascimento";
            GridClientes.Columns["DataNascimento"].DefaultCellStyle.Format = "dd/MM/yyyy";

            GridClientes.Columns.Add("Endereco", "Endereço");
            GridClientes.Columns["Endereco"].Width = 180;
            GridClientes.Columns["Endereco"].DataPropertyName = "Endereco";

            GridClientes.Columns.Add("RendaDeclarada", "Renda");
            GridClientes.Columns["RendaDeclarada"].Width = 100;
            GridClientes.Columns["RendaDeclarada"].DataPropertyName = "RendaDeclarada";
            GridClientes.Columns["RendaDeclarada"].DefaultCellStyle.Format = "C";
        }

        #region Eventos do Grid

        private void GridClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (GridClientes.CurrentRow != null && GridClientes.CurrentRow.DataBoundItem != null && !modoEdicao && !modoCriacao)
            {
                var cliente = (Cliente)GridClientes.CurrentRow.DataBoundItem;
                PreencherCampos(cliente);
                clienteAtual = cliente;
                AtualizarLabelsData(cliente);

                // Habilitar botão inativar apenas se há cliente selecionado
                btnInativar.Enabled = cliente.ID > 0;
            }
        }

        private void GridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && GridClientes.Rows[e.RowIndex].DataBoundItem != null)
                {
                    var cliente = (Cliente)GridClientes.Rows[e.RowIndex].DataBoundItem;

                    if (cliente != null && cliente.ID > 0)
                    {
                        PreencherCampos(cliente);
                        clienteAtual = cliente;
                        AtualizarLabelsData(cliente);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar cliente: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos dos Botões

        private void btnNovo_Click(object sender, EventArgs e)
        {
            try
            {
                IniciarModoCriacao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao criar novo cliente: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private  void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteAtual == null || clienteAtual.ID == 0)
                {
                    MessageBox.Show("Selecione um cliente no grid para editar.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                IniciarModoEdicao();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao iniciar edição: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
              await  SalvarClienteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (modoEdicao || modoCriacao)
                {
                    // Se está em modo de edição/criação, cancelar primeiro
                    var resultado = MessageBox.Show("Deseja cancelar as alterações e atualizar a lista?",
                        "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                  await   CancelarOperacao();
                        AtualizarListaClientes();
                    }
                }
                else
                {
                    AtualizarListaClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnInativar_Click(object sender, EventArgs e)
        {
            try
            {
              await  InativarClienteAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inativar: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
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
                MessageBox.Show($"Erro ao sair: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCPFCNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void txtCPFCNPJ_TextChanged(object sender, EventArgs e)
        {
            string digits = new string(txtCPFCNPJ.Text.Where(char.IsDigit).ToArray());

            if (digits.Length == 11)
                txtCPFCNPJ.Mask = "000,000,000-00";
            else if (digits.Length == 14)
                txtCPFCNPJ.Mask = "00,000,000/0000-00";
        }

        private void txtCPFCNPJ_KeyUp(object sender, KeyEventArgs e)
        {
            validationTimer.Stop();
            validationTimer.Start();
        }

        private void ValidationTimer_Tick(object sender, EventArgs e)
        {
            validationTimer.Stop();

            string digits = new string(txtCPFCNPJ.Text.Where(char.IsDigit).ToArray());

            if (digits.Length == 11)
            {
                if (Validador.ValidarCPF(digits))
                {
                    txtCPFCNPJ.BackColor = Color.DarkGreen;
                    txtCPFCNPJ.ForeColor = Color.White;
                }
                else
                {
                    txtCPFCNPJ.BackColor = Color.DarkRed;
                    txtCPFCNPJ.ForeColor = Color.White;
                    MessageBox.Show("CPF inválido!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (digits.Length == 14)
            {
                if (Validador.ValidarCNPJ(digits))
                {
                    txtCPFCNPJ.BackColor = Color.DarkGreen;
                    txtCPFCNPJ.ForeColor = Color.White;
                }
                else
                {
                    txtCPFCNPJ.BackColor = Color.DarkRed;
                    txtCPFCNPJ.ForeColor = Color.White;
                    MessageBox.Show("CNPJ inválido!", "Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtCPFCNPJ.BackColor = Color.Linen;
                txtCPFCNPJ.ForeColor = Color.Black;
            }
        }

        #endregion

        #region Eventos de CEP

        private async void btnBuscarCEP_Click(object sender, EventArgs e)
        {
            try
            {
                string cepValue = txtCEP.Text?.Replace("_", "").Replace("-", "") ?? "";

                if (string.IsNullOrWhiteSpace(cepValue) || cepValue.Length != 8)
                {
                    MessageBox.Show("Por favor, informe um CEP válido com 8 dígitos.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCEP.Focus();
                    return;
                }

                btnBuscarCEP.Enabled = false;
                btnBuscarCEP.Text = "Buscando...";

                var enderecoInfo = await cepService.BuscarEnderecoPorCEP(cepValue);

                if (enderecoInfo != null)
                {
                   PreencherEndereco(enderecoInfo);
                    MessageBox.Show("Endereço encontrado e preenchido automaticamente!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("CEP não encontrado. Verifique o número informado.",
                        "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar CEP: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnBuscarCEP.Enabled = true;
                btnBuscarCEP.Text = "Buscar";
            }
        }
        private void PreencherEndereco(EnderecoInfo enderecoInfo)
        {
            if (enderecoInfo == null) return;

            txtLogradouro.Text = enderecoInfo.Logradouro ?? "";
            txtBairro.Text = enderecoInfo.Bairro ?? "";
            txtLocalidade.Text = enderecoInfo.Localidade ?? "";
            txtUF.Text = enderecoInfo.UF ?? "";
            txtEstado.Text = enderecoInfo.Estado ?? "";
            txtRegiao.Text = enderecoInfo.Regiao ?? "";
            txtIBGE.Text = enderecoInfo.IBGE ?? "";
        }
        #endregion

        #region Métodos de Negócio

        private void IniciarModoCriacao()
        {
            LimparCampos();
            clienteAtual = new Cliente();
            modoCriacao = true;
            modoEdicao = false;
            DefinirEstadoFormulario(EstadoFormulario.Criacao);
            txtNome.Focus();
        }

        private void IniciarModoEdicao()
        {
            modoEdicao = true;
            modoCriacao = false;
           DefinirEstadoFormulario(EstadoFormulario.Edicao);
            txtNome.Focus();
        }

        private async Task CancelarOperacao()
        {
            if (modoCriacao)
            {
                LimparCampos();
                clienteAtual = new Cliente();
            }
            else if (modoEdicao && clienteAtual.ID > 0)
            {
                // Recarregar dados originais  
                var clienteOriginal = await clienteDAL.ObterClientePorIdAsync(clienteAtual.ID);
                if (clienteOriginal != null)
                {
                    PreencherCampos((Cliente)clienteOriginal); 
                    clienteAtual = (Cliente)clienteOriginal;
                    AtualizarLabelsData((Cliente)clienteOriginal);
                }
            }

            modoEdicao = false;
            modoCriacao = false;
            DefinirEstadoFormulario(EstadoFormulario.Visualizacao);
        }

        private async Task SalvarClienteAsync()
        {
            if (!ValidarCampos())
                return;

            PreencherObjetoCliente();

            bool sucesso;
            string mensagem;

            if (modoCriacao)
            {
                var novoId = await clienteDAL.InserirClienteAsync(clienteAtual);
                clienteAtual.ID = novoId;
                sucesso = novoId > 0;
                mensagem = "Cliente criado com sucesso!";
            }
            else
            {
                sucesso = await clienteDAL.AtualizarClienteAsync(clienteAtual);
                mensagem = "Cliente atualizado com sucesso!";
            }

            if (sucesso)
            {
                MessageBox.Show(mensagem, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                modoEdicao = false;
                modoCriacao = false;

                CarregarClientes();
                SelecionarClienteNoGrid(clienteAtual.ID);

                if (clienteAtual.ID > 0)
                {
                    var atualizado = await clienteDAL.ObterClientePorIdAsync(clienteAtual.ID);
                    if (atualizado != null)
                    {
                        PreencherCampos((Cliente)atualizado);
                        AtualizarLabelsData((Cliente)atualizado);
                    }
                }

                DefinirEstadoFormulario(EstadoFormulario.Visualizacao);
            }
            else
            {
                MessageBox.Show("Erro ao salvar cliente. Tente novamente.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task InativarClienteAsync()
        {
            if (clienteAtual == null || clienteAtual.ID == 0)
            {
                MessageBox.Show("Selecione um cliente no grid para inativar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja realmente inativar o cliente '{clienteAtual.Nome}'?\n\nEsta ação não poderá ser desfeita.",
                "Confirmação de Inativação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                if (await clienteDAL.InativarClienteAsync(clienteAtual.ID))
                {
                    MessageBox.Show("Cliente inativado com sucesso!",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                     CarregarClientes();
                    LimparCampos();
                    clienteAtual = new Cliente();
                    DefinirEstadoFormulario(EstadoFormulario.Visualizacao);
                }
                else
                {
                    MessageBox.Show("Erro ao inativar cliente. Tente novamente.",
                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AtualizarListaClientes()
        {
            var clienteSelecionado = clienteAtual;
            CarregarClientes();

            // Tentar reselecionar cliente anterior
            if (clienteSelecionado != null && clienteSelecionado.ID > 0)
            {
                SelecionarClienteNoGrid(clienteSelecionado.ID);
            }

            MessageBox.Show("Lista de clientes atualizada!",
                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Métodos de Interface

        private enum EstadoFormulario
        {
            Visualizacao,
            Criacao,
            Edicao
        }

        private void DefinirEstadoInicial()
        {
            LimparCampos();
            DefinirEstadoFormulario(EstadoFormulario.Visualizacao);

            // Se há clientes, selecionar o primeiro
            if (GridClientes.Rows.Count > 0)
            {
                GridClientes.CurrentCell = GridClientes.Rows[0].Cells[0];
            }
        }

        private void DefinirEstadoFormulario(EstadoFormulario estado)
        {
            switch (estado)
            {
                case EstadoFormulario.Visualizacao:
                    // Campos desabilitados para visualização
                    HabilitarCampos(false);

                    // Botões habilitados: Novo, Editar, Inativar, Atualizar, Sair
                    btnNovo.Enabled = true;
                    btnEditar.Enabled = true;
                    btnSalvar.Enabled = false;
                    btnAtualizar.Enabled = true;
                    btnInativar.Enabled = clienteAtual != null && clienteAtual.ID > 0;
                    btnSair.Enabled = true;

                    // Grid habilitado
                    GridClientes.Enabled = true;
                    break;

                case EstadoFormulario.Criacao:
                case EstadoFormulario.Edicao:
                    // Campos habilitados para edição
                    HabilitarCampos(true);

                    // Botões habilitados: Salvar, Atualizar (para cancelar), Sair
                    btnNovo.Enabled = false;
                    btnEditar.Enabled = false;
                    btnSalvar.Enabled = true;
                    btnAtualizar.Enabled = true; // Funciona como cancelar
                    btnInativar.Enabled = false;
                    btnSair.Enabled = true;

                    // Grid desabilitado durante edição
                    GridClientes.Enabled = false;
                    break;
            }
        }

        private void HabilitarCampos(bool habilitar)
        {
            // Campos editáveis
            txtNome.Enabled = habilitar;
            txtCPFCNPJ.Enabled = habilitar;
            dtpDataNascimento.Enabled = habilitar;
            txtEndereco.Enabled = habilitar;
            txtNumero.Enabled = habilitar;
            txtTelefone.Enabled = habilitar;
            txtRenda.Enabled = habilitar;
            txtCEP.Enabled = habilitar;
            txtComplemento.Enabled = habilitar;
            btnBuscarCEP.Enabled = habilitar;

            // Campos sempre readonly (preenchidos pela API)
            txtLogradouro.Enabled = false;
            txtBairro.Enabled = false;
            txtLocalidade.Enabled = false;
            txtUF.Enabled = false;
            txtEstado.Enabled = false;
            txtRegiao.Enabled = false;
            txtIBGE.Enabled = false;
            txtCode.Enabled = false;
        }

        private void PreencherCampos(Cliente cliente)
        {
            if (cliente == null) return;

            txtCode.Text = cliente.ID > 0 ? cliente.ID.ToString() : "";
            txtNome.Text = cliente.Nome ?? "";
            txtCPFCNPJ.Text = cliente.CPFCNPJ ?? "";

            if (cliente.DataNascimento.HasValue)
            {
                dtpDataNascimento.Value = cliente.DataNascimento.Value;
                dtpDataNascimento.Checked = true;
            }
            else
            {
                dtpDataNascimento.Checked = false;
            }

            txtEndereco.Text = cliente.Endereco ?? "";
            txtNumero.Text = cliente.Numero ?? "";
            txtTelefone.Text = cliente.Telefone ?? "";
            txtRenda.Text = cliente.RendaDeclarada?.ToString("C") ?? "";
            txtCEP.Text = cliente.CEP ?? "";
            txtLogradouro.Text = cliente.Logradouro ?? "";
            txtBairro.Text = cliente.Bairro ?? "";
            txtLocalidade.Text = cliente.Localidade ?? "";
            txtUF.Text = cliente.UF ?? "";
            txtEstado.Text = cliente.Estado ?? "";
            txtRegiao.Text = cliente.Regiao ?? "";
            txtIBGE.Text = cliente.IBGE ?? "";
            txtComplemento.Text = cliente.Complemento ?? "";
        }

        private void LimparCampos()
        {
            txtCode.Text = "";
            txtNome.Text = "";
            txtCPFCNPJ.Text = "";
            dtpDataNascimento.Checked = false;
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtTelefone.Text = "";
            txtRenda.Text = "";
            txtCEP.Text = "";
            txtLogradouro.Text = "";
            txtBairro.Text = "";
            txtLocalidade.Text = "";
            txtUF.Text = "";
            txtEstado.Text = "";
            txtRegiao.Text = "";
            txtIBGE.Text = "";
            txtComplemento.Text = "";

            AtualizarLabelsData(null);
            clienteAtual = new Cliente();
        }

        private void AtualizarLabelsData(Cliente cliente)
        {
            if (cliente != null && cliente.ID > 0)
            {
                lbDataCriacao.Text = $"Cliente desde: {cliente.DataCadastro:dd/MM/yyyy}";
                lbMod.Text = $"Última Modificação: {cliente.UltimaModificacao:dd/MM/yyyy HH:mm}";
            }
            else
            {
                lbDataCriacao.Text = "Cliente desde: -";
                lbMod.Text = "Última Modificação: -";
            }
        }

        private void SelecionarClienteNoGrid(int clienteId)
        {
            foreach (DataGridViewRow row in GridClientes.Rows)
            {
                if (row.DataBoundItem is Cliente cliente && cliente.ID == clienteId)
                {
                    GridClientes.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private async void CarregarClientes()
        {
            try
            {
                var clientesTask = clienteDAL.ObterTodosClientesAsync();
                var clientes = await clientesTask; 
                GridClientes.DataSource = clientes;

                if (lbTotalClientes != null)
                {
                    lbTotalClientes.Text = $"Total de Clientes: {clientes.Count}"; 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("O campo Nome é obrigatório.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCPFCNPJ.Text?.Replace("_", "").Replace(".", "").Replace("-", "")))
            {
                MessageBox.Show("O campo CPF/CNPJ é obrigatório.",
                    "Validação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCPFCNPJ.Focus();
                return false;
            }

            return true;
        }

        private void PreencherObjetoCliente()
        {
            clienteAtual.Nome = txtNome.Text.Trim();
            clienteAtual.CPFCNPJ = txtCPFCNPJ.Text?.Replace("_", "").Replace(".", "").Replace("-", "").Replace("/", "") ?? "";
            clienteAtual.DataNascimento = dtpDataNascimento.Checked ? dtpDataNascimento.Value : (DateTime?)null;
            clienteAtual.Endereco = txtEndereco.Text.Trim();
            clienteAtual.Numero = txtNumero.Text.Trim();
            clienteAtual.Telefone = txtTelefone.Text.Trim();

            // Conversão de renda
            if (!string.IsNullOrWhiteSpace(txtRenda.Text))
            {
                var rendaTexto = txtRenda.Text.Replace("R$", "").Replace(".", "").Replace(",", ".").Trim();
                if (decimal.TryParse(rendaTexto, out decimal renda))
                {
                    clienteAtual.RendaDeclarada = renda;
                }
            }
            else
            {
                clienteAtual.RendaDeclarada = null;
            }

            // Dados de endereço
            clienteAtual.CEP = txtCEP.Text?.Replace("_", "").Replace("-", "") ?? "";
            clienteAtual.Logradouro = txtLogradouro.Text.Trim();
            clienteAtual.Bairro = txtBairro.Text.Trim();
            clienteAtual.Localidade = txtLocalidade.Text.Trim();
            clienteAtual.UF = txtUF.Text.Trim();
            clienteAtual.Estado = txtEstado.Text.Trim();
            clienteAtual.Regiao = txtRegiao.Text.Trim();
            clienteAtual.IBGE = txtIBGE.Text.Trim();
            clienteAtual.Complemento = txtComplemento.Text.Trim();

            // Atualizar data de modificação
            clienteAtual.UltimaModificacao = DateTime.Now;

            // Se é criação, definir data de cadastro
            if (modoCriacao)
            {
                clienteAtual.DataCadastro = DateTime.Now;
            }
        }

        private bool VerificarAlteracoesPendentes()
        {
            return modoEdicao || modoCriacao;
        }


        #endregion

    }
}

