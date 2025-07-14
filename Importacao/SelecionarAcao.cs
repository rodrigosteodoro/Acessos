using System;
using System.Windows.Forms;

namespace Acessos
{
    public partial class SelecionarAcao : Form
    {
        public ProdutoDuplicataService.AcaoDuplicata AcaoSelecionada { get; private set; }

        public SelecionarAcao()
        {
            InitializeComponent();
            ConfigurarFormularioCompleto();
        }

        private void ConfigurarFormularioCompleto()
        {
            // Configurar ComboBox com as ações disponíveis
            cmbAcao.DataSource = Enum.GetValues(typeof(ProdutoDuplicataService.AcaoDuplicata));
            cmbAcao.SelectedIndex = 0;

            // Configurar eventos
            btnOK.Click += BtnOK_Click;
            btnCancelar.Click += BtnCancelar_Click;
            cmbAcao.SelectedIndexChanged += CmbAcao_SelectedIndexChanged;

            // Definir ação padrão e descrição inicial
            AcaoSelecionada = (ProdutoDuplicataService.AcaoDuplicata)cmbAcao.SelectedItem;
            lblDescricao.Text = ObterDescricaoAcao(AcaoSelecionada);
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            AcaoSelecionada = (ProdutoDuplicataService.AcaoDuplicata)cmbAcao.SelectedItem;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CmbAcao_SelectedIndexChanged(object sender, EventArgs e)
        {
            var acao = (ProdutoDuplicataService.AcaoDuplicata)cmbAcao.SelectedItem;
            lblDescricao.Text = ObterDescricaoAcao(acao);
        }

        private string ObterDescricaoAcao(ProdutoDuplicataService.AcaoDuplicata acao)
        {
            return acao switch
            {
                ProdutoDuplicataService.AcaoDuplicata.Ignorar => "Ignorar produtos duplicados durante a importação.",
                ProdutoDuplicataService.AcaoDuplicata.Atualizar => "Atualizar produtos existentes com os dados importados.",
                ProdutoDuplicataService.AcaoDuplicata.Substituir => "Substituir completamente produtos existentes.",
                ProdutoDuplicataService.AcaoDuplicata.InserirComCodigoNovo => "Inserir como novos produtos com códigos modificados.",
                ProdutoDuplicataService.AcaoDuplicata.Perguntar => "Perguntar ação para cada produto duplicado individualmente.",
                _ => "Selecione uma ação para todos os produtos duplicados:"
            };
        }
    }
}
