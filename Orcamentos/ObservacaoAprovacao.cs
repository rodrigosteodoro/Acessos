using System;
using System.Windows.Forms;

namespace  Acessos
{
    public partial class ObservacaoAprovacao : Form
    {
        public string Observacao { get; private set; }
        private string tipoOperacao;

        public ObservacaoAprovacao(string tipoOperacao)
        {
            InitializeComponent();
            this.tipoOperacao = tipoOperacao;
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            switch (tipoOperacao.ToLower())
            {
                case "aprovação":
                case "aprovacao":
                    this.Text = "Aprovação do Orçamento";
                    lblTitulo.Text = "Aprovação do Orçamento";
                    lblInstrucao.Text = "Informe uma observação para a aprovação (opcional):";
                    btnConfirmar.Text = "Aprovar";
                    btnConfirmar.BackColor = System.Drawing.Color.Green;
                    btnConfirmar.ForeColor = System.Drawing.Color.White;
                    break;

                case "rejeição":
                case "rejeicao":
                    this.Text = "Rejeição do Orçamento";
                    lblTitulo.Text = "Rejeição do Orçamento";
                    lblInstrucao.Text = "Informe o motivo da rejeição (obrigatório):";
                    btnConfirmar.Text = "Rejeitar";
                    btnConfirmar.BackColor = System.Drawing.Color.Red;
                    btnConfirmar.ForeColor = System.Drawing.Color.White;
                    break;

                default:
                    this.Text = "Observação";
                    lblTitulo.Text = "Observação";
                    lblInstrucao.Text = "Informe uma observação:";
                    btnConfirmar.Text = "Confirmar";
                    break;
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validar se é rejeição e observação é obrigatória
            if (tipoOperacao.ToLower().Contains("rejeic") && string.IsNullOrWhiteSpace(txtObservacao.Text))
            {
                MessageBox.Show("Para rejeitar um orçamento é obrigatório informar o motivo.", "Observação Obrigatória",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservacao.Focus();
                return;
            }

            Observacao = txtObservacao.Text.Trim();
            if (string.IsNullOrEmpty(Observacao))
            {
                Observacao = $"{tipoOperacao} realizada em {DateTime.Now:dd/MM/yyyy HH:mm}";
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }
    }
}
