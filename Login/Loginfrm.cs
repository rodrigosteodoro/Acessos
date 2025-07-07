using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acessos.Security;
using Bunifu.UI.WinForms;
using Telerik.WinControls;

namespace Acessos
{
    internal partial class Loginfrm : Telerik.WinControls.UI.RadForm
    {
        private bool loginEfetuado = false;
        private int tentativas = 0; // Variável de instância para contar tentativas

        private Dictionary<string, int> tentativasLogin = new Dictionary<string, int>();

        internal Loginfrm()
        {
            InitializeComponent();
        }
        private void Loginfrm_Load(object sender, EventArgs e)
        {
            //verificar condicoes de login
        }
        private void Loginfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginEfetuado) // Só pergunta se o login NÃO foi efetuado
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
            // Se loginEfetuado == true, não pergunta nada e fecha normalmente!
        }
       
        private async Task AtualizarHashSenhaNoBancoAsync(int usuarioId, string novaHash)
        {
            using (var conn = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("UPDATE usuario SET senha = @Senha WHERE UsuarioID = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Senha", novaHash);
                    cmd.Parameters.AddWithValue("@Id", usuarioId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        private async void btLogar_Click(object sender, EventArgs e)
        {
            // 1. Validação dos campos
            if (string.IsNullOrWhiteSpace(txtNome.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                RadMessageBox.Show("Por favor, preencha todos os campos.", "Atenção", MessageBoxButtons.OK, RadMessageIcon.Info);
                return;
            }

            // 2. Exibe loader e desabilita botão
            Loader.Visible = true;
            btLogar.Enabled = false;

            string nomeUsuario = txtNome.Text.Trim();
            string senha = txtSenha.Text;
            DataTable dt = null;

            await Task.Run(() => { dt = new Usuario("Admin").ConsultarUsuario(); });

            var usuarioEncontrado = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("Nome") == nomeUsuario);

            // 3. Carrega status do usuário
            IUsuarioStatus status = null;
            if (usuarioEncontrado != null)
            {
                int usuarioId = usuarioEncontrado.Field<int>("UsuarioID");
                status = new UsuarioStatus("Admin").CarregarStatusUsuario(usuarioId);
            }

            // 4. Checa status antes de validar senha
            if (status != null && new[] { "Bloqueado", "Inativo", "Suspenso" }.Contains(status.Situacao))
            {
                Loader.Visible = false;
                btLogar.Enabled = true;
                RadMessageBox.Show($"Usuário {status.Situacao.ToLower()}. Contate o administrador.", "Acesso negado", MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            // 5. Verifica senha (com suporte à migração)
            bool senhaValida = false;
            if (usuarioEncontrado != null)
            {
                string hashBanco = usuarioEncontrado.Field<string>("Senha");

                if (HashSenhaMigrador.PrecisaMigrar(hashBanco))
                {
                    senhaValida = HashSenhaMigrador.ValidarSenhaAntiga(senha, hashBanco);

                    if (senhaValida)
                    {
                        string novaHash = HashSenhaManager.CriarHash(senha);
                        await AtualizarHashSenhaNoBancoAsync(usuarioEncontrado.Field<int>("UsuarioID"), novaHash);
                    }
                }
                else
                {
                    senhaValida = HashSenhaManager.VerificarSenha(senha, hashBanco);
                }
            }

            // 6. Login bem-sucedido
            if (usuarioEncontrado != null && senhaValida && usuarioEncontrado.Field<bool>("Ativo"))
            {
                loginEfetuado = true;

                SessaoUsuario.UsuarioAtual = new UsuarioLogado
                {
                    UsuarioID = usuarioEncontrado.Field<int>("UsuarioID"),
                    Nome = usuarioEncontrado.Field<string>("Nome"),
                    Email = usuarioEncontrado.Field<string>("Email"),
                    Cargo = usuarioEncontrado.Field<string>("Cargo"),
                    NivelAcesso = usuarioEncontrado.Field<int>("NivelAcesso"),
                    DataLogin = DateTime.Now,
                    Situacao = status?.Situacao,
                    DataStatus = status?.DataStatus ?? DateTime.Now,
                    DataMod = status?.DataMod,
                    AcessoLiberacao = status?.AcessoLiberacao ?? true,
                    NivelLiberacao = status?.NivelLiberacao ?? 1
                };

                var auditoriaDAL = new AuditoriaAcesso();
                auditoriaDAL.InserirAuditoria(new AuditoriaAcesso
                {
                    UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
                    Acao = "Login",
                    DataHora = DateTime.Now,
                    UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
                    Detalhes = "Login realizado com sucesso."
                });

                Loader.Color = Color.Green;
                await Task.Delay(500);
                Loader.Visible = false;
                btLogar.Enabled = true;

                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                Loader.Color = Color.Red;
                await Task.Delay(200);
                Loader.Visible = false;
                btLogar.Enabled = true;
                RadMessageBox.Show("Usuário ou senha inválidos.", "Erro", MessageBoxButtons.OK, RadMessageIcon.Error);
                txtSenha.Clear();
                txtSenha.Focus();
            }
        }
    }
}
