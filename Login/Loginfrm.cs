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

            // 2. Loader visual e desabilita botão
            Loader.Visible = true;
            btLogar.Enabled = false;

            string nomeUsuario = txtNome.Text.Trim();
            string senha = txtSenha.Text;
            DataTable dt = null;

            // 3. Consulta ao banco (assíncrono)
            await Task.Run(() => { dt = new Usuario("Admin").ConsultarUsuario(); });

            var usuarioEncontrado = dt.AsEnumerable()
                .FirstOrDefault(row => row.Field<string>("Nome") == nomeUsuario);

            // 4. Carrega status do usuário
            IUsuarioStatus status = null;
            if (usuarioEncontrado != null)
            {
                int usuarioId = usuarioEncontrado.Field<int>("UsuarioID");
                status = new UsuarioStatus("Admin").CarregarStatusUsuario(usuarioId);
            }

            // 5. Checa status antes de validar senha
            if (status == null || !string.Equals(status.Situacao, "Normal", StringComparison.OrdinalIgnoreCase))
            {
                Loader.Visible = false;
                btLogar.Enabled = true;
                string situacaoMsg = status?.Situacao ?? "Indefinido";
                RadMessageBox.Show(
                    $"Usuário com status '{situacaoMsg}'. Contate o administrador.",
                    "Acesso negado",
                    MessageBoxButtons.OK,
                    RadMessageIcon.Error
                );
                return;
            }

            // 6. Verifica senha (com suporte a hash e migração, se necessário)
            bool senhaValida = false;
            if (usuarioEncontrado != null)
            {
                string hashBanco = usuarioEncontrado.Field<string>("Senha");

                // Se usa hash antigo, migra (ajuste conforme seu padrão)
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

            // 7. Login bem-sucedido
            if (usuarioEncontrado != null && senhaValida && usuarioEncontrado.Field<bool>("Ativo"))
            {
                tentativas = 0; // Zera tentativas

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

                // Auditoria de login
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

                loginEfetuado = true;
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            else
            {
                tentativas++;

                Loader.Color = Color.Red;
                await Task.Delay(200);
                Loader.Visible = false;
                btLogar.Enabled = true;

                if (tentativas == 3 && usuarioEncontrado != null)
                {
                    // 8. Bloqueia o usuário após 3 tentativas
                    new UsuarioStatus("Admin").BloquearUsuario(usuarioEncontrado.Field<int>("UsuarioID"));

                    // Auditoria do bloqueio
                    var auditoriaDAL = new AuditoriaAcesso();
                    auditoriaDAL.InserirAuditoria(new AuditoriaAcesso
                    {
                        UsuarioID = usuarioEncontrado.Field<int>("UsuarioID"),
                        Acao = "Bloqueio",
                        DataHora = DateTime.Now,
                        UsuarioAplicacao = nomeUsuario,
                        Detalhes = "Usuário bloqueado após 3 tentativas inválidas de login."
                    });

                    RadMessageBox.Show("Usuário bloqueado após 3 tentativas inválidas. Contate o administrador.", "Acesso bloqueado", MessageBoxButtons.OK, RadMessageIcon.Error);

                    txtNome.Clear();
                    txtSenha.Clear();
                    txtNome.Focus();
                    tentativas = 0;
                    return;
                }
                else
                {
                    int restantes = 3 - tentativas;
                    RadMessageBox.Show($"Usuário ou senha inválidos. Tentativas restantes: {restantes}", "Erro", MessageBoxButtons.OK, RadMessageIcon.Error);
                    txtSenha.Clear();
                    txtSenha.Focus();
                }
            }
        }

    }
}
