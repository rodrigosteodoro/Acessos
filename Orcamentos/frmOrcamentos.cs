using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Acessos;
using Telerik.WinControls.UI;

namespace  Acessos
{
    public partial class frmOrcamentos : Telerik.WinControls.UI.RadForm
    {
        private OrcamentoRepository repository;
        private Orcamento orcamentoAtual;
        private List<Produto> produtosDisponiveis;

        public frmOrcamentos()
        {
            InitializeComponent();
            repository = new OrcamentoRepository();
            orcamentoAtual = new Orcamento();
        }

        private void frmOrcamentos_Load(object sender, EventArgs e)
        {
            CarregarProdutosDisponiveis();
            ConfigurarGrids();
            NovoOrcamento();
        }

        private async void CarregarProdutosDisponiveis()
        {
            try
            {
                // Aguarde a task finalizar para receber a lista de produtos
                var produtosDisponiveis = await repository.ObterProdutosDisponiveisAsync();

                // Criar uma lista simplificada para exibição
                var produtosExibicao = produtosDisponiveis.Select(p => new
                {
                    p.ID,
                    p.CodigoProduto,
                    p.Nome,
                    p.Descricao,
                    PrecoAtual = p.PromocaoAtiva && p.PrecoPromocional.HasValue ? p.PrecoPromocional.Value : p.PrecoVenda,
                    p.UnidadeMedida,
                    p.QuantidadeAtual
                }).ToList();

                dgvItensDisponiveis.DataSource = produtosExibicao;

                // Remover a coluna "ID" se ela existir
                if (dgvItensDisponiveis.Columns["ID"] != null)
                    dgvItensDisponiveis.Columns.Remove("ID");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar produtos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrids()
        {
            // Configurar grid de produtos disponíveis
            dgvItensDisponiveis.AutoGenerateColumns = true;
            dgvItensDisponiveis.ReadOnly = true;
            dgvItensDisponiveis.SelectionMode = GridViewSelectionMode.FullRowSelect;

            // Configurar grid de itens do orçamento
            dgvItensOrcamento.AutoGenerateColumns = false;
            dgvItensOrcamento.Columns.Clear();

            dgvItensOrcamento.Columns.Add(new GridViewTextBoxColumn("DescricaoProduto") { HeaderText = "Produto", Width = 200 });
            dgvItensOrcamento.Columns.Add(new GridViewDecimalColumn("Quantidade") { HeaderText = "Qtd", Width = 80 });
            dgvItensOrcamento.Columns.Add(new GridViewDecimalColumn("PrecoUnitario") { HeaderText = "Preço Unit.", Width = 100, FormatString = "{0:C2}" });
            dgvItensOrcamento.Columns.Add(new GridViewDecimalColumn("Desconto") { HeaderText = "Desc. %", Width = 80 });
            dgvItensOrcamento.Columns.Add(new GridViewDecimalColumn("Total") { HeaderText = "Total", Width = 100, FormatString = "{0:C2}", ReadOnly = true });
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            NovoOrcamento();
        }

        private void NovoOrcamento()
        {
            orcamentoAtual = new Orcamento
            {
                CodigoOrcamento = GerarCodigoOrcamento(),
                DataCriacao = DateTime.Now,
                Status = StatusOrcamento.Novo
            };

            LimparCampos();
            AtualizarInterface();
        }

        private string GerarCodigoOrcamento()
        {
            return $"ORC{DateTime.Now:yyyyMMddHHmmss}";
        }

        private void LimparCampos()
        {
            txtCodigoOrcamento.Text = orcamentoAtual.CodigoOrcamento;
            txtNomeCliente.Text = "";
            txtCPF_CNPJ.Text = "";
            txtDesconto.Value = 0;
            txtObservacoes.Text = "";

            AtualizarGridItens();
            CalcularTotal();
        }

        private void BtnAdicionarItem_Click(object sender, EventArgs e)
        {
            if (dgvItensDisponiveis.CurrentRow?.DataBoundItem != null)
            {
                var produtoSelecionado = dgvItensDisponiveis.CurrentRow.DataBoundItem;
                var produtoId = (int)produtoSelecionado.GetType().GetProperty("ID").GetValue(produtoSelecionado);
                var produto = produtosDisponiveis.FirstOrDefault(p => p.ID == produtoId);

                if (produto != null)
                {
                    var precoAtual = produto.PromocaoAtiva && produto.PrecoPromocional.HasValue
                        ? produto.PrecoPromocional.Value
                        : produto.PrecoVenda;

                    var itemOrcamento = new ItemOrcamento
                    {
                        ProdutoID = produto.ID,
                        DescricaoProduto = $"{produto.CodigoProduto} - {produto.Nome}",
                        Quantidade = 1,
                        PrecoUnitario = precoAtual
                    };

                    orcamentoAtual.Itens.Add(itemOrcamento);
                    AtualizarGridItens();
                    CalcularTotal();
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto para adicionar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemoverItem_Click(object sender, EventArgs e)
        {
            if (dgvItensOrcamento.CurrentRow?.DataBoundItem is ItemOrcamento item)
            {
                orcamentoAtual.Itens.Remove(item);
                AtualizarGridItens();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show("Selecione um item para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void AtualizarGridItens()
        {
            dgvItensOrcamento.DataSource = null;
            dgvItensOrcamento.DataSource = orcamentoAtual.Itens.Where(i => i.Ativo).ToList();
        }

        private void CalcularTotal()
        {
            lblSubtotal.Text = $"Subtotal: {orcamentoAtual.Subtotal:C2}";
            lblDesconto.Text = $"Desconto: {orcamentoAtual.ValorDesconto:C2}";
            lblTotal.Text = $"Total: {orcamentoAtual.ValorTotal:C2}";
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtDesconto.Text, out decimal desconto))
            {
                orcamentoAtual.DescontoGeral = desconto;
                CalcularTotal();
            }
        }

        private void dgvItensOrcamento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CalcularTotal();
        }

        private async void BtnSalvarOrcamento_Click(object sender, EventArgs e)
        {
            if (ValidarOrcamento())
            {
                try
                {
                    orcamentoAtual.Observacoes = txtObservacoes.Text;
                    orcamentoAtual.UltimaModificacao = DateTime.Now;

                    int id = await repository.InserirOrcamentoAsync(orcamentoAtual); // aguarde o Task<int>

                    MessageBox.Show($"Orçamento salvo com sucesso! ID: {id}", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    orcamentoAtual.ID = id;
                    AtualizarInterface();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar orçamento: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private bool ValidarOrcamento()
        {
            if (orcamentoAtual.ClienteID == 0)
            {
                MessageBox.Show("Selecione um cliente para o orçamento.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!orcamentoAtual.Itens.Any(i => i.Ativo))
            {
                MessageBox.Show("Adicione pelo menos um item ao orçamento.", "Validação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private async void BtnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                // Aguarde a lista de clientes
                var clientes = await repository.BuscarClientesAsync(); // Implemente esse método no repository

                if (clientes.Any())
                {
                    using (var formSelecao = new FormSelecaoCliente(clientes.ToList()))
                    {
                        if (formSelecao.ShowDialog() == DialogResult.OK && formSelecao.ClienteSelecionado != null)
                        {
                            PreencherDadosCliente(formSelecao.ClienteSelecionado);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nenhum cliente encontrado no sistema.", "Informação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao buscar clientes: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PreencherDadosCliente(Cliente cliente)
        {
            orcamentoAtual.ClienteID = cliente.ID;
            orcamentoAtual.Cliente = cliente;

            txtNomeCliente.Text = cliente.Nome;
            txtCPF_CNPJ.Text = cliente.CPFCNPJ;
        }

        private void BtnSolicitarAprovacao_Click(object sender, EventArgs e)
        {
            // Validar se o orçamento foi salvo
            if (orcamentoAtual.ID <= 0)
            {
                Microsoft.VisualBasic.Interaction.MsgBox(
                    "⚠️ ORÇAMENTO NÃO SALVO\n\n" +
                    "Para solicitar aprovação é necessário\n" +
                    "salvar o orçamento primeiro.\n\n" +
                    "🔄 Clique em 'Salvar Orçamento'\n" +
                    "e tente solicitar aprovação novamente.",
                    Microsoft.VisualBasic.MsgBoxStyle.Exclamation,
                    "Salvar Antes de Solicitar Aprovação");
                return;
            }

            // Validar se o orçamento tem itens
            if (!orcamentoAtual.Itens.Any(i => i.Ativo))
            {
                Microsoft.VisualBasic.Interaction.MsgBox(
                    "⚠️ ORÇAMENTO SEM ITENS\n\n" +
                    "Não é possível solicitar aprovação\n" +
                    "para um orçamento sem itens.\n\n" +
                    "📦 Adicione pelo menos um produto\n" +
                    "antes de solicitar aprovação.",
                    Microsoft.VisualBasic.MsgBoxStyle.Exclamation,
                    "Adicionar Itens");
                return;
            }

            // Validar se o cliente está selecionado
            if (orcamentoAtual.ClienteID <= 0)
            {
                Microsoft.VisualBasic.Interaction.MsgBox(
                    "⚠️ CLIENTE NÃO SELECIONADO\n\n" +
                    "É necessário selecionar um cliente\n" +
                    "antes de solicitar aprovação.\n\n" +
                    "👤 Clique em 'Buscar Cliente'\n" +
                    "e selecione um cliente válido.",
                    Microsoft.VisualBasic.MsgBoxStyle.Exclamation,
                    "Selecionar Cliente");
                return;
            }

            // Validar se o status permite solicitação de aprovação
            if (orcamentoAtual.Status != StatusOrcamento.Novo)
            {
                Microsoft.VisualBasic.Interaction.MsgBox(
                    $"⚠️ STATUS INVÁLIDO\n\n" +
                    $"Orçamento está com status: {ObterDescricaoStatus(orcamentoAtual.Status)}\n\n" +
                    "Apenas orçamentos com status 'Novo'\n" +
                    "podem ser enviados para aprovação.",
                    Microsoft.VisualBasic.MsgBoxStyle.Exclamation,
                    "Status Não Permite Aprovação");
                return;
            }

            // Confirmar solicitação de aprovação
            var resultado = Microsoft.VisualBasic.Interaction.MsgBox(
                $"📋 SOLICITAR APROVAÇÃO\n\n" +
                $"Orçamento: {orcamentoAtual.CodigoOrcamento}\n" +
                $"Cliente: {orcamentoAtual.Cliente?.Nome ?? "Não informado"}\n" +
                $"Valor Total: {orcamentoAtual.ValorTotal:C2}\n" +
                $"Itens: {orcamentoAtual.Itens.Count(i => i.Ativo)} produto(s)\n\n" +
                "Deseja enviar este orçamento para aprovação?\n\n" +
                "⚠️ Após enviar, não será possível editar\n" +
                "até que seja aprovado ou rejeitado.",
                Microsoft.VisualBasic.MsgBoxStyle.Question | Microsoft.VisualBasic.MsgBoxStyle.YesNo,
                "Confirmar Solicitação");

            if (resultado == Microsoft.VisualBasic.MsgBoxResult.Yes)
            {
                try
                {
                    // Atualizar apenas o status no banco de dados
                    AtualizarStatusOrcamento(orcamentoAtual.ID, StatusOrcamento.Pendente);

                    // Atualizar o objeto local
                    orcamentoAtual.Status = StatusOrcamento.Pendente;
                    orcamentoAtual.UltimaModificacao = DateTime.Now;

                    // Criar notificação para aprovadores
                    CriarNotificacaoAprovacao();

                    // Atualizar interface
                    AtualizarInterface();

                    // Notificação de sucesso
                    Microsoft.VisualBasic.Interaction.MsgBox(
                        "✅ SOLICITAÇÃO ENVIADA!\n\n" +
                        "📤 O orçamento foi enviado para aprovação\n" +
                        "🔔 Os aprovadores foram notificados\n" +
                        "⏳ Aguarde a análise e retorno\n\n" +
                        "💡 Você será notificado quando houver\n" +
                        "uma resposta sobre a aprovação.",
                        Microsoft.VisualBasic.MsgBoxStyle.Information,
                        "Enviado para Aprovação");
                }
                catch (Exception ex)
                {
                    Microsoft.VisualBasic.Interaction.MsgBox(
                        $"❌ ERRO AO SOLICITAR APROVAÇÃO\n\n" +
                        $"Detalhes: {ex.Message}\n\n" +
                        "Tente novamente ou contate o suporte.",
                        Microsoft.VisualBasic.MsgBoxStyle.Critical,
                        "Erro no Sistema");
                }
            }
        }

        // Método para atualizar apenas o status sem recriar o orçamento
        private void AtualizarStatusOrcamento(int orcamentoId, StatusOrcamento novoStatus)
        {
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                var sql = @"UPDATE Orcamentos 
                   SET Status = @status, 
                       UltimaModificacao = @ultimaModificacao 
                   WHERE ID = @id AND Ativo = 1";

                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@status", (int)novoStatus);
                    command.Parameters.AddWithValue("@ultimaModificacao", DateTime.Now);
                    command.Parameters.AddWithValue("@id", orcamentoId);

                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new InvalidOperationException("Orçamento não encontrado ou não pôde ser atualizado.");
                    }
                }
            }
        }

        // Método para criar notificação de aprovação
        private void CriarNotificacaoAprovacao()
        {
            try
            {
                using (var connection = new SqlConnection(ConnectionManager.GetConnectionString()))
                {
                    var sql = @"INSERT INTO NotificacoesAprovacao 
                       (OrcamentoID, TipoNotificacao, Mensagem, DataCriacao, Lida, Ativa)
                       VALUES (@orcamentoId, @tipo, @mensagem, @dataCriacao, @lida, @ativa)";

                    using (var command = new SqlCommand(sql, connection))
                    {
                        var mensagem = $"Novo orçamento aguardando aprovação: {orcamentoAtual.CodigoOrcamento} - " +
                                      $"Cliente: {orcamentoAtual.Cliente?.Nome} - " +
                                      $"Valor: {orcamentoAtual.ValorTotal:C2}";

                        command.Parameters.AddWithValue("@orcamentoId", orcamentoAtual.ID);
                        command.Parameters.AddWithValue("@tipo", "APROVACAO_PENDENTE");
                        command.Parameters.AddWithValue("@mensagem", mensagem);
                        command.Parameters.AddWithValue("@dataCriacao", DateTime.Now);
                        command.Parameters.AddWithValue("@lida", false);
                        command.Parameters.AddWithValue("@ativa", true);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log do erro, mas não interrompe o processo
                System.Diagnostics.Debug.WriteLine($"Erro ao criar notificação: {ex.Message}");
            }
        }     
        //criar sistema de verificacao de usuário para impor politicas de aprovação
        private async Task BtnAprovarOrcamento_Click(object sender, EventArgs e)
        {
            if (orcamentoAtual.ID > 0)
            {
                orcamentoAtual.Status = StatusOrcamento.Aprovado;
             await   repository.InserirOrcamentoAsync(orcamentoAtual);
                AtualizarInterface();
                MessageBox.Show("Orçamento aprovado!", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async Task BtnRejeitarOrcamento_Click(object sender, EventArgs e)
        {
            if (orcamentoAtual.ID > 0)
            {
                orcamentoAtual.Status = StatusOrcamento.Rejeitado;
            await    repository.InserirOrcamentoAsync(orcamentoAtual);
                AtualizarInterface();
                MessageBox.Show("Orçamento rejeitado!", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AtualizarInterface()
        {
            lblStatusOrcamento.Text = $"Status: {orcamentoAtual.Status}";

            // Habilitar/desabilitar botões baseado no status
            var isNovo = orcamentoAtual.Status == StatusOrcamento.Novo;
            var isPendente = orcamentoAtual.Status == StatusOrcamento.Pendente;

            btnSalvarOrcamento.Enabled = isNovo;
            btnAdicionarItem.Enabled = isNovo;
            btnRemoverItem.Enabled = isNovo;
            btnSolicitarAprovacao.Enabled = isNovo && orcamentoAtual.ID > 0;
            btnAprovarOrcamento.Enabled = isPendente;
            btnRejeitarOrcamento.Enabled = isPendente;

            dgvItensOrcamento.ReadOnly = !isNovo;
        }

        private void BtnNovoCliente_Click(object sender, EventArgs e)
        {
            FormManager.ShowForm<frmClientes>();
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (orcamentoAtual.ID > 0)
            {
                try
                {
                    // Mostrar notificação de início
                    Microsoft.VisualBasic.Interaction.MsgBox(
                        "Gerando relatório para impressão...\n\nAguarde enquanto o arquivo é criado.",
                        Microsoft.VisualBasic.MsgBoxStyle.Information | Microsoft.VisualBasic.MsgBoxStyle.OkOnly,
                        "Gerando Relatório");

                    // Gerar HTML e abrir no navegador
                    string caminhoArquivo = GerarRelatorioHTML();

                    if (!string.IsNullOrEmpty(caminhoArquivo))
                    {
                        // Abrir no navegador padrão
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = caminhoArquivo,
                            UseShellExecute = true
                        });

                        // Notificação de sucesso
                        Microsoft.VisualBasic.Interaction.MsgBox(
                            "✅ Relatório gerado com sucesso!\n\n" +
                            "📄 O orçamento foi aberto no seu navegador padrão.\n" +
                            "🖨️ Use Ctrl+P para imprimir ou salvar como PDF.\n\n" +
                            $"📂 Arquivo salvo em: {Path.GetFileName(caminhoArquivo)}",
                            Microsoft.VisualBasic.MsgBoxStyle.Information | Microsoft.VisualBasic.MsgBoxStyle.OkOnly,
                            "Relatório Pronto para Impressão");
                    }
                }
                catch (Exception ex)
                {
                    // Notificação de erro
                    Microsoft.VisualBasic.Interaction.MsgBox(
                        $"❌ Erro ao gerar relatório:\n\n{ex.Message}\n\n" +
                        "Tente novamente ou entre em contato com o suporte técnico.",
                        Microsoft.VisualBasic.MsgBoxStyle.Critical | Microsoft.VisualBasic.MsgBoxStyle.OkOnly,
                        "Erro na Geração do Relatório");
                }
            }
            else
            {
                // Notificação de validação
                Microsoft.VisualBasic.Interaction.MsgBox(
                    "⚠️ Atenção!\n\n" +
                    "É necessário salvar o orçamento antes de imprimir.\n\n" +
                    "Clique em 'Salvar' e tente novamente.",
                    Microsoft.VisualBasic.MsgBoxStyle.Exclamation | Microsoft.VisualBasic.MsgBoxStyle.OkOnly,
                    "Orçamento Não Salvo");
            }
        }

        private string GerarRelatorioHTML()
        {
            try
            {
                // Criar diretório temporário se não existir
                string diretorioTemp = Path.Combine(Path.GetTempPath(), "RelatoriosOrcamento");
                if (!Directory.Exists(diretorioTemp))
                    Directory.CreateDirectory(diretorioTemp);

                // Nome do arquivo
                string nomeArquivo = $"Orcamento_{orcamentoAtual.CodigoOrcamento}_{DateTime.Now:yyyyMMdd_HHmmss}.html";
                string caminhoCompleto = Path.Combine(diretorioTemp, nomeArquivo);

                // Gerar conteúdo HTML
                string htmlContent = GerarConteudoHTML();

                // Salvar arquivo
                File.WriteAllText(caminhoCompleto, htmlContent, System.Text.Encoding.UTF8);

                return caminhoCompleto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao gerar arquivo HTML: {ex.Message}", ex);
            }
        }

        private string GerarConteudoHTML()
        {
            var html = new System.Text.StringBuilder();

            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html lang='pt-BR'>");
            html.AppendLine("<head>");
            html.AppendLine("    <meta charset='UTF-8'>");
            html.AppendLine("    <meta name='viewport' content='width= Acessosice-width, initial-scale=1.0'>");
            html.AppendLine($"    <title>Orçamento {orcamentoAtual.CodigoOrcamento}</title>");
            html.AppendLine(GerarCSS());
            html.AppendLine("</head>");
            html.AppendLine("<body>");

            // Cabeçalho da empresa
            html.AppendLine(GerarCabecalhoEmpresa());

            // Informações do orçamento
            html.AppendLine(GerarInformacoesOrcamento());

            // Dados do cliente
            html.AppendLine(GerarDadosCliente());

            // Itens do orçamento
            html.AppendLine(GerarItensOrcamento());

            // Totais
            html.AppendLine(GerarTotais());

            // Observações
            html.AppendLine(GerarObservacoes());

            // Rodapé
            html.AppendLine(GerarRodape());

            // JavaScript para impressão automática
            html.AppendLine(GerarJavaScript());

            html.AppendLine("</body>");
            html.AppendLine("</html>");

            return html.ToString();
        }

        private string GerarCSS()
        {
            return @"
    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            font-size: 12px;
            line-height: 1.4;
            color: #333;
            background-color: #fff;
            margin: 20px;
        }

        .container {
            max-width: 800px;
            margin: 0 auto;
            background: white;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            padding: 30px;
        }

        .header {
            text-align: center;
            border-bottom: 3px solid #2c3e50;
            padding-bottom: 20px;
            margin-bottom: 30px;
        }

        .company-name {
            font-size: 28px;
            font-weight: bold;
            color: #2c3e50;
            margin-bottom: 10px;
        }

        .company-info {
            font-size: 14px;
            color: #7f8c8d;
            line-height: 1.6;
        }

        .document-title {
            font-size: 24px;
            font-weight: bold;
            color: #e74c3c;
            text-align: center;
            margin: 30px 0;
            padding: 15px;
            background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
            border-radius: 8px;
            border-left: 5px solid #e74c3c;
        }

        .info-section {
            margin-bottom: 25px;
        }

        .section-title {
            font-size: 16px;
            font-weight: bold;
            color: #2c3e50;
            margin-bottom: 15px;
            padding-bottom: 5px;
            border-bottom: 2px solid #3498db;
        }

        .info-grid {
            display: grid;
            grid-template-columns: 1fr 1fr;
            gap: 20px;
            margin-bottom: 20px;
        }

        .info-item {
            display: flex;
            margin-bottom: 8px;
        }

        .info-label {
            font-weight: bold;
            min-width: 120px;
            color: #34495e;
        }

        .info-value {
            color: #2c3e50;
        }

        .items-table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            box-shadow: 0 2px 8px rgba(0,0,0,0.1);
        }

        .items-table th {
            background: linear-gradient(135deg, #3498db 0%, #2980b9 100%);
            color: white;
            padding: 12px 8px;
            text-align: left;
            font-weight: bold;
            font-size: 13px;
        }

        .items-table td {
            padding: 10px 8px;
            border-bottom: 1px solid #ecf0f1;
        }

        .items-table tr:nth-child(even) {
            background-color: #f8f9fa;
        }

        .items-table tr:hover {
            background-color: #e3f2fd;
        }

        .text-right {
            text-align: right;
        }

        .text-center {
            text-align: center;
        }

        .totals-section {
            margin-top: 30px;
            padding: 20px;
            background: linear-gradient(135deg, #f8f9fa 0%, #e9ecef 100%);
            border-radius: 8px;
            border: 1px solid #dee2e6;
        }

        .total-line {
            display: flex;
            justify-content: space-between;
            margin-bottom: 8px;
            padding: 5px 0;
        }

        .total-label {
            font-weight: bold;
            color: #34495e;
        }

        .total-value {
            font-weight: bold;
            color: #2c3e50;
        }

        .grand-total {
            border-top: 2px solid #3498db;
            padding-top: 10px;
            margin-top: 10px;
            font-size: 18px;
        }

        .grand-total .total-label,
        .grand-total .total-value {
            color: #e74c3c;
            font-size: 20px;
        }

        .observations {
            margin-top: 25px;
            padding: 15px;
            background-color: #fff3cd;
            border: 1px solid #ffeaa7;
            border-radius: 5px;
        }

        .footer {
            margin-top: 40px;
            padding-top: 20px;
            border-top: 1px solid #bdc3c7;
            text-align: center;
            color: #7f8c8d;
            font-size: 11px;
        }

        .status-badge {
            display: inline-block;
            padding: 5px 15px;
            border-radius: 20px;
            font-weight: bold;
            font-size: 11px;
            text-transform: uppercase;
        }

        .status-novo { background-color: #3498db; color: white; }
        .status-pendente { background-color: #f39c12; color: white; }
        .status-aprovado { background-color: #27ae60; color: white; }
        .status-rejeitado { background-color: #e74c3c; color: white; }
        .status-cancelado { background-color: #95a5a6; color: white; }
        .status-expirado { background-color: #e67e22; color: white; }

        @media print {
            body { margin: 0; }
            .container { 
                box-shadow: none; 
                padding: 20px;
                max-width: none;
            }
            .no-print { display: none !important; }
        }

        .print-button {
            position: fixed;
            top: 20px;
            right: 20px;
            background-color: #3498db;
            color: white;
            border: none;
            padding: 12px 20px;
            border-radius: 5px;
            cursor: pointer;
            font-weight: bold;
            box-shadow: 0 2px 5px rgba(0,0,0,0.2);
            z-index: 1000;
        }

        .print-button:hover {
            background-color: #2980b9;
        }
    </style>";
        }
        private string GerarCabecalhoEmpresa()
        {
            return @"
    <div class='container'>
        <button class='print-button no-print' onclick='window.print()'>🖨️ Imprimir</button>
        
        <div class='header'>
            <div class='company-name'>SUA EMPRESA LTDA</div>
            <div class='company-info'>
                Rua Exemplo, 123 - Centro - Cidade/UF - CEP: 12345-678<br>
                Telefone: (11) 1234-5678 | Email: contato@suaempresa.com.br<br>
                CNPJ: 12.345.678/0001-90
            </div>
        </div>";
        }

        private string GerarInformacoesOrcamento()
        {
            string statusClass = $"status-{orcamentoAtual.Status.ToString().ToLower()}";

            return $@"
        <div class='document-title'>
            ORÇAMENTO Nº {orcamentoAtual.CodigoOrcamento}
            <span class='status-badge {statusClass}'>{ObterDescricaoStatus(orcamentoAtual.Status)}</span>
        </div>

        <div class='info-section'>
            <div class='section-title'>📋 Informações do Orçamento</div>
            <div class='info-grid'>
                <div>
                    <div class='info-item'>
                        <span class='info-label'>Data de Criação:</span>
                        <span class='info-value'>{orcamentoAtual.DataCriacao:dd/MM/yyyy}</span>
                    </div>
                    <div class='info-item'>
                        <span class='info-label'>Validade:</span>
                        <span class='info-value'>{orcamentoAtual.DataValidade?.ToString("dd/MM/yyyy") ?? "Não informada"}</span>
                    </div>
                </div>
                <div>
                    <div class='info-item'>
                        <span class='info-label'>Status:</span>
                        <span class='info-value'>{ObterDescricaoStatus(orcamentoAtual.Status)}</span>
                    </div>
                    <div class='info-item'>
                        <span class='info-label'>Última Modificação:</span>
                        <span class='info-value'>{orcamentoAtual.UltimaModificacao:dd/MM/yyyy HH:mm}</span>
                    </div>
                </div>
            </div>
        </div>";
        }

        private string GerarDadosCliente()
        {
            var cliente = orcamentoAtual.Cliente; //usando Icliente
            if (cliente == null) return "";

            string endereco = MontarEnderecoCompleto(cliente);

            return $@"
        <div class='info-section'>
            <div class='section-title'>👤 Dados do Cliente</div>
            <div class='info-grid'>
                <div>
                    <div class='info-item'>
                        <span class='info-label'>Nome:</span>
                        <span class='info-value'>{cliente.Nome}</span>
                    </div>
                    <div class='info-item'>
                        <span class='info-label'>CPF/CNPJ:</span>
                        <span class='info-value'>{cliente.CPFCNPJ}</span>
                    </div>
                </div>
                <div>
                    <div class='info-item'>
                        <span class='info-label'>Endereço:</span>
                        <span class='info-value'>{endereco}</span>
                    </div>
                </div>
            </div>
        </div>";
        }
        private string GerarItensOrcamento()
        {
            var html = new System.Text.StringBuilder();

            html.AppendLine("<div class='info-section'>");
            html.AppendLine("    <div class='section-title'>📦 Itens do Orçamento</div>");
            html.AppendLine("    <table class='items-table'>");
            html.AppendLine("        <thead>");
            html.AppendLine("            <tr>");
            html.AppendLine("                <th style='width: 50px;'>#</th>");
            html.AppendLine("                <th>Produto/Serviço</th>");
            html.AppendLine("                <th style='width: 80px;' class='text-center'>Qtd</th>");
            html.AppendLine("                <th style='width: 100px;' class='text-right'>Preço Unit.</th>");
            html.AppendLine("                <th style='width: 80px;' class='text-center'>Desc. %</th>");
            html.AppendLine("                <th style='width: 120px;' class='text-right'>Total</th>");
            html.AppendLine("            </tr>");
            html.AppendLine("        </thead>");
            html.AppendLine("        <tbody>");

            int contador = 1;
            foreach (var item in orcamentoAtual.Itens.Where(i => i.Ativo))
            {
                html.AppendLine("            <tr>");
                html.AppendLine($"                <td class='text-center'>{contador}</td>");
                html.AppendLine($"                <td>{item.DescricaoProduto}</td>");
                html.AppendLine($"                <td class='text-center'>{item.Quantidade:N2}</td>");
                html.AppendLine($"                <td class='text-right'>{item.PrecoUnitario:C2}</td>");
                html.AppendLine($"                <td class='text-center'>{item.Desconto:N2}%</td>");
                html.AppendLine($"                <td class='text-right'><strong>{item.Total:C2}</strong></td>");
                html.AppendLine("            </tr>");
                contador++;
            }

            html.AppendLine("        </tbody>");
            html.AppendLine("    </table>");
            html.AppendLine("</div>");

            return html.ToString();
        }
        private string GerarTotais()
        {
            return $@"
        <div class='totals-section'>
            <div class='section-title'>💰 Resumo Financeiro</div>
            
            <div class='total-line'>
                <span class='total-label'>Subtotal:</span>
                <span class='total-value'>{orcamentoAtual.Subtotal:C2}</span>
            </div>
            
            {(orcamentoAtual.DescontoGeral > 0 ? $@"
            <div class='total-line'>
                <span class='total-label'>Desconto ({orcamentoAtual.DescontoGeral:N2}%):</span>
                <span class='total-value'>- {orcamentoAtual.ValorDesconto:C2}</span>
            </div>" : "")}
            
            <div class='total-line grand-total'>
                <span class='total-label'>VALOR TOTAL:</span>
                <span class='total-value'>{orcamentoAtual.ValorTotal:C2}</span>
            </div>
        </div>";
        }
        private string GerarObservacoes()
        {
            if (string.IsNullOrEmpty(orcamentoAtual.Observacoes))
                return "";

            return $@"
        <div class='observations'>
            <div class='section-title'>📝 Observações</div>
            <p>{orcamentoAtual.Observacoes.Replace("\n", "<br>")}</p>
        </div>";
        }

        private string GerarRodape()
        {
            return $@"
        <div class='footer'>
            <p>Este orçamento foi gerado automaticamente pelo sistema em {DateTime.Now:dd/MM/yyyy HH:mm:ss}</p>
            <p>Orçamento válido por 30 dias a partir da data de emissão</p>
            <p>Dúvidas? Entre em contato conosco: contato@suaempresa.com.br | (11) 1234-5678</p>
        </div>
    </div>";
        }
        private string GerarJavaScript()
        {
            return @"
    <script>
        // Função para imprimir automaticamente (opcional)
        // window.onload = function() {
        //     setTimeout(function() {
        //         window.print();
        //     }, 1000);
        // };

        // Função para fechar após imprimir
        window.onafterprint = function() {
            // Opcional: fechar a janela após imprimir
            // window.close();
        };
    </script>";
        }

        private string ObterDescricaoStatus(StatusOrcamento status)
        {
            return status switch
            {
                StatusOrcamento.Novo => "Novo",
                StatusOrcamento.Pendente => "Pendente",
                StatusOrcamento.Aprovado => "Aprovado",
                StatusOrcamento.Rejeitado => "Rejeitado",
                StatusOrcamento.Cancelado => "Cancelado",
                StatusOrcamento.Expirado => "Expirado",
                _ => "Desconhecido"
            };
        }

        private string MontarEnderecoCompleto(ICliente cliente)
        {
            var partes = new[]
            { cliente.Endereco, cliente.Numero, cliente.Bairro, cliente.Localidade,     cliente.UF    }.Where(p => !string.IsNullOrEmpty(p));
            return string.Join(", ", partes);
        }    

        private void BtnVerHistorico_Click(object sender, EventArgs e)
        {
            try
            {
                int? clienteId = orcamentoAtual?.ClienteID > 0 ? orcamentoAtual.ClienteID : null;

                using (var frmHistorico = new frmHistoricoOrcamento(clienteId))
                {
                    frmHistorico.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir histórico: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnVerificarOrcamento_Click(object sender, EventArgs e)
        {
            if (orcamentoAtual.ID > 0)
            {
                var orcamento = await repository.ObterOrcamentoPorIdAsync(orcamentoAtual.ID); // await aqui!

                if (orcamento != null)
                {
                    MessageBox.Show($"Orçamento verificado com sucesso!\n" +
                                   $"Código: {orcamento.CodigoOrcamento}\n" +
                                   $"Cliente: {orcamento.Cliente?.Nome}\n" +
                                   $"Total: {orcamento.ValorTotal:C2}\n" +
                                   $"Status: {orcamento.Status}", "Verificação",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Orçamento não encontrado.", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Nenhum orçamento carregado para verificar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }

}
