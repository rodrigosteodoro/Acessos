using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acessos.Security;
using Bunifu.UI.WinForms;
using Telerik.WinControls;

namespace Acessos.Usuarios
{
    public partial class Usuariosfrm : Form
    {

        private int usuarioSelecionadoId = 0; // Campo para guardar o ID do usuário selecionado
        bool status = false; // Variável para controlar o status do usuário
        public Usuariosfrm()
        {
            InitializeComponent();
        }
        private void Usuariosfrm_Load(object sender, EventArgs e)
        {
            ConfigurarGrid(GridUsuarios);
            //
            var usuario = new Usuario("Admin");
            List<IUsuario> usuarios = usuario.ConsultarUsuarios();

            GridUsuarios.DataSource = usuarios;
        }
        public void ConfigurarGrid(Bunifu.UI.WinForms.BunifuDataGridView grid)
        {
            grid.Columns.Clear();

            // Coluna: UsuarioID
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UsuarioID",
                HeaderText = "ID",
                DataPropertyName = "UsuarioID",
                Width = 60,
                ReadOnly = true,
                Visible = false // Oculta a coluna ID por padrão
            });

            // Coluna: Nome
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 180,
                ReadOnly = true
            });

            // Coluna: Email
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Email",
                HeaderText = "E-mail",
                DataPropertyName = "Email",
                Width = 200,
                ReadOnly = true
            });

            // Coluna: Senha (opcional: ocultar por padrão)
            var colSenha = new DataGridViewTextBoxColumn
            {
                Name = "Senha",
                HeaderText = "Senha",
                DataPropertyName = "Senha",
                Width = 120,
                ReadOnly = true,
                Visible = false // Oculta por segurança
            };
            grid.Columns.Add(colSenha);

            // Coluna: Cargo
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Cargo",
                HeaderText = "Cargo",
                DataPropertyName = "Cargo",
                Width = 120,
                ReadOnly = true
            });

            // Coluna: DataCriacao
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DataCriacao",
                HeaderText = "Data de Criação",
                DataPropertyName = "DataCriacao",
                Width = 130,
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            // Coluna: Ativo
            grid.Columns.Add(new DataGridViewCheckBoxColumn
            {
                Name = "Ativo",
                HeaderText = "Ativo",
                DataPropertyName = "Ativo",
                Width = 60,
                ReadOnly = true
            });

            // Coluna: NivelAcesso
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NivelAcesso",
                HeaderText = "Nível de Acesso",
                DataPropertyName = "NivelAcesso",
                Width = 80,
                ReadOnly = true
            });

            // Configurações visuais recomendadas
            grid.EnableHeadersVisualStyles = false; // Permite customização do header
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.RowHeadersVisible = false;
            grid.AutoGenerateColumns = false;
            // Centralizar o conteúdo das células de todas as colunas
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void GridUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (GridUsuarios.SelectedRows.Count > 0)
            {
                var row = GridUsuarios.SelectedRows[0];

                // Preenche os campos do formulário com os valores da linha selecionada
                usuarioSelecionadoId = Convert.ToInt32(row.Cells["UsuarioID"].Value);
                txtNome.Text = row.Cells["Nome"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtSenha.Text = row.Cells["Senha"].Value?.ToString();
                cbCargo.SelectedItem = row.Cells["Cargo"].Value?.ToString();
                cbNivel.SelectedItem = row.Cells["NivelAcesso"].Value?.ToString();
                chkAtivo.Checked = Convert.ToBoolean(row.Cells["Ativo"].Value);
            }
            else
            {
                // Se nenhuma linha está selecionada, limpe os campos
                limparCampos();
                usuarioSelecionadoId = 0;
            }
        }

        private void limparCampos()
        {
            txtNome.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSenha.Text = string.Empty;
            cbCargo.SelectedIndex = -1;
            cbNivel.SelectedIndex = -1;
            chkAtivo.Checked = false;
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            // Validação simples
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text) ||
                cbCargo.SelectedIndex == -1 ||
                cbNivel.SelectedIndex == -1)
            {
                RadMessageBox.Show("Preencha todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK,RadMessageIcon.Info);
                return;
            }

            // Cria o objeto usuário
            if (chkAtivo.Checked == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            var usuario = new Usuario
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = HashSenhaManager.CriarHash(txtSenha.Text),
                Cargo = cbCargo.SelectedItem.ToString(),
                DataCriacao = DateTime.Now,
                Ativo = status,
                NivelAcesso = Convert.ToInt32(cbNivel.SelectedItem),
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual?.Nome ?? "Sistema" // Nome do usuário atual ou "Sistema" se não houver
            };


            var usuarioDAL = new Usuario("Admin");
            usuarioDAL.InserirUsuario(usuario);

            RadMessageBox.Show("Usuário salvo com sucesso!", "Sucesso", MessageBoxButtons.OK,RadMessageIcon.Info);
            limparCampos();
            // Atualize o grid
            var usuarios = usuarioDAL.ConsultarUsuarios();
            GridUsuarios.DataSource = usuarios;
            limparCampos();
        }

        private void btAtualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text) ||
                cbCargo.SelectedIndex == -1 ||
                cbNivel.SelectedIndex == -1)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int usuarioId = usuarioSelecionadoId;

            var usuarioDAL = new Usuario("Admin");
            if (chkAtivo.Checked == true)
            {
                status = true;
            }
            else
            {
                status = false;
            }
            usuarioDAL.AtualizarUsuario(
                usuarioId,
                txtNome.Text,
                txtEmail.Text,
                txtSenha.Text,
                cbCargo.SelectedItem.ToString(),
                status,
                Convert.ToInt32(cbNivel.SelectedItem),
                "Atualização por " + (SessaoUsuario.UsuarioAtual?.Nome ?? "Sistema")
            );
            //string nome, string email, string senha, string cargo,bool ativo, int nivelacesso, string usuarioaplicacao)

            MessageBox.Show("Usuário atualizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limparCampos();
            // Atualize o grid
            var usuarios = usuarioDAL.ConsultarUsuarios();
            GridUsuarios.DataSource = usuarios;
            limparCampos();
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {           
            var usuario = new Usuario
            {
                UsuarioID= usuarioSelecionadoId,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual?.Nome ?? "Sistema" // Nome do usuário atual ou "Sistema" se não houver
            };
            var usuarioDAL = new Usuario("Admin");

            usuarioDAL.ExcluirUsuario(usuarioSelecionadoId, SessaoUsuario.UsuarioAtual?.Nome ?? "Sistema");

            RadMessageBox.Show("Usuário excluído com sucesso!", "Sucesso", MessageBoxButtons.OK,RadMessageIcon.Info );
            limparCampos();
            // Atualize o grid
            var usuarios = usuarioDAL.ConsultarUsuarios();
            GridUsuarios.DataSource = usuarios;
            limparCampos();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            limparCampos();
            btAtualizar.Enabled = true;
            btExcluir.Enabled = true;
            btSalvar.Enabled = true;           
            // Habilita os campos para edição
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtSenha.Enabled = true;
            cbCargo.Enabled = true;
            cbNivel.Enabled = true;
            chkAtivo.Enabled = true;
            GridUsuarios.Enabled = true;
        }

        private void btDesbloquear_Click(object sender, EventArgs e)
        {
            // Verifique se há um usuário selecionado no grid
            if (GridUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um usuário para desbloquear.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Pegue o ID do usuário selecionado
            int usuarioId = Convert.ToInt32(GridUsuarios.SelectedRows[0].Cells["UsuarioID"].Value);

            // Chame o método para ativar o usuário
            var usuario = new UsuarioStatus("Admin");
            usuario.AtivarUsuario(usuarioId);

            MessageBox.Show("Usuário desbloqueado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //"INSERT INTO usuarioStatus (UsuarioID, Situacao, DataStatus, AcessoLiberacao, NivelLiberacao) VALUES (@UsuarioID, 'Ativo', @DataStatus, 1, 1)", conn))
        }

    }
}
