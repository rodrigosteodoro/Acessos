using System;
using System.Windows.Forms;
using Acessos.Usuarios;
using Telerik.WinControls;

namespace Acessos
{
    public partial class Geral : Telerik.WinControls.UI.RadForm
    {
        private readonly string usuario = SessaoUsuario.UsuarioAtual.Nome;
        private readonly string cargo = SessaoUsuario.UsuarioAtual.Cargo;
        private readonly int nivelAcesso = SessaoUsuario.UsuarioAtual.NivelAcesso;
        //
        AuditoriaAcesso auditoria;


        public Geral() => InitializeComponent();
      
        private void Geral_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = RadMessageBox.Show(
                "Deseja realmente sair?",
                "Sair",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true; // Cancela o fechamento
            }

        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            // Auditoria de logout
            auditoria.InserirAuditoria(new AuditoriaAcesso
            {
                UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
                Acao = "Logout",
                DataHora = DateTime.Now,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
                Detalhes = "Usuário fez logout."
            });

            // Limpa sessão do usuário
            SessaoUsuario.UsuarioAtual = null;
            this.Hide();
            var loginForm = new Loginfrm();

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                this.Show();
            }
            else
            {
                Application.ExitThread();
            }

        }

        private void Geral_Load(object sender, EventArgs e)
        {
            lbusuario.Text = "Usuário:  " + usuario;
            auditoria = new AuditoriaAcesso();
            auditoria.InserirAuditoria(new AuditoriaAcesso
            {
                UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
                Acao = "Menu principal",
                DataHora = DateTime.Now,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
                Detalhes = "observando ações."
            });
            // eventos de mouse para os botões
            bt1.MouseHover += MouseEnterHandler;
            bt1.MouseLeave += MouseLeaveHandler;
            bt2.MouseHover += MouseEnterHandler;
            bt2.MouseLeave += MouseLeaveHandler;
            bt3.MouseHover += MouseEnterHandler;
            bt3.MouseLeave += MouseLeaveHandler;
            bt4.MouseHover += MouseEnterHandler;
            bt4.MouseLeave += MouseLeaveHandler;
            btLogout.MouseHover += MouseEnterHandler;
            btLogout.MouseLeave += MouseLeaveHandler;
            btOrcamentos.MouseHover += MouseEnterHandler;
            btOrcamentos.MouseLeave += MouseLeaveHandler;
            btVendas.MouseHover += MouseEnterHandler;
            btVendas.MouseLeave += MouseLeaveHandler;
        }

        internal bool VerificarPermissao(Cargo cargo, int nivelAcesso, Acao acao)
        {
            switch (cargo)
            {
                case Cargo.Admin:
                    return nivelAcesso >= 5; // Admin tem todas as permissões

                case Cargo.Gerente:
                    // Gerente pode tudo, exceto excluir usuários (ajuste conforme sua regra)
                    if (nivelAcesso == 4)
                        return acao != Acao.Excluir;
                    break;

                case Cargo.Supervisor:
                    // Supervisor pode visualizar e editar
                    if (nivelAcesso == 3)
                        return acao == Acao.Visualizar || acao == Acao.Editar;
                    break;

                case Cargo.Encarregado:
                    // Encarregado pode visualizar
                    if (nivelAcesso == 2)
                        return acao == Acao.Visualizar;
                    break;

                case Cargo.Comum:
                    // Comum pode tudo menos excluir
                    return acao != Acao.Excluir;
            }
            return false; // Não permitido por padrão
        }

        private void btUsuarios_Click(object sender, EventArgs e) => FormManager.ShowForm<Usuariosfrm>();
       
        private void btFornecedores_Click(object sender, EventArgs e) => FormManager.ShowForm<frmFornecedores>();
        
        private void btProdutos_Click(object sender, EventArgs e) => FormManager.ShowForm<frmProdutos>();    
        
        private void btClientes_Click(object sender, EventArgs e) => FormManager.ShowForm<frmEdicaoP>(); //corrigir aqui para o form de clientes

        private void MouseLeaveHandler(object sender, EventArgs e)
        {
            lbMsg.Visible = false;
            lbMsg2.Visible = false;
        }

        private void MouseEnterHandler(object sender, EventArgs e)
        {
            lbMsg.Visible = true;
            lbMsg2.Visible = true;

            if (sender == bt1)
                lbMsg.Text = "módulo de Usuários.";
            else if (sender == bt2)
                lbMsg.Text = "módulo de Fornecedores.";
            else if (sender == bt3)
                lbMsg.Text = "módulo de Produtos.";
            else if (sender == bt4)
                lbMsg.Text = "módulo de Clientes.";
            else if (sender == btOrcamentos)
                lbMsg2.Text = "módulo de Orçamentos.";
            else if (sender == btVendas)
                lbMsg2.Text = "módulo de Vendas.";
        }
    }
}
