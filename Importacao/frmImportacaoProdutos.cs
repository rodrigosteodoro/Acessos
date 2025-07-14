using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfficeOpenXml;


namespace Acessos
{
    public partial class frmImportacaoProdutos : Telerik.WinControls.UI.RadForm
    {
       
        private List<Produto> _produtosImportados = new List<Produto>();
        private List<string> _errosImportacao = new List<string>();
        private List<Produto> _produtosExistentes;
        private Produto repository;
        private int totalLinhasProcessadas = 0;
        private int produtosSalvos = 0;
        private int errosEncontrados = 0;
        private ProdutoRepository Prepository;
        private ProdutoDAL produtoDAL;
        private Dictionary<string, int> MapearIndicesColunas(string[] cabecalho)
        {
            var map = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            for (int i = 0; i < cabecalho.Length; i++)
            {
                string nome = cabecalho[i].Trim().Replace("\"", "");
                if (!string.IsNullOrEmpty(nome) && !map.ContainsKey(nome))
                    map.Add(nome, i);
            }
            return map;
        }

        public frmImportacaoProdutos()
        {
            InitializeComponent();
            repository = new  Produto();
            Prepository = new ProdutoRepository();   
            produtoDAL = new ProdutoDAL();
            ConfigurarEventosEEstilos();
            InicializarFormulario();          
        }

        private void InicializarFormulario()
        {
            btnImportar.Enabled = false;
            btnSalvar.Enabled = false;
            btnExportarErros.Enabled = false;
            AtualizarStatus("Selecione um arquivo para importar");
        }

        public void FormImportacaoProdutos_Load(object sender, EventArgs e)
        {
            // Configurações adicionais ao carregar o formulário
            this.Text = "Importação de Produtos - Sistema de Orçamentos";
            tabControl.SelectedIndex = 0;
        }
        private async void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (!_produtosImportados.Any())
            {
                MessageBox.Show("Não há produtos para salvar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Deseja salvar {_produtosImportados.Count} produtos no banco de dados?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    HabilitarControles(false);
                    ExibirProgresso(true, 0, _produtosImportados.Count);
                    AtualizarStatus("Salvando produtos...");

                    await SalvarProdutos();

                    MessageBox.Show($"Produtos salvos com sucesso!\n" +
                                   $"Total: {produtosSalvos} produtos",
                        "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    AtualizarStatus($"Salvamento concluído: {produtosSalvos} produtos salvos");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar produtos: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AtualizarStatus($"Erro no salvamento: {ex.Message}");
                }
                finally
                {
                    ExibirProgresso(false);
                    HabilitarControles(true);
                }
            }
        }

        public async void BtnImportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtArquivo.Text) || !File.Exists(txtArquivo.Text))
            {
                MessageBox.Show("Selecione um arquivo válido para importação.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Limpar dados anteriores
                LimparDados();

                // Desabilitar controles durante importação
                HabilitarControles(false);
                ExibirProgresso(true);
                AtualizarStatus("Iniciando importação...");

                // Processar arquivo
                await ProcessarArquivo(txtArquivo.Text);

                // Exibir resultados
                ExibirResultados();

                // Atualizar interface
                AtualizarInterface();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro durante a importação: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                AtualizarStatus($"Erro: {ex.Message}");
            }
            finally
            {
                ExibirProgresso(false);
                HabilitarControles(true);
            }
        }

        private async Task ProcessarArquivo(string caminhoArquivo)
        {
            string extensao = Path.GetExtension(caminhoArquivo).ToLower();

            switch (extensao)
            {
                case ".csv":
                    await ProcessarCSV(caminhoArquivo);
                    break;
                case ".xlsx":
                case ".xls":
                    await ProcessarExcel(caminhoArquivo);
                    break;
                default:
                    throw new NotSupportedException($"Formato de arquivo não suportado: {extensao}");
            }
        }

        private async Task ProcessarCSV(string caminhoArquivo)
        {
            await Task.Run(() =>
            {
                var linhas = File.ReadAllLines(caminhoArquivo, Encoding.UTF8);
                int inicioLinhas = chkCabecalho.Checked ? 1 : 0;

                Dictionary<string, int> colunas = null;
                if (chkCabecalho.Checked && linhas.Length > 0)
                    colunas = MapearIndicesColunas(ParsearCSV(linhas[0]));

                this.Invoke((MethodInvoker)delegate
                {
                    ExibirProgresso(true, 0, linhas.Length - inicioLinhas);
                });

                for (int i = inicioLinhas; i < linhas.Length; i++)
                {
                    try
                    {
                        var produto = ProcessarLinha(linhas[i], i + 1, colunas);
                        if (produto != null)
                        {
                            _produtosImportados.Add(produto);
                        }
                    }
                    catch (Exception ex)
                    {
                        _errosImportacao.Add($"Linha {i + 1}: {ex.Message}");
                        errosEncontrados++;
                    }

                    totalLinhasProcessadas++;

                    this.Invoke((MethodInvoker)delegate
                    {
                        ExibirProgresso(true, i - inicioLinhas + 1);
                        AtualizarStatus($"Processando linha {i + 1} de {linhas.Length}...");
                    });
                }
            });
        }


        private async Task ProcessarExcel(string caminhoArquivo)
        {
            await Task.Run(() =>
            {
                try
                {
                    using (var package = new OfficeOpenXml.ExcelPackage(new FileInfo(caminhoArquivo)))
                    {
                        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                        if (worksheet == null)
                            throw new Exception("Nenhuma planilha encontrada no arquivo Excel.");

                        int startRow = chkCabecalho.Checked ? 2 : 1;
                        int totalRows = worksheet.Dimension.End.Row;

                        // Mapeamento de colunas pelo cabeçalho
                        Dictionary<string, int> colunas = null;
                        if (chkCabecalho.Checked)
                        {
                            var cabecalho = new string[worksheet.Dimension.End.Column];
                            for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                cabecalho[col - 1] = worksheet.Cells[1, col].Text;
                            colunas = MapearIndicesColunas(cabecalho);
                        }

                        this.Invoke((MethodInvoker)delegate
                        {
                            ExibirProgresso(true, 0, totalRows - startRow + 1);
                        });

                        for (int row = startRow; row <= totalRows; row++)
                        {
                            try
                            {
                                var campos = new string[worksheet.Dimension.End.Column];
                                for (int col = 1; col <= worksheet.Dimension.End.Column; col++)
                                {
                                    campos[col - 1] = worksheet.Cells[row, col].Text;
                                }
                                var produto = ProcessarLinha(campos, row, colunas);
                                if (produto != null)
                                {
                                    _produtosImportados.Add(produto);
                                }
                            }
                            catch (Exception ex)
                            {
                                _errosImportacao.Add($"Linha {row}: {ex.Message}");
                                errosEncontrados++;
                            }

                            totalLinhasProcessadas++;

                            this.Invoke((MethodInvoker)delegate
                            {
                                ExibirProgresso(true, row - startRow + 1, totalRows - startRow + 1);
                                AtualizarStatus($"Processando linha {row} de {totalRows}...");
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show($"Erro ao processar Excel: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    });
                }
            });
        }


        private Produto ProcessarLinha(string linha, int numeroLinha, Dictionary<string, int> colunas)
        {
            var campos = ParsearCSV(linha);
            return ProcessarLinha(campos, numeroLinha, colunas);
        }
       

        private Produto ProcessarLinha(string[] campos, int numeroLinha, Dictionary<string, int> colunas)
        {
            if (campos == null || campos.Length == 0)
                return null;

            var produto = new Produto();

            try
            {
                // Identificação
                produto.CodigoProduto = ObterCampoPorNome(campos, colunas, "CodigoProduto", false) ?? ObterCampoPorNome(campos, colunas, "Codigo", true);
                produto.CodigoBarras = ObterCampoPorNome(campos, colunas, "CodigoBarras", false);
                produto.Nome = ObterCampoPorNome(campos, colunas, "Nome", true);
                produto.Descricao = ObterCampoPorNome(campos, colunas, "Descricao", false);
                produto.SKU = ObterCampoPorNome(campos, colunas, "SKU", false);

                // Classificação
                produto.Categoria = ObterCampoPorNome(campos, colunas, "Categoria", false);
                produto.Subcategoria = ObterCampoPorNome(campos, colunas, "Subcategoria", false);
                produto.Marca = ObterCampoPorNome(campos, colunas, "Marca", false);
                produto.TipoProduto = ObterCampoPorNome(campos, colunas, "TipoProduto", false);

                // Fornecedor
                var fornecedorIdStr = ObterCampoPorNome(campos, colunas, "FornecedorID", false);
                produto.FornecedorID = !string.IsNullOrEmpty(fornecedorIdStr) ? int.Parse(fornecedorIdStr) : 0;
                produto.NomeFornecedor = ObterCampoPorNome(campos, colunas, "NomeFornecedor", false);

                // Unidade e medidas
                produto.UnidadeMedida = ObterCampoPorNome(campos, colunas, "UnidadeMedida", false) ?? "UN";
                produto.Peso = ParsearDecimal(ObterCampoPorNome(campos, colunas, "Peso", false));
                produto.Volume = ParsearDecimal(ObterCampoPorNome(campos, colunas, "Volume", false));

                // Estoque
                produto.QuantidadeAtual = ParsearDecimal(ObterCampoPorNome(campos, colunas, "QuantidadeAtual", false));
                produto.EstoqueMinimo = ParsearDecimal(ObterCampoPorNome(campos, colunas, "EstoqueMinimo", false));
                produto.EstoqueMaximo = ParsearDecimal(ObterCampoPorNome(campos, colunas, "EstoqueMaximo", false));
                produto.LocalizacaoEstoque = ObterCampoPorNome(campos, colunas, "LocalizacaoEstoque", false);
                produto.PermiteEstoqueNegativo = ParsearBoolean(ObterCampoPorNome(campos, colunas, "PermiteEstoqueNegativo", false));

                // Preços
                produto.PrecoCusto = ParsearDecimal(ObterCampoPorNome(campos, colunas, "PrecoCusto", true));
                produto.PrecoVenda = ParsearDecimal(ObterCampoPorNome(campos, colunas, "PrecoVenda", true));
                var margemStr = ObterCampoPorNome(campos, colunas, "MargemLucro", false);
                produto.MargemLucro = !string.IsNullOrEmpty(margemStr)
                    ? ParsearDecimal(margemStr)
                    : CalcularMargem(produto.PrecoCusto, produto.PrecoVenda);

                // Promoção
                produto.PromocaoAtiva = ParsearBoolean(ObterCampoPorNome(campos, colunas, "PromocaoAtiva", false));
                var precoPromocionalStr = ObterCampoPorNome(campos, colunas, "PrecoPromocional", false);
                produto.PrecoPromocional = !string.IsNullOrEmpty(precoPromocionalStr) ? ParsearDecimal(precoPromocionalStr) : (decimal?)null;
                var inicioPromocaoStr = ObterCampoPorNome(campos, colunas, "InicioPromocao", false);
                produto.InicioPromocao = !string.IsNullOrEmpty(inicioPromocaoStr) ? (DateTime?)ParsearData(inicioPromocaoStr) : null;
                var fimPromocaoStr = ObterCampoPorNome(campos, colunas, "FimPromocao", false);
                produto.FimPromocao = !string.IsNullOrEmpty(fimPromocaoStr) ? (DateTime?)ParsearData(fimPromocaoStr) : null;

                // Tributação
                produto.OrigemProduto = ObterCampoPorNome(campos, colunas, "OrigemProduto", false);
                produto.NCM = ObterCampoPorNome(campos, colunas, "NCM", false);
                produto.CFOP = ObterCampoPorNome(campos, colunas, "CFOP", false);
                produto.CSTCSOSN = ObterCampoPorNome(campos, colunas, "CSTCSOSN", false);
                produto.AliquotaICMS = ParsearDecimal(ObterCampoPorNome(campos, colunas, "AliquotaICMS", false));
                produto.AliquotaPIS = ParsearDecimal(ObterCampoPorNome(campos, colunas, "AliquotaPIS", false));
                produto.AliquotaCOFINS = ParsearDecimal(ObterCampoPorNome(campos, colunas, "AliquotaCOFINS", false));
                produto.AliquotaIPI = ParsearDecimal(ObterCampoPorNome(campos, colunas, "AliquotaIPI", false));

                // Lote e validade
                produto.Lote = ObterCampoPorNome(campos, colunas, "Lote", false);
                var dataValidade = ObterCampoPorNome(campos, colunas, "DataValidade", false);
                produto.DataValidade = !string.IsNullOrEmpty(dataValidade)
                    ? (DateTime?)ParsearData(dataValidade)
                    : null;

                // Datas de cadastro e alteração
                var dataCadastro = ObterCampoPorNome(campos, colunas, "DataCadastro", false);
                produto.DataCadastro = !string.IsNullOrEmpty(dataCadastro) ? ParsearData(dataCadastro) : DateTime.Now;
                var ultimaAlteracao = ObterCampoPorNome(campos, colunas, "UltimaAlteracao", false);
                produto.UltimaAlteracao = !string.IsNullOrEmpty(ultimaAlteracao) ? ParsearData(ultimaAlteracao) : DateTime.Now;

                // Status e observações
                produto.Ativo = ParsearBoolean(ObterCampoPorNome(campos, colunas, "Ativo", false));
                produto.Observacoes = ObterCampoPorNome(campos, colunas, "Observacoes", false);

                // Imagem (se for base64 ou caminho, adapte conforme sua lógica)
                // produto.Imagem = ...;

                ValidarProduto(produto, numeroLinha);

                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao processar campos: {ex.Message}");
            }
        }

        private string ObterCampoPorNome(string[] campos, Dictionary<string, int> colunas, string nome, bool obrigatorio = true)
        {
            if (colunas != null && colunas.TryGetValue(nome, out int idx) && idx < campos.Length)
                return campos[idx].Trim().Trim('"');
            if (obrigatorio)
                throw new Exception($"Campo '{nome}' é obrigatório");
            return null;
        }


        private string[] ParsearCSV(string linha)
        {
            var campos = new List<string>();
            bool dentroAspas = false;
            var campoAtual = new StringBuilder();

            for (int i = 0; i < linha.Length; i++)
            {
                char c = linha[i];

                if (c == '"')
                {
                    dentroAspas = !dentroAspas;
                }
                else if (c == ',' && !dentroAspas)
                {
                    campos.Add(campoAtual.ToString().Trim());
                    campoAtual.Clear();
                }
                else
                {
                    campoAtual.Append(c);
                }
            }

            campos.Add(campoAtual.ToString().Trim());
            return campos.ToArray();
        }

        private string ObterCampo(string[] campos, int indice, string nomeCampo, bool obrigatorio = true)
        {
            if (indice >= campos.Length || string.IsNullOrWhiteSpace(campos[indice]))
            {
                if (obrigatorio)
                    throw new Exception($"Campo '{nomeCampo}' é obrigatório");
                return null;
            }
            return campos[indice].Trim().Trim('"');
        }

        private decimal ParsearDecimal(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return 0;

            valor = valor.Replace("R$", "").Replace(".", "").Replace(",", ".");

            if (decimal.TryParse(valor, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal resultado))
                return resultado;

            throw new Exception($"Valor numérico inválido: {valor}");
        }

        private DateTime ParsearData(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new Exception("Data em branco.");

            valor = valor.Trim();

            string[] formatos = { "yyyy-MM-dd", "dd/MM/yyyy", "MM/dd/yyyy", "dd-MM-yyyy" };

            foreach (string formato in formatos)
            {
                if (DateTime.TryParseExact(valor, formato, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime data))
                    return data;
            }

            // Tenta conversão genérica (para casos em que o Excel exporta datas no padrão do sistema)
            if (DateTime.TryParse(valor, out DateTime dataGenerica))
                return dataGenerica;

            throw new Exception($"Data inválida: {valor}");
        }

        private bool ParsearBoolean(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return true;

            valor = valor.ToLower().Trim();
            return valor == "1" || valor == "true" || valor == "sim" || valor == "s" || valor == "ativo";
        }

        private decimal CalcularMargem(decimal precoCusto, decimal precoVenda)
        {
            if (precoCusto <= 0) return 0;
            return ((precoVenda - precoCusto) / precoCusto) * 100;
        }

        private void ValidarProduto(Produto produto, int numeroLinha)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(produto.CodigoProduto))
                erros.Add("Código do produto é obrigatório");

            if (string.IsNullOrWhiteSpace(produto.Nome))
                erros.Add("Nome do produto é obrigatório");

            if (produto.PrecoCusto < 0)
                erros.Add("Preço de custo não pode ser negativo");

            if (produto.PrecoVenda < 0)
                erros.Add("Preço de venda não pode ser negativo");

            if (produto.QuantidadeAtual < 0)
                erros.Add("Quantidade em estoque não pode ser negativa");

            // Verificar duplicatas
            if (_produtosImportados.Any(p => p.CodigoProduto == produto.CodigoProduto))
                erros.Add($"Código '{produto.CodigoProduto}' duplicado no arquivo");

            if (erros.Any())
            {
                throw new Exception($"Linha {numeroLinha}: {string.Join("; ", erros)}");
            }
        }

        private void ExibirResultados()
        {
            // Atualizar grid de produtos
            dgvProdutos.DataSource = null;
            dgvProdutos.DataSource = _produtosImportados;

            // Atualizar lista de erros
            lstErros.Items.Clear();
            foreach (var erro in _errosImportacao)
            {
                lstErros.Items.Add(erro);
            }

            // Atualizar resumo
            AtualizarResumo();

            // Atualizar títulos das abas
            tabProdutos.Text = $"Produtos Importados ({_produtosImportados.Count})";
            tabErros.Text = $"Erros ({_errosImportacao.Count})";
        }

        private void AtualizarResumo()
        {
            var resumo = new StringBuilder();

            resumo.AppendLine("=== RESUMO DA IMPORTAÇÃO ===");
            resumo.AppendLine();
            resumo.AppendLine($"📄 Arquivo: {Path.GetFileName(txtArquivo.Text)}");
            resumo.AppendLine($"📅 Data/Hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            resumo.AppendLine();
            resumo.AppendLine("📊 ESTATÍSTICAS:");
            resumo.AppendLine($"   • Total de linhas processadas: {totalLinhasProcessadas}");
            resumo.AppendLine($"   • Produtos importados com sucesso: {_produtosImportados.Count}");
            resumo.AppendLine($"   • Erros encontrados: {_errosImportacao.Count}");
            resumo.AppendLine();

            if (_produtosImportados.Any())
            {
                resumo.AppendLine("💰 ANÁLISE FINANCEIRA:");
                resumo.AppendLine($"   • Valor total em estoque (custo): {_produtosImportados.Sum(p => p.PrecoCusto * p.QuantidadeAtual):C2}");
                resumo.AppendLine($"   • Valor total em estoque (venda): {_produtosImportados.Sum(p => p.PrecoVenda * p.QuantidadeAtual):C2}");
                resumo.AppendLine($"   • Margem média: {_produtosImportados.Where(p => p.MargemLucro > 0).Average(p => p.MargemLucro):N2}%");
                resumo.AppendLine();

                resumo.AppendLine("📦 CATEGORIAS:");
                var categorias = _produtosImportados
                    .Where(p => !string.IsNullOrEmpty(p.Categoria))
                    .GroupBy(p => p.Categoria)
                    .OrderByDescending(g => g.Count());

                foreach (var categoria in categorias.Take(10))
                {
                    resumo.AppendLine($"   • {categoria.Key}: {categoria.Count()} produtos");
                }
            }

            if (_errosImportacao.Any())
            {
                resumo.AppendLine();
                resumo.AppendLine("❌ PRINCIPAIS ERROS:");
                var tiposErros = _errosImportacao
                    .Select(e => e.Split(':').LastOrDefault()?.Trim())
                    .Where(e => !string.IsNullOrEmpty(e))
                    .GroupBy(e => e)
                    .OrderByDescending(g => g.Count());

                foreach (var erro in tiposErros.Take(5))
                {
                    resumo.AppendLine($"   • {erro.Key}: {erro.Count()} ocorrências");
                }
            }

            rtbResumo.Text = resumo.ToString();
        }

        public void BtnLimpar_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "Isso irá limpar todos os dados importados. Deseja continuar?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                LimparDados();
                txtArquivo.Text = "";
                btnImportar.Enabled = false;
                AtualizarStatus("Dados limpos. Selecione um novo arquivo.");
            }
        }

        private void LimparDados()
        {
            _produtosImportados.Clear();
            _errosImportacao.Clear();
            totalLinhasProcessadas = 0;
            produtosSalvos = 0;
            errosEncontrados = 0;

            dgvProdutos.DataSource = null;
            lstErros.Items.Clear();
            rtbResumo.Text = "";

            tabProdutos.Text = "Produtos Importados";
            tabErros.Text = "Erros";
            tabResumo.Text = "Resumo";

            btnSalvar.Enabled = false;
            btnExportarErros.Enabled = false;
        }

        private async Task SalvarProdutos()
        {
            produtosSalvos = 0;           

            for (int i = 0; i < _produtosImportados.Count; i++)
            {
                try
                {
                    var produto = _produtosImportados[i];
                    await produtoDAL.InserirProdutoAsync(produto);
                    produtosSalvos++;

                    this.Invoke((MethodInvoker)delegate
                    {
                        ExibirProgresso(true, i + 1, _produtosImportados.Count);
                        AtualizarStatus($"Salvando produto {i + 1} de {_produtosImportados.Count}...");
                    });
                }
                catch (Exception ex)
                {
                    _errosImportacao.Add($"Erro ao salvar produto {_produtosImportados[i].CodigoProduto}: {ex.Message}");
                }
            }
        }


        public void BtnExportarErros_Click(object sender, EventArgs e)
        {
            if (!_errosImportacao.Any())
            {
                MessageBox.Show("Não há erros para exportar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "Arquivos de Texto (*.txt)|*.txt|Arquivos CSV (*.csv)|*.csv";
                saveDialog.FileName = $"Erros_Importacao_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var conteudo = new StringBuilder();
                        conteudo.AppendLine($"RELATÓRIO DE ERROS - IMPORTAÇÃO DE PRODUTOS");
                        conteudo.AppendLine($"Data/Hora: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                        conteudo.AppendLine($"Arquivo: {Path.GetFileName(txtArquivo.Text)}");
                        conteudo.AppendLine($"Total de erros: {_errosImportacao.Count}");
                        conteudo.AppendLine();
                        conteudo.AppendLine("DETALHES DOS ERROS:");
                        conteudo.AppendLine(new string('=', 50));

                        foreach (var erro in _errosImportacao)
                        {
                            conteudo.AppendLine(erro);
                        }

                        File.WriteAllText(saveDialog.FileName, conteudo.ToString(), Encoding.UTF8);

                        MessageBox.Show("Relatório de erros exportado com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void AtualizarInterface()
        {
            btnSalvar.Enabled = _produtosImportados.Any();
            btnExportarErros.Enabled = _errosImportacao.Any();

            if (_produtosImportados.Any())
            {
                tabControl.SelectedTab = tabProdutos;
            }
            else if (_errosImportacao.Any())
            {
                tabControl.SelectedTab = tabErros;
            }
        }

        private void HabilitarControles(bool habilitar)
        {
            btnSelecionarArquivo.Enabled = habilitar;
            btnImportar.Enabled = habilitar && !string.IsNullOrEmpty(txtArquivo.Text);
            btnLimpar.Enabled = habilitar;
            btnGerarTemplate.Enabled = habilitar;
            chkCabecalho.Enabled = habilitar;
        }

        private void AtualizarStatus(string mensagem)
        {
            lblStatus.Text = mensagem;
            Application.DoEvents();
        }

        private void LstErros_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();

            using (var brush = new SolidBrush(Color.FromArgb(220, 53, 69)))
            {
                e.Graphics.DrawString(lstErros.Items[e.Index].ToString(),
                    e.Font, brush, e.Bounds, StringFormat.GenericDefault);
            }

            e.DrawFocusRectangle();
        }
        private void ConfigurarEventosEEstilos()
        {
            // Configurar eventos dos controles
            btnSelecionarArquivo.Click += BtnSelecionarArquivo_Click;
            btnGerarTemplate.Click += btnGerarTemplate_Click;

            // Configurar estilos do grid
            ConfigurarGridProdutos();

            // Configurar lista de erros
            lstErros.DrawMode = DrawMode.OwnerDrawFixed;
            lstErros.DrawItem += LstErros_DrawItem;

            // Configurar progress bar
            progressBar.Visible = false;
            progressBar.Style = ProgressBarStyle.Continuous;
        }

        private void ConfigurarGridProdutos()
        {
            dgvProdutos.AutoGenerateColumns = false;
            dgvProdutos.Columns.Clear();

            // Configurar colunas do grid
            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodigoProduto",
                HeaderText = "Código",
                DataPropertyName = "CodigoProduto",
                Width = 100
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nome",
                HeaderText = "Nome",
                DataPropertyName = "Nome",
                Width = 200,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Categoria",
                HeaderText = "Categoria",
                DataPropertyName = "Categoria",
                Width = 120
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecoCusto",
                HeaderText = "Preço Custo",
                DataPropertyName = "PrecoCusto",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrecoVenda",
                HeaderText = "Preço Venda",
                DataPropertyName = "PrecoVenda",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "QuantidadeAtual",
                HeaderText = "Estoque",
                DataPropertyName = "QuantidadeAtual",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleCenter }
            });

            dgvProdutos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "UnidadeMedida",
                HeaderText = "Unidade",
                DataPropertyName = "UnidadeMedida",
                Width = 70
            });

            // Configurações gerais
            dgvProdutos.ReadOnly = true;
            dgvProdutos.AllowUserToAddRows = false;
            dgvProdutos.AllowUserToDeleteRows = false;
            dgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProdutos.RowHeadersVisible = false;
        }

        private void BtnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            using (var openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Selecionar Arquivo para Importação"; //preferencia Excel
                openDialog.Filter = "Arquivos Excel (*.xlsx;*.xls)|*.xlsx;*.xls|Arquivos CSV (*.csv)|*.csv";
                openDialog.FilterIndex = 1;
                openDialog.RestoreDirectory = true;

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    txtArquivo.Text = openDialog.FileName;
                    btnImportar.Enabled = true;

                    // Mostrar informações do arquivo
                    var fileInfo = new FileInfo(openDialog.FileName);
                    AtualizarStatus($"Arquivo selecionado: {fileInfo.Name} ({fileInfo.Length / 1024:N0} KB)");

                    // Detectar automaticamente se tem cabeçalho
                    DetectarCabecalho(openDialog.FileName);
                }
            }
        }

        private void DetectarCabecalho(string caminhoArquivo)
        {
            try
            {
                using (var reader = new StreamReader(caminhoArquivo, Encoding.UTF8))
                {
                    var primeiraLinha = reader.ReadLine();
                    if (!string.IsNullOrEmpty(primeiraLinha))
                    {
                        // Verificar se a primeira linha contém texto típico de cabeçalho
                        var campos = primeiraLinha.Split(',', ';');
                        bool temCabecalho = campos.Any(c =>
                            c.ToLower().Contains("codigo") ||
                            c.ToLower().Contains("nome") ||
                            c.ToLower().Contains("descricao") ||
                            c.ToLower().Contains("preco"));

                        chkCabecalho.Checked = temCabecalho;

                        if (temCabecalho)
                        {
                            AtualizarStatus("Cabeçalho detectado automaticamente na primeira linha.");
                            chkCabecalho.Checked = temCabecalho;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Ignorar erros de detecção
                Console.WriteLine($"Erro ao detectar cabeçalho: {ex.Message}");
            }
        }

        private void btnGerarTemplate_Click(object sender, EventArgs e)
        {
            using (var saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Salvar Template CSV";
                saveDialog.Filter = "Arquivos CSV (*.csv)|*.csv";
                saveDialog.FileName = $"Template_Produtos_{DateTime.Now:yyyyMMdd}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        GerarTemplateCSV(saveDialog.FileName);

                        var resultado = MessageBox.Show(
                            $"Template gerado com sucesso!\n\nDeseja abrir o arquivo?",
                            "Template Criado",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);

                        if (resultado == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao gerar template: {ex.Message}", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void GerarTemplateCSV(string caminhoArquivo)
        {
            var template = new StringBuilder();

            // Cabeçalho
            template.AppendLine("Codigo,Nome,Descricao,Categoria,Subcategoria,Marca,PrecoCusto,PrecoVenda,MargemLucro,QuantidadeEstoque,UnidadeMedida," +
                "Peso,Volume,CodigoBarras,DataCadastro,DataValidade,Ativo,Fornecedor,Lote,EstoqueMinimo,EstoqueMaximo,Observacoes");

            // Exemplos de dados
            template.AppendLine("\"001\",\"Produto Exemplo 1\",\"Descrição do produto 1\",\"Categoria A\",\"Subcategoria 1\",\"Marca X\",\"10.50\",\"15.75\",\"50.00\"," +
                "\"100\",\"UN\",\"0.5\",\"0.1\",\"7891234567890\",\"01/01/2024\",\"\",\"1\",\"Fornecedor ABC\",\"LOTE001\",\"10\",\"1000\",\"Observações do produto\"");
            template.AppendLine("\"002\",\"Produto Exemplo 2\",\"Descrição do produto 2\",\"Categoria B\",\"Subcategoria 2\",\"Marca Y\",\"25.00\",\"35.00\",\"40.00\"," +
                "\"50\",\"KG\",\"2.0\",\"0.5\",\"7891234567891\",\"01/01/2024\",\"31/12/2024\",\"1\",\"Fornecedor XYZ\",\"LOTE002\",\"5\",\"500\",\"\"");

            File.WriteAllText(caminhoArquivo, template.ToString(), Encoding.UTF8);
        }

        private void ExibirProgresso(bool mostrar, int valorAtual = 0, int valorMaximo = 100)
        {
            if (mostrar)
            {
                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = valorMaximo;
                progressBar.Value = Math.Min(valorAtual, valorMaximo);

                // Atualizar porcentagem se necessário
                if (valorMaximo > 0)
                {
                    int porcentagem = (int)((double)valorAtual / valorMaximo * 100);
                    lblProgresso.Text = $"Progresso: {porcentagem}% ({valorAtual}/{valorMaximo})";
                    lblProgresso.Visible = true;
                }
            }
            else
            {
                progressBar.Visible = false;
                lblProgresso.Visible = false;
            }

            Application.DoEvents();
        }
        private async Task CarregarProdutosExistentesAsync()
        {
            _produtosExistentes = await Prepository.ObterTodosAsync();
        }
        private async void btResolverDuplicatas_Click(object sender, EventArgs e)
        {
           await  CarregarProdutosExistentesAsync();
            FormManager.ShowForm<frmResolverDuplicatas>(
                "Resolução de Duplicatas",
                new frmResolverDuplicatas(_produtosImportados, _produtosExistentes),
                (frmResolverDuplicatas form) =>
                {
                    form.OnResolucaoConcluida += (produtosResolvidos, errosResolvidos) =>
                    {
                        _produtosImportados = produtosResolvidos;
                        _errosImportacao = errosResolvidos;
                        ExibirResultados();
                        AtualizarInterface();
                    };
                });           
        }
    }
}
