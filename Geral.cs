using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acessos.Usuarios;
using Telerik.WinControls;

namespace Acessos
{
    public partial class Geral : Form
    {
             private readonly string usuario = SessaoUsuario.UsuarioAtual.Nome;       
             private readonly string cargo = SessaoUsuario.UsuarioAtual.Cargo;
             private readonly int nivelAcesso = SessaoUsuario.UsuarioAtual.NivelAcesso;
             //
            AuditoriaAcesso auditoria;


        public Geral()
        {
            InitializeComponent();
        }
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

        private void btnLogout_Click(object sender, EventArgs e)
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
            lbusuario.Text = "Usuário:  "+usuario+" Função: "+cargo+" Nvl: "+nivelAcesso;
             auditoria = new AuditoriaAcesso();
            auditoria.InserirAuditoria(new AuditoriaAcesso
            {
                UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
                Acao = "Menu principal",
                DataHora = DateTime.Now,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
                Detalhes = "observando ações."
            });
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
      
        private void bt1_Click(object sender, EventArgs e)
        {
            FormManager.AlternarFormNoPainel<Usuariosfrm>(pDashboard);            
        }
    }
}
