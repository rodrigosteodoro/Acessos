using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Acessos
{
    public class ProdutoDuplicataService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoDuplicataService(ProdutoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public class ResultadoVerificacaoDuplicatas
        {
            public List<Produto> ProdutosNovos { get; set; } = new List<Produto>();
            public List<ProdutoDuplicata> Duplicatas { get; set; } = new List<ProdutoDuplicata>();
            public int TotalVerificados { get; set; }
            public int TotalNovos { get; set; }
            public int TotalDuplicatas { get; set; }
        }

        public class ProdutoDuplicata
        {
            public Produto ProdutoImportado { get; set; }
            public Produto ProdutoExistente { get; set; }
            public List<string> DiferencasEncontradas { get; set; } = new List<string>();
            public TipoDuplicata Tipo { get; set; }
            public AcaoDuplicata AcaoSugerida { get; set; }
        }

        public enum TipoDuplicata
        {
            CodigoProdutoIgual,
            CodigoBarrasIgual,
            NomeCategoriaSimilar,
            DadosIdenticos
        }

        public enum AcaoDuplicata
        {
            Ignorar,
            Atualizar,
            Substituir,
            InserirComCodigoNovo,
            Perguntar
        }

        /// <summary>
        /// Método principal para verificar duplicatas de forma assíncrona.
        /// </summary>
        public async Task<ResultadoVerificacaoDuplicatas> VerificarDuplicatasAsync(List<Produto> produtosImportados)
        {
            var resultado = new ResultadoVerificacaoDuplicatas();
            resultado.TotalVerificados = produtosImportados.Count;

            try
            {
                var produtosExistentes = (await _repository.ObterTodosAsync()).ToList();
                var codigosExistentes = produtosExistentes.ToDictionary(p => p.CodigoProduto.ToUpper(), p => p);
                var codigosBarrasExistentes = produtosExistentes
                    .Where(p => !string.IsNullOrEmpty(p.CodigoBarras))
                    .ToDictionary(p => p.CodigoBarras.ToUpper(), p => p);

                foreach (var produtoImportado in produtosImportados)
                {
                    var duplicataEncontrada = VerificarDuplicataIndividual(
                        produtoImportado,
                        codigosExistentes,
                        codigosBarrasExistentes,
                        produtosExistentes);

                    if (duplicataEncontrada != null)
                    {
                        resultado.Duplicatas.Add(duplicataEncontrada);
                        resultado.TotalDuplicatas++;
                    }
                    else
                    {
                        resultado.ProdutosNovos.Add(produtoImportado);
                        resultado.TotalNovos++;
                    }
                }

                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao verificar duplicatas: {ex.Message}", ex);
            }
        }

        private ProdutoDuplicata VerificarDuplicataIndividual(
            Produto produtoImportado,
            Dictionary<string, Produto> codigosExistentes,
            Dictionary<string, Produto> codigosBarrasExistentes,
            List<Produto> todosExistentes)
        {
            // 1. Verificar por código do produto
            if (!string.IsNullOrEmpty(produtoImportado.CodigoProduto) &&
                codigosExistentes.TryGetValue(produtoImportado.CodigoProduto.ToUpper(), out Produto existentePorCodigo))
            {
                return CriarDuplicata(produtoImportado, existentePorCodigo, TipoDuplicata.CodigoProdutoIgual);
            }

            // 2. Verificar por código de barras
            if (!string.IsNullOrEmpty(produtoImportado.CodigoBarras) &&
                codigosBarrasExistentes.TryGetValue(produtoImportado.CodigoBarras.ToUpper(), out Produto existentePorCodigoBarras))
            {
                return CriarDuplicata(produtoImportado, existentePorCodigoBarras, TipoDuplicata.CodigoBarrasIgual);
            }

            // 3. Verificar por nome e categoria similar
            var produtoSimilar = EncontrarProdutoSimilar(produtoImportado, todosExistentes);
            if (produtoSimilar != null)
            {
                return CriarDuplicata(produtoImportado, produtoSimilar, TipoDuplicata.NomeCategoriaSimilar);
            }

            return null;
        }

        private ProdutoDuplicata CriarDuplicata(Produto importado, Produto existente, TipoDuplicata tipo)
        {
            if (importado == null) throw new ArgumentNullException(nameof(importado));
            if (existente == null) throw new ArgumentNullException(nameof(existente));

            return new ProdutoDuplicata
            {
                ProdutoImportado = importado,
                ProdutoExistente = existente,
                Tipo = tipo,
                DiferencasEncontradas = CompararProdutos(importado, existente),
                AcaoSugerida = SugerirAcao(tipo, importado, existente)
            };
        }

        private List<string> CompararProdutos(Produto importado, Produto existente)
        {
            var diferencas = new List<string>();

            if (importado.Nome != existente.Nome)
                diferencas.Add($"Nome: '{existente.Nome ?? "N/A"}' → '{importado.Nome ?? "N/A"}'");

            if (importado.Descricao != existente.Descricao)
                diferencas.Add($"Descrição: '{existente.Descricao ?? "N/A"}' → '{importado.Descricao ?? "N/A"}'");

            if (importado.Categoria != existente.Categoria)
                diferencas.Add($"Categoria: '{existente.Categoria ?? "N/A"}' → '{importado.Categoria ?? "N/A"}'");

            if (importado.Subcategoria != existente.Subcategoria)
                diferencas.Add($"Subcategoria: '{existente.Subcategoria ?? "N/A"}' → '{importado.Subcategoria ?? "N/A"}'");

            if (importado.PrecoVenda != existente.PrecoVenda)
                diferencas.Add($"Preço Venda: {FormatarMoeda(existente.PrecoVenda)} → {FormatarMoeda(importado.PrecoVenda)}");

            if (importado.PrecoCusto != existente.PrecoCusto)
                diferencas.Add($"Preço Custo: {FormatarMoeda(existente.PrecoCusto)} → {FormatarMoeda(importado.PrecoCusto)}");

            if (importado.MargemLucro != existente.MargemLucro)
                diferencas.Add($"Margem Lucro: {FormatarPorcentagem(existente.MargemLucro)} → {FormatarPorcentagem(importado.MargemLucro)}");

            if (importado.QuantidadeAtual != existente.QuantidadeAtual)
                diferencas.Add($"Estoque: {FormatarDecimal(existente.QuantidadeAtual)} → {FormatarDecimal(importado.QuantidadeAtual)}");

            if (importado.Peso != existente.Peso)
                diferencas.Add($"Peso: {FormatarDecimal(existente.Peso)} kg → {FormatarDecimal(importado.Peso)} kg");

            if (importado.Volume != existente.Volume)
                diferencas.Add($"Volume: {FormatarDecimal(existente.Volume)} m³ → {FormatarDecimal(importado.Volume)} m³");

            if (importado.FornecedorID != existente.FornecedorID)
                diferencas.Add($"Fornecedor ID: {existente.FornecedorID} → {importado.FornecedorID}");

            if (importado.Ativo != existente.Ativo)
                diferencas.Add($"Ativo: {existente.Ativo} → {importado.Ativo}");

            return diferencas;
        }

        private string FormatarMoeda(decimal valor) => valor.ToString("C2", CultureInfo.CurrentCulture);
        private string FormatarDecimal(decimal valor) => valor.ToString("N3", CultureInfo.CurrentCulture);
        private string FormatarPorcentagem(decimal valor) => valor.ToString("P2", CultureInfo.CurrentCulture);

        private Produto EncontrarProdutoSimilar(Produto produtoImportado, List<Produto> existentes)
        {
            return existentes.FirstOrDefault(p =>
                p.Nome.Equals(produtoImportado.Nome, StringComparison.OrdinalIgnoreCase) &&
                p.Categoria.Equals(produtoImportado.Categoria, StringComparison.OrdinalIgnoreCase));
        }

        private AcaoDuplicata SugerirAcao(TipoDuplicata tipo, Produto importado, Produto existente)
        {
            return tipo switch
            {
                TipoDuplicata.DadosIdenticos => AcaoDuplicata.Ignorar,
                TipoDuplicata.CodigoProdutoIgual => importado.Equals(existente) ?
                                             AcaoDuplicata.Ignorar :
                                             AcaoDuplicata.Atualizar,
                _ => AcaoDuplicata.Perguntar
            };
        }

        /// <summary>
        /// Processa as duplicatas aplicando a ação sugerida (ou a ação escolhida pelo usuário).
        /// </summary>
        public async Task ProcessarDuplicatasAsync(List<ProdutoDuplicata> duplicatas, Func<ProdutoDuplicata, AcaoDuplicata, Task> aplicarAcaoAsync)
        {
            foreach (var duplicata in duplicatas)
            {
                if (aplicarAcaoAsync != null)
                    await aplicarAcaoAsync(duplicata, duplicata.AcaoSugerida);
            }
        }

        // Métodos de aplicação de ações
        public async Task AplicarAcaoAtualizarAsync(ProdutoDuplicata duplicata)
        {
            var existente = duplicata.ProdutoExistente;
            var importado = duplicata.ProdutoImportado;

            existente.Nome = importado.Nome;
            existente.Descricao = importado.Descricao ?? existente.Descricao;
            existente.Categoria = importado.Categoria;
            existente.Subcategoria = importado.Subcategoria ?? existente.Subcategoria;
            existente.Marca = importado.Marca ?? existente.Marca;
            existente.PrecoCusto = importado.PrecoCusto;
            existente.PrecoVenda = importado.PrecoVenda;
            existente.MargemLucro = importado.MargemLucro;
            existente.QuantidadeAtual = importado.QuantidadeAtual;
            existente.UnidadeMedida = importado.UnidadeMedida;
            existente.Peso = importado.Peso;
            existente.Volume = importado.Volume;
            existente.FornecedorID = importado.FornecedorID;
            existente.NomeFornecedor = importado.NomeFornecedor ?? existente.NomeFornecedor;
            existente.Lote = importado.Lote ?? existente.Lote;
            existente.DataValidade = importado.DataValidade != default ? importado.DataValidade : existente.DataValidade;

            existente.UltimaAlteracao = DateTime.Now;
            existente.Ativo = importado.Ativo;

            await _repository.Atualizar(existente);
        }

        public async Task AplicarAcaoSubstituirAsync(ProdutoDuplicata duplicata)
        {
            var importado = duplicata.ProdutoImportado;
            importado.ID = duplicata.ProdutoExistente.ID;
            await _repository.Atualizar(importado);
        }

        public async Task AplicarAcaoInserirComCodigoNovoAsync(ProdutoDuplicata duplicata)
        {
            var importado = duplicata.ProdutoImportado;
            importado.CodigoProduto = await GerarCodigoUnicoAsync(importado.CodigoProduto);
            await _repository.Inserir(importado);
        }

        private async Task<string> GerarCodigoUnicoAsync(string codigoOriginal)
        {
            var contador = 1;
            string novoCodigo;

            do
            {
                novoCodigo = $"{codigoOriginal}_{contador:000}";
                contador++;
            } while (await _repository.ExistePorCodigoAsync(novoCodigo));

            return novoCodigo;
        }
    }
}
