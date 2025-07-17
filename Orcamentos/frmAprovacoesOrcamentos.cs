using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace Acessos
{
    public partial class frmAprovacoesOrcamentos : RadForm
    {
        private readonly OrcamentoRepository _orcamentoRepository = new OrcamentoRepository();
        private BindingList<OrcamentoAprovacaoModel> _orcamentos;
        private string _codigoOrcamentoFiltro;

        public frmAprovacoesOrcamentos(string codigoOrcamento = null)
        {
            InitializeComponent();
            _codigoOrcamentoFiltro = codigoOrcamento;
            _orcamentos = new BindingList<OrcamentoAprovacaoModel>();
        }

        private async void frmAprovacoesOrcamentos_Load(object sender, EventArgs e)
        {
            try
            {
                ConfigurarInterface();
                CarregarFiltros();
                await CarregarDados();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Erro ao carregar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
        }

        private void ConfigurarInterface()
        {
            // Configurar tema
            ThemeName = "Fluent";

            // Configurar grid
            dgvOrcamentosPendentes.AutoGenerateColumns = false;
            dgvOrcamentosPendentes.DataSource = _orcamentos;
            dgvOrcamentosPendentes.EnableFiltering = true;
            dgvOrcamentosPendentes.EnableGrouping = false;
            dgvOrcamentosPendentes.MasterTemplate.AllowAddNewRow = false;
            dgvOrcamentosPendentes.MasterTemplate.AllowDeleteRow = false;
            dgvOrcamentosPendentes.MasterTemplate.AllowEditRow = false;
            dgvOrcamentosPendentes.MasterTemplate.AutoSizeColumnsMode = GridViewAutoSizeColumnsMode.Fill;

            // Configurar colunas
            dgvOrcamentosPendentes.Columns.Clear();

            var colId = new GridViewTextBoxColumn("ID");
            colId.HeaderText = "ID";
            colId.Width = 60;
            colId.IsVisible = false;
            dgvOrcamentosPendentes.Columns.Add(colId);

            var colCodigo = new GridViewTextBoxColumn("CodigoOrcamento");
            colCodigo.HeaderText = "Código";
            colCodigo.Width = 100;
            dgvOrcamentosPendentes.Columns.Add(colCodigo);

            var colCliente = new GridViewTextBoxColumn("NomeCliente");
            colCliente.HeaderText = "Cliente";
            colCliente.Width = 200;
            dgvOrcamentosPendentes.Columns.Add(colCliente);

            var colCpfCnpj = new GridViewTextBoxColumn("CPFCNPJ");
            colCpfCnpj.HeaderText = "CPF/CNPJ";
            colCpfCnpj.Width = 120;
            dgvOrcamentosPendentes.Columns.Add(colCpfCnpj);

            var colData = new GridViewDateTimeColumn("DataCriacao");
            colData.HeaderText = "Data";
            colData.Width = 90;
            colData.Format = DateTimePickerFormat.Short;
            dgvOrcamentosPendentes.Columns.Add(colData);

            var colValor = new GridViewDecimalColumn("ValorTotal");
            colValor.HeaderText = "Valor Total";
            colValor.Width = 100;
            colValor.FormatString = "{0:C2}";
            colValor.TextAlignment = ContentAlignment.MiddleRight;
            dgvOrcamentosPendentes.Columns.Add(colValor);

            var colStatus = new GridViewTextBoxColumn("StatusDescricao");
            colStatus.HeaderText = "Status";
            colStatus.Width = 120;
            dgvOrcamentosPendentes.Columns.Add(colStatus);

            // Configurar botões
            btnAprovar.Enabled = false;
            btnRejeitar.Enabled = false;
            btnDetalhes.Enabled = false;
        }

        private void CarregarFiltros()
        {
            cmbFiltroStatus.Items.Clear();
            cmbFiltroStatus.Items.Add("Todos");
            cmbFiltroStatus.Items.Add("Aguardando Aprovação");
            cmbFiltroStatus.Items.Add("Aprovado");
            cmbFiltroStatus.Items.Add("Rejeitado");
            cmbFiltroStatus.SelectedIndex = 1; // "Aguardando Aprovação"

            dtpDataInicio.Value = DateTime.Now.AddDays(-30);
            dtpDataFim.Value = DateTime.Now;
        }

        private async Task CarregarDados()
        {
            try
            {
                progressBar.Visible = true;
                progressBar.StartWaiting();

                string statusFiltro = cmbFiltroStatus.SelectedItem?.ToString();
                DateTime dataInicio = dtpDataInicio.Value.Date;
                DateTime dataFim = dtpDataFim.Value.Date.AddDays(1).AddTicks(-1);

                var dados = await _orcamentoRepository.ObterOrcamentosParaAprovacaoAsync(
                    statusFiltro == "Aguardando Aprovação" ? (int)StatusOrcamento.Pendente :
                    statusFiltro == "Aprovado" ? (int)StatusOrcamento.Aprovado :
                    statusFiltro == "Rejeitado" ? (int)StatusOrcamento.Rejeitado : (int?)null,
                    dataInicio, dataFim
                );

                if (!string.IsNullOrEmpty(_codigoOrcamentoFiltro))
                {
                    dados = dados.Where(o => o.CodigoOrcamento == _codigoOrcamentoFiltro).ToList();
                }

                // Atualizar lista vinculada
                _orcamentos.Clear();
                foreach (var item in dados)
                {
                    _orcamentos.Add(item);
                }

                AtualizarEstatisticas();
            }
            catch (Exception ex)
            {
                RadMessageBox.Show($"Erro ao carregar orçamentos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
            }
            finally
            {
                progressBar.StopWaiting();
                progressBar.Visible = false;
            }
        }

        private void AtualizarEstatisticas()
        {
            int pendentes = _orcamentos.Count(o => o.Status == (int)StatusOrcamento.Pendente);
            decimal valorTotal = _orcamentos
                .Where(o => o.Status == (int)StatusOrcamento.Pendente)
                .Sum(o => o.ValorTotal);

            lblTotalPendentes.Text = $"Orçamentos pendentes: {pendentes}";
            lblValorTotal.Text = $"Valor total pendente: {valorTotal:C2}";
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await CarregarDados();
        }

        private void btnLimparFiltros_Click(object sender, EventArgs e)
        {
            cmbFiltroStatus.SelectedIndex = 1;
            dtpDataInicio.Value = DateTime.Now.AddDays(-30);
            dtpDataFim.Value = DateTime.Now;
            CarregarDados().GetAwaiter();
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarDados().GetAwaiter();
        }

        private async void btnAprovar_Click(object sender, EventArgs e)
        {
            if (dgvOrcamentosPendentes.CurrentRow == null)
            {
                RadMessageBox.Show("Selecione um orçamento para aprovar", "Aviso",
                    MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            var orcamento = ObterOrcamentoSelecionado();
            if (orcamento == null) return;

            if (RadMessageBox.Show(
                $"Confirma aprovação do orçamento {orcamento.CodigoOrcamento}?",
                "Confirmar Aprovação",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _orcamentoRepository.AtualizarStatusOrcamentoAsync(orcamento.ID, StatusOrcamento.Aprovado);

                    // Atualizar item local
                    orcamento.Status = (int)StatusOrcamento.Aprovado;
                    orcamento.StatusDescricao = "Aprovado";

                    dgvOrcamentosPendentes.Refresh();
                    AtualizarEstatisticas();

                    RadMessageBox.Show("Orçamento aprovado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show($"Erro ao aprovar orçamento: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private async void btnRejeitar_Click(object sender, EventArgs e)
        {
            if (dgvOrcamentosPendentes.CurrentRow == null)
            {
                RadMessageBox.Show("Selecione um orçamento para rejeitar", "Aviso",
                    MessageBoxButtons.OK, RadMessageIcon.Exclamation);
                return;
            }

            var orcamento = ObterOrcamentoSelecionado();
            if (orcamento == null) return;

            if (RadMessageBox.Show(
                $"Confirma rejeição do orçamento {orcamento.CodigoOrcamento}?",
                "Confirmar Rejeição",
                MessageBoxButtons.YesNo,
                RadMessageIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    await _orcamentoRepository.AtualizarStatusOrcamentoAsync(orcamento.ID, StatusOrcamento.Rejeitado);

                    // Atualizar item local
                    orcamento.Status = (int)StatusOrcamento.Rejeitado;
                    orcamento.StatusDescricao = "Rejeitado";

                    dgvOrcamentosPendentes.Refresh();
                    AtualizarEstatisticas();

                    RadMessageBox.Show("Orçamento rejeitado!", "Sucesso",
                        MessageBoxButtons.OK, RadMessageIcon.Info);
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show($"Erro ao rejeitar orçamento: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, RadMessageIcon.Error);
                }
            }
        }

        private async void btnDetalhes_Click(object sender, EventArgs e)
        {
            await VisualizarOrcamentoSelecionadoAsync();
        }

        private async void dgvOrcamentosPendentes_DoubleClick(object sender, EventArgs e)
        {
            await VisualizarOrcamentoSelecionadoAsync();
        }

        private async Task VisualizarOrcamentoSelecionadoAsync()
        {
            var orcamentoModel = ObterOrcamentoSelecionado();
            if (orcamentoModel == null) return;

            var orcamentoCompleto = await _orcamentoRepository.ObterOrcamentoPorIdAsync(orcamentoModel.ID);

            if (orcamentoCompleto == null)
            {
                RadMessageBox.Show("Orçamento não encontrado", "Erro",
                    MessageBoxButtons.OK, RadMessageIcon.Error);
                return;
            }

            using (var frmDetalhes = new frmVisualizarOrcamento((Orcamento)orcamentoCompleto))
            {
                frmDetalhes.ShowDialog();
            }
        }

        private OrcamentoAprovacaoModel ObterOrcamentoSelecionado()
        {
            if (dgvOrcamentosPendentes.CurrentRow == null) return null;

            int id = Convert.ToInt32(dgvOrcamentosPendentes.CurrentRow.Cells["ID"].Value);
            return _orcamentos.FirstOrDefault(o => o.ID == id);
        }

        private void dgvOrcamentosPendentes_SelectionChanged(object sender, EventArgs e)
        {
            bool temSelecao = dgvOrcamentosPendentes.SelectedRows.Count > 0;
            btnAprovar.Enabled = temSelecao;
            btnRejeitar.Enabled = temSelecao;
            btnDetalhes.Enabled = temSelecao;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
