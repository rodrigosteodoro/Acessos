using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Acessos
{
    public partial class FormSelecaoCliente : Telerik.WinControls.UI.RadForm
    {
        private List<ICliente> clientes;
        private List<ICliente> clientesFiltrados;

        public Cliente ClienteSelecionado { get; private set; }

        public FormSelecaoCliente(List<ICliente> listaClientes)
        {
            InitializeComponent();
            clientes = listaClientes ?? new List<ICliente>();

            // Corrija aqui:
            clientesFiltrados = clientes.OfType<ICliente>().ToList();

            ConfigurarGrid();
            CarregarClientes();
        }


        private void ConfigurarGrid()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            // Configurar colunas manualmente para melhor controle
            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ID",
                HeaderText = "ID",
                DataPropertyName = "ID",
                Width = 60,
                Visible = false
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CPFCNPJ",
                HeaderText = "CPF/CNPJ",
                DataPropertyName = "CPFCNPJ",
                Width = 120
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Endereco",
                HeaderText = "Endereço",
                DataPropertyName = "Endereco",
                Width = 180
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Localidade",
                HeaderText = "Cidade",
                DataPropertyName = "Localidade",
                Width = 120
            });

            dgvClientes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UF",
                HeaderText = "UF",
                DataPropertyName = "UF",
                Width = 40
            });

            // Configurações gerais do grid
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.RowHeadersVisible = false;
        }

        private void CarregarClientes()
        {
            try
            {
                dgvClientes.DataSource = null;
                dgvClientes.DataSource = clientesFiltrados;

                // Atualizar contador
                this.Text = $"Pesquisar Clientes - {clientesFiltrados.Count} registro(s) encontrado(s)";

                // Habilitar/desabilitar botão selecionar
                btnSelecionar.Enabled = clientesFiltrados.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar clientes: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelecionarCliente();
        }

        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica se não é o cabeçalho
            {
                SelecionarCliente();
            }
        }

        private void SelecionarCliente()
        {
            if (dgvClientes.CurrentRow?.DataBoundItem is Cliente clienteSelecionado)
            {
                ClienteSelecionado = clienteSelecionado;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Selecione um cliente para continuar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClienteSelecionado = null;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            FiltrarClientes();
        }

        private void FiltrarClientes()
        {
            try
            {
                string filtro = txtPesquisa.Text.Trim().ToLower();

                if (string.IsNullOrEmpty(filtro))
                {
                    // Se não há filtro, mostrar todos os clientes
                    clientesFiltrados = new List<ICliente>(clientes);
                }
                else
                {
                    // Aplicar filtro nos campos relevantes
                    clientesFiltrados = clientes.Where(c =>
                        (!string.IsNullOrEmpty(c.Nome) && c.Nome.ToLower().Contains(filtro)) ||
                        (!string.IsNullOrEmpty(c.CPFCNPJ) && c.CPFCNPJ.Replace(".", "").Replace("-", "").Replace("/", "").Contains(filtro.Replace(".", "").Replace("-", "").Replace("/", ""))) ||
                        (!string.IsNullOrEmpty(c.Endereco) && c.Endereco.ToLower().Contains(filtro)) ||
                        (!string.IsNullOrEmpty(c.Localidade) && c.Localidade.ToLower().Contains(filtro)) ||
                        (!string.IsNullOrEmpty(c.UF) && c.UF.ToLower().Contains(filtro))
                    ).ToList();
                }

                CarregarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao filtrar clientes: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Focar no campo de pesquisa ao abrir o formulário
            txtPesquisa.Focus();

            // Se não há clientes, mostrar mensagem
            if (clientes.Count == 0)
            {
                MessageBox.Show("Nenhum cliente encontrado no sistema.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Permitir navegação com teclado
            switch (keyData)
            {
                case Keys.Enter:
                    if (dgvClientes.Focused && dgvClientes.CurrentRow != null)
                    {
                        SelecionarCliente();
                        return true;
                    }
                    break;

                case Keys.Escape:
                    btnCancelar_Click(null, null);
                    return true;

                case Keys.F3:
                    txtPesquisa.Focus();
                    txtPesquisa.SelectAll();
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
