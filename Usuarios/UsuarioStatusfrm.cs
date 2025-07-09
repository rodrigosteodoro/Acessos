using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;

namespace Acessos.Usuarios
{
    public partial class UsuarioStatusfrm : Telerik.WinControls.UI.RadForm
    {
        private int usuarioSelecionadoId = 0;

        public UsuarioStatusfrm(int usuarioId)
        {
            InitializeComponent();
            usuarioSelecionadoId = usuarioId;
        }

        private void UsuarioStatusfrm_Load(object sender, EventArgs e)
        {
            ConfigurarGrid(GridStatus);
            AtualizarGrid();
            GridStatus.CellFormatting += GridStatus_CellFormatting;
            GridStatus.SelectionChanged += GridStatus_SelectionChanged;
        }

        /// <summary>
        /// Atualiza o grid com dados do usuário selecionado ou de todos, se nenhum selecionado.
        /// </summary>
        private void AtualizarGrid()
        {
            var usuario = new Usuario("Admin");
            DataTable dados = usuarioSelecionadoId > 0
                ? usuario.ConsultarUsuario(usuarioSelecionadoId)
                : usuario.ConsultarUsuario();

            GridStatus.DataSource = dados ?? new DataTable();
        }

        /// <summary>
        /// Configura as colunas e visual do grid.
        /// </summary>
        public void ConfigurarGrid(Bunifu.UI.WinForms.BunifuDataGridView grid)
        {
            grid.Columns.Clear();

            var colunas = new List<DataGridViewColumn>
            {
                new DataGridViewTextBoxColumn { Name = "UsuarioID", HeaderText = "ID", DataPropertyName = "UsuarioID", Width = 60, ReadOnly = true, Visible = false },
                new DataGridViewTextBoxColumn { Name = "Nome", HeaderText = "Nome", DataPropertyName = "Nome", Width = 180, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Cargo", HeaderText = "Cargo", DataPropertyName = "Cargo", Width = 120, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "DataCriacao", HeaderText = "Criação", DataPropertyName = "DataCriacao", Width = 130, ReadOnly = true, DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" } },
                new DataGridViewCheckBoxColumn { Name = "Ativo", HeaderText = "Ativo", DataPropertyName = "Ativo", Width = 60, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "NivelAcesso", HeaderText = "Nível", DataPropertyName = "NivelAcesso", Width = 80, ReadOnly = true },
                new DataGridViewTextBoxColumn { Name = "Situacao", HeaderText = "Situação", DataPropertyName = "Situacao", Width = 80, ReadOnly = true }
            };

            grid.Columns.AddRange(colunas.ToArray());

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            grid.RowHeadersVisible = false;
            grid.AutoGenerateColumns = false;

            foreach (DataGridViewColumn col in grid.Columns)
                col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        /// <summary>
        /// Formata a cor da célula conforme o status.
        /// </summary>
        private void GridStatus_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var grid = sender as DataGridView;
            if (grid.Columns[e.ColumnIndex].Name == "Situacao" && e.Value != null)
            {
                string status = e.Value.ToString().ToLowerInvariant();
                switch (status)
                {
                    case "normal":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "bloqueado":
                        e.CellStyle.BackColor = Color.IndianRed;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "inativo":
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "suspenso":
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    default:
                        e.CellStyle.BackColor = Color.White;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        /// <summary>
        /// Atualiza o id do usuário selecionado ao trocar a seleção no grid.
        /// </summary>
        private void GridStatus_SelectionChanged(object sender, EventArgs e)
        {
            if (GridStatus.SelectedRows.Count > 0)
            {
                var row = GridStatus.SelectedRows[0];
                usuarioSelecionadoId = Convert.ToInt32(row.Cells["UsuarioID"].Value);
            }
            else
            {
                usuarioSelecionadoId = 0;
            }
        }

        /// <summary>
        /// Método genérico para atualizar o status do usuário.
        /// </summary>
        private void AtualizarStatusUsuario(string situacao, string detalhes)
        {
            if (usuarioSelecionadoId <= 0)
            {
                MessageBox.Show("Nenhum usuário selecionado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var usuario = new Usuario("Admin")
            {
                UsuarioID = usuarioSelecionadoId,
                NivelAcesso = SessaoUsuario.UsuarioAtual?.NivelAcesso ?? 4,
                UsuarioAplicacao = SessaoUsuario.UsuarioAtual?.Nome ?? "Sistema",
                Situacao = situacao,
                Detalhes = detalhes
            };

            usuario.AtualizarUsuario(usuario);
            MessageBox.Show($"Usuário definido como {situacao}!");
            AtualizarGrid();
        }

        // Botões de status
        private void btNormal_Click(object sender, EventArgs e) =>
            AtualizarStatusUsuario("Normal", "Usuário definido status como Normal por admin");

        private void btInativo_Click(object sender, EventArgs e) =>
            AtualizarStatusUsuario("Inativo", "Usuário definido status como Inativo por admin");

        private void btBloqueado_Click(object sender, EventArgs e) =>
            AtualizarStatusUsuario("Bloqueado", "Usuário definido status como Bloqueado por admin");

        private void btSuspenso_Click(object sender, EventArgs e) =>
            AtualizarStatusUsuario("Suspenso", "Usuário definido status como Suspenso por admin");

        // Botão para recarregar a lista de usuários
        private void btAtualizar_Click(object sender, EventArgs e) => AtualizarGrid();
    }
}
