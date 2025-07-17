using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Acessos
{
    public partial class frmPesquisaOrcamentos : RadForm
    {
        private readonly SqlConnection conexao;
        public int OrcamentoSelecionadoId { get; private set; }
        private DataTable dadosOriginais;

        public frmPesquisaOrcamentos(SqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao ?? throw new ArgumentNullException(nameof(conexao));
            CarregarOrcamentos();
            ConfigurarInterface();
        }

        private void ConfigurarInterface()
        {
            this.ThemeName = "Material";
            dgvOrcamentos.ThemeName = "Material";

            // Configurar botões
            btnSelecionar.ButtonElement.Text = "Selecionar";
            btnCancelar.ButtonElement.Text = "Cancelar";

            // Configurar caixa de pesquisa
            txtPesquisa.Padding = new Padding(5);
            txtPesquisa.NullText = "Digite para pesquisar...";

            // Configurar grid
            dgvOrcamentos.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;
            dgvOrcamentos.MasterTemplate.AllowAddNewRow = false;
            dgvOrcamentos.MasterTemplate.AllowDeleteRow = false;
            dgvOrcamentos.MasterTemplate.AllowEditRow = false;
            dgvOrcamentos.MasterTemplate.EnableFiltering = true;
            dgvOrcamentos.MasterTemplate.EnableGrouping = false;
            dgvOrcamentos.MasterTemplate.EnablePaging = true;
            dgvOrcamentos.MasterTemplate.PageSize = 20;
            dgvOrcamentos.SelectionMode = GridViewSelectionMode.FullRowSelect;

            ConfigurarColunasGrid();
        }

        private void ConfigurarColunasGrid()
        {
            dgvOrcamentos.Columns.Clear();

            var colId = new GridViewDecimalColumn("Id");
            colId.HeaderText = "Código";
            colId.Width = 70;
            colId.ReadOnly = true;
            dgvOrcamentos.Columns.Add(colId);

            var colData = new GridViewDateTimeColumn("Data");
            colData.HeaderText = "Data";
            colData.Format = DateTimePickerFormat.Short;
            colData.Width = 90;
            colData.ReadOnly = true;
            dgvOrcamentos.Columns.Add(colData);

            var colCliente = new GridViewTextBoxColumn("Cliente");
            colCliente.HeaderText = "Cliente";
            colCliente.Width = 240;
            colCliente.ReadOnly = true;
            dgvOrcamentos.Columns.Add(colCliente);

            var colTotal = new GridViewDecimalColumn("Total");
            colTotal.HeaderText = "Total";
            colTotal.FormatString = "{0:C2}";
            colTotal.Width = 100;
            colTotal.ReadOnly = true;
            colTotal.TextAlignment = ContentAlignment.MiddleRight;
            dgvOrcamentos.Columns.Add(colTotal);

            var colStatus = new GridViewTextBoxColumn("Status");
            colStatus.HeaderText = "Status";
            colStatus.Width = 120;
            colStatus.ReadOnly = true;
            dgvOrcamentos.Columns.Add(colStatus);
        }

        private void CarregarOrcamentos()
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(
                    "SELECT o.Id, o.Data, c.Nome as Cliente, o.Total, o.Status " +
                    "FROM Orcamentos o " +
                    "LEFT JOIN Clientes c ON o.ClienteId = c.Id " +
                    "ORDER BY o.Data DESC",
                    conexao))
                {
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dadosOriginais = new DataTable();
                    da.Fill(dadosOriginais);

                    dgvOrcamentos.DataSource = dadosOriginais;
                }
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Erro ao carregar orçamentos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            SelecionarOrcamento();
        }

        private void dgvOrcamentos_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelecionarOrcamento();
            }
        }

        private void SelecionarOrcamento()
        {
            if (dgvOrcamentos.CurrentRow != null &&
                dgvOrcamentos.CurrentRow is GridViewDataRowInfo)
            {
                OrcamentoSelecionadoId = Convert.ToInt32(dgvOrcamentos.CurrentRow.Cells["Id"].Value);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                RadMessageBox.Show("Selecione um orçamento para continuar.", "Aviso",
                    MessageBoxButtons.OK, RadMessageIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (dadosOriginais != null)
            {
                string filtro = txtPesquisa.Text.Trim();

                if (string.IsNullOrEmpty(filtro))
                {
                    dgvOrcamentos.DataSource = dadosOriginais;
                }
                else
                {
                    DataView dv = new DataView(dadosOriginais);
                    dv.RowFilter = $@"Id LIKE '%{filtro}%' OR 
                                     Cliente LIKE '%{filtro}%' OR 
                                     Status LIKE '%{filtro}%' OR 
                                     CONVERT(Total, 'System.String') LIKE '%{filtro}%'";

                    dgvOrcamentos.DataSource = dv;
                }
            }
        }
    }
}
