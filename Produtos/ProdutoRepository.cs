using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Acessos
{
    public class ProdutoRepository
    {
        private readonly string _connectionString = ConnectionManager.GetConnectionString("Admin");

        public async Task<int> Inserir(IProdutos produto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"INSERT INTO Produtos (
                    CodigoProduto, CodigoBarras, Nome, Descricao, Peso, Volume, DataValidade, Lote,
                    Categoria, Subcategoria, Marca, FornecedorID, NomeFornecedor, UnidadeMedida, TipoProduto, 
                    QuantidadeAtual, EstoqueMinimo, EstoqueMaximo, LocalizacaoEstoque, PermiteEstoqueNegativo, 
                    PrecoCusto, PrecoVenda, MargemLucro, PromocaoAtiva, PrecoPromocional, InicioPromocao, 
                    FimPromocao, OrigemProduto, NCM, CFOP, CSTCSOSN, AliquotaICMS, AliquotaPIS, AliquotaCOFINS, 
                    AliquotaIPI, Imagem, Ativo, Observacoes, SKU, DataCadastro, UltimaAlteracao
                ) VALUES (
                    @CodigoProduto, @CodigoBarras, @Nome, @Descricao, @Peso, @Volume, @DataValidade, @Lote,
                    @Categoria, @Subcategoria, @Marca, @FornecedorID, @NomeFornecedor, @UnidadeMedida, @TipoProduto,
                    @QuantidadeAtual, @EstoqueMinimo, @EstoqueMaximo, @LocalizacaoEstoque, @PermiteEstoqueNegativo, 
                    @PrecoCusto, @PrecoVenda, @MargemLucro, @PromocaoAtiva, @PrecoPromocional, @InicioPromocao, 
                    @FimPromocao, @OrigemProduto, @NCM, @CFOP, @CSTCSOSN, @AliquotaICMS, @AliquotaPIS, @AliquotaCOFINS, 
                    @AliquotaIPI, @Imagem, @Ativo, @Observacoes, @SKU, @DataCadastro, @UltimaAlteracao
                ); SELECT SCOPE_IDENTITY();";

                return await connection.ExecuteScalarAsync<int>(sql, produto);
            }
        }

        public async Task Atualizar(IProdutos produto)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = @"UPDATE Produtos SET
                    CodigoProduto = @CodigoProduto,
                    CodigoBarras = @CodigoBarras,
                    Nome = @Nome,
                    Descricao = @Descricao,
                    Peso = @Peso,
                    Volume = @Volume,
                    DataValidade = @DataValidade,
                    Lote = @Lote,
                    Categoria = @Categoria,
                    Subcategoria = @Subcategoria,
                    Marca = @Marca,
                    FornecedorID = @FornecedorID,
                    NomeFornecedor = @NomeFornecedor,
                    UnidadeMedida = @UnidadeMedida,
                    TipoProduto = @TipoProduto,
                    QuantidadeAtual = @QuantidadeAtual,
                    EstoqueMinimo = @EstoqueMinimo,
                    EstoqueMaximo = @EstoqueMaximo,
                    LocalizacaoEstoque = @LocalizacaoEstoque,
                    PermiteEstoqueNegativo = @PermiteEstoqueNegativo,
                    PrecoCusto = @PrecoCusto,
                    PrecoVenda = @PrecoVenda,
                    MargemLucro = @MargemLucro,
                    PromocaoAtiva = @PromocaoAtiva,
                    PrecoPromocional = @PrecoPromocional,
                    InicioPromocao = @InicioPromocao,
                    FimPromocao = @FimPromocao,
                    OrigemProduto = @OrigemProduto,
                    NCM = @NCM,
                    CFOP = @CFOP,
                    CSTCSOSN = @CSTCSOSN,
                    AliquotaICMS = @AliquotaICMS,
                    AliquotaPIS = @AliquotaPIS,
                    AliquotaCOFINS = @AliquotaCOFINS,
                    AliquotaIPI = @AliquotaIPI,
                    Imagem = @Imagem,
                    Ativo = @Ativo,
                    Observacoes = @Observacoes,
                    SKU = @SKU,
                    DataCadastro = @DataCadastro,
                    UltimaAlteracao = @UltimaAlteracao
                WHERE ID = @ID";

                await connection.ExecuteAsync(sql, produto);
            }
        }

        public async Task<IProdutos> ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                return await connection.QueryFirstOrDefaultAsync<Produto>(
                    "SELECT * FROM Produtos WHERE ID = @ID",
                    new { ID = id }
                );
            }
        }

        public async Task<List<IProdutos>> ObterTodos()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<Produto>("SELECT * FROM Produtos");
                return result.Cast<IProdutos>().ToList();
            }
        }

        public async Task<bool> ExistePorCodigoAsync(string codigo)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var count = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT(1) FROM Produtos WHERE CodigoProduto = @Codigo",
                    new { Codigo = codigo }
                );
                return count > 0;
            }
        }

        public async Task<bool> ExistePorCodigoBarras(string codigoBarras)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var count = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT(1) FROM Produtos WHERE CodigoBarras = @CodigoBarras",
                    new { CodigoBarras = codigoBarras }
                );
                return count > 0;
            }
        }

        public async Task Deletar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(
                    "DELETE FROM Produtos WHERE ID = @ID",
                    new { ID = id }
                );
            }
        }

        public async Task<bool> AtualizarEmLote(List<IProdutos> produtos)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var sql = @"UPDATE Produtos SET 
                            PrecoVenda = @PrecoVenda, 
                            QuantidadeAtual = @QuantidadeAtual,
                            Ativo = @Ativo,
                            UltimaAlteracao = @UltimaAlteracao
                        WHERE ID = @ID";

                        await connection.ExecuteAsync(sql, produtos, transaction);
                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<List<IProdutos>> Buscar(string termo = null, string categoria = null, string marca = null, bool ativo = true)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = @"SELECT * FROM Produtos 
                          WHERE (@termo IS NULL OR 
                                 Nome LIKE '%' + @termo + '%' OR 
                                 Descricao LIKE '%' + @termo + '%')
                          AND (@categoria IS NULL OR Categoria = @categoria)
                          AND (@marca IS NULL OR Marca = @marca)
                          AND Ativo = @ativo";

                var result = await connection.QueryAsync<Produto>(sql, new
                {
                    termo,
                    categoria,
                    marca,
                    ativo
                });
                return result.Cast<IProdutos>().ToList();
            }
        }              
      
        public async Task<List<Produto>> ObterTodosAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var result = await connection.QueryAsync<Produto>("SELECT * FROM Produtos");
                return result.ToList();
            }
        }
        

    }
}
