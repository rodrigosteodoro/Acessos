using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Acessos
{
    public class ProdutoDAL
    {
        private readonly string connectionString;

        public ProdutoDAL()
        {
            connectionString = ConnectionManager.GetConnectionString("Admin");
        }

        public async Task<int> ObterProximoCodigo()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT ISNULL(MAX(CAST(CodigoProduto AS INT)), 0) + 1 FROM Produtos";
                using (var command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }

        public async Task<int> InserirProduto(IProdutos produto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    INSERT INTO Produtos 
                    (CodigoProduto, CodigoBarras, Nome, Descricao, Peso, Volume, DataValidade, Lote,
                     Categoria, Subcategoria, Marca, FornecedorID, NomeFornecedor, UnidadeMedida, TipoProduto,
                     QuantidadeAtual, EstoqueMinimo, EstoqueMaximo, LocalizacaoEstoque, PermiteEstoqueNegativo,
                     PrecoCusto, PrecoVenda, MargemLucro, PromocaoAtiva, PrecoPromocional, InicioPromocao,
                     FimPromocao, OrigemProduto, NCM, CFOP, CSTCSOSN, AliquotaICMS, AliquotaPIS, AliquotaCOFINS,
                     AliquotaIPI, Imagem, Ativo, Observacoes, SKU, DataCadastro, UltimaAlteracao)
                    VALUES 
                    (@CodigoProduto, @CodigoBarras, @Nome, @Descricao, @Peso, @Volume, @DataValidade, @Lote,
                     @Categoria, @Subcategoria, @Marca, @FornecedorID, @NomeFornecedor, @UnidadeMedida, @TipoProduto,
                     @QuantidadeAtual, @EstoqueMinimo, @EstoqueMaximo, @LocalizacaoEstoque, @PermiteEstoqueNegativo,
                     @PrecoCusto, @PrecoVenda, @MargemLucro, @PromocaoAtiva, @PrecoPromocional, @InicioPromocao,
                     @FimPromocao, @OrigemProduto, @NCM, @CFOP, @CSTCSOSN, @AliquotaICMS, @AliquotaPIS, @AliquotaCOFINS,
                     @AliquotaIPI, @Imagem, @Ativo, @Observacoes, @SKU, @DataCadastro, @UltimaAlteracao);
                    SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    AdicionarParametros(command, produto);
                    await connection.OpenAsync();
                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }

        public async Task<bool> AtualizarProduto(IProdutos produto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    UPDATE Produtos SET
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

                using (var command = new SqlCommand(query, connection))
                {
                    AdicionarParametros(command, produto);
                    command.Parameters.AddWithValue("@ID", produto.ID);
                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> ExcluirProduto(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "DELETE FROM Produtos WHERE ID = @ID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<IProdutos> ObterProdutoPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"SELECT * FROM Produtos WHERE ID = @ID";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapearProduto(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<IProdutos> ObterProdutoPorCodigo(string codigo)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"SELECT * FROM Produtos WHERE CodigoProduto = @Codigo OR CodigoBarras = @Codigo";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Codigo", codigo);
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapearProduto(reader);
                        }
                    }
                }
            }
            return null;
        }

        public async Task<List<IProdutos>> ObterTodosProdutos()
        {
            var produtos = new List<IProdutos>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"SELECT * FROM Produtos WHERE Ativo = 1 ORDER BY Nome";
                using (var command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            produtos.Add(MapearProduto(reader));
                        }
                    }
                }
            }
            return produtos;
        }

        public async Task<List<IProdutos>> BuscarProdutos(string filtro)
        {
            var produtos = new List<IProdutos>();
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT * FROM Produtos 
                    WHERE Ativo = 1 
                      AND (Nome LIKE @Filtro 
                           OR CodigoProduto LIKE @Filtro 
                           OR CodigoBarras LIKE @Filtro
                           OR Categoria LIKE @Filtro)
                    ORDER BY Nome";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Filtro", $"%{filtro}%");
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            produtos.Add(MapearProduto(reader));
                        }
                    }
                }
            }
            return produtos;
        }
        private void AdicionarParametros(SqlCommand command, IProdutos produto)
        {
            command.Parameters.AddWithValue("@CodigoProduto", produto.CodigoProduto ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CodigoBarras", produto.CodigoBarras ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Nome", produto.Nome ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Descricao", produto.Descricao ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Peso", produto.Peso);
            command.Parameters.AddWithValue("@Volume", produto.Volume);
            command.Parameters.AddWithValue("@DataValidade", produto.DataValidade);
            command.Parameters.AddWithValue("@Lote", produto.Lote ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Categoria", produto.Categoria ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Subcategoria", produto.Subcategoria ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Marca", produto.Marca ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FornecedorID", produto.FornecedorID);
            command.Parameters.AddWithValue("@NomeFornecedor", produto.NomeFornecedor ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UnidadeMedida", produto.UnidadeMedida ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TipoProduto", produto.TipoProduto ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@QuantidadeAtual", produto.QuantidadeAtual);
            command.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
            command.Parameters.AddWithValue("@EstoqueMaximo", produto.EstoqueMaximo);
            command.Parameters.AddWithValue("@LocalizacaoEstoque", produto.LocalizacaoEstoque ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@PermiteEstoqueNegativo", produto.PermiteEstoqueNegativo);
            command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
            command.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
            command.Parameters.AddWithValue("@MargemLucro", produto.MargemLucro);
            command.Parameters.AddWithValue("@PromocaoAtiva", produto.PromocaoAtiva);
            command.Parameters.AddWithValue("@PrecoPromocional", produto.PrecoPromocional ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@InicioPromocao", produto.InicioPromocao ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FimPromocao", produto.FimPromocao ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@OrigemProduto", produto.OrigemProduto ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NCM", produto.NCM ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CFOP", produto.CFOP ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CSTCSOSN", produto.CSTCSOSN ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@AliquotaICMS", produto.AliquotaICMS);
            command.Parameters.AddWithValue("@AliquotaPIS", produto.AliquotaPIS);
            command.Parameters.AddWithValue("@AliquotaCOFINS", produto.AliquotaCOFINS);
            command.Parameters.AddWithValue("@AliquotaIPI", produto.AliquotaIPI);
            command.Parameters.AddWithValue("@Imagem", produto.Imagem ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ativo", produto.Ativo);
            command.Parameters.AddWithValue("@Observacoes", produto.Observacoes ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@SKU", produto.SKU ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);
            command.Parameters.AddWithValue("@UltimaAlteracao", produto.UltimaAlteracao);
        }

        private IProdutos MapearProduto(IDataReader reader)
        {
            // Aqui você pode retornar uma instância de Produto que implementa IProdutos
            return new Produto
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                CodigoProduto = reader.IsDBNull(reader.GetOrdinal("CodigoProduto")) ? null : reader.GetString(reader.GetOrdinal("CodigoProduto")),
                CodigoBarras = reader.IsDBNull(reader.GetOrdinal("CodigoBarras")) ? null : reader.GetString(reader.GetOrdinal("CodigoBarras")),
                Nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? null : reader.GetString(reader.GetOrdinal("Nome")),
                Descricao = reader.IsDBNull(reader.GetOrdinal("Descricao")) ? null : reader.GetString(reader.GetOrdinal("Descricao")),
                Peso = reader.IsDBNull(reader.GetOrdinal("Peso")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Peso")),
                Volume = reader.IsDBNull(reader.GetOrdinal("Volume")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Volume")),
                DataValidade = reader.IsDBNull(reader.GetOrdinal("DataValidade")) ? DateTime.MinValue : reader.GetDateTime(reader.GetOrdinal("DataValidade")),
                Lote = reader.IsDBNull(reader.GetOrdinal("Lote")) ? null : reader.GetString(reader.GetOrdinal("Lote")),
                Categoria = reader.IsDBNull(reader.GetOrdinal("Categoria")) ? null : reader.GetString(reader.GetOrdinal("Categoria")),
                Subcategoria = reader.IsDBNull(reader.GetOrdinal("Subcategoria")) ? null : reader.GetString(reader.GetOrdinal("Subcategoria")),
                Marca = reader.IsDBNull(reader.GetOrdinal("Marca")) ? null : reader.GetString(reader.GetOrdinal("Marca")),
                FornecedorID = reader.GetInt32(reader.GetOrdinal("FornecedorID")),
                NomeFornecedor = reader.IsDBNull(reader.GetOrdinal("NomeFornecedor")) ? null : reader.GetString(reader.GetOrdinal("NomeFornecedor")),
                UnidadeMedida = reader.IsDBNull(reader.GetOrdinal("UnidadeMedida")) ? null : reader.GetString(reader.GetOrdinal("UnidadeMedida")),
                TipoProduto = reader.IsDBNull(reader.GetOrdinal("TipoProduto")) ? null : reader.GetString(reader.GetOrdinal("TipoProduto")),
                QuantidadeAtual = reader.GetDecimal(reader.GetOrdinal("QuantidadeAtual")),
                EstoqueMinimo = reader.GetDecimal(reader.GetOrdinal("EstoqueMinimo")),
                EstoqueMaximo = reader.GetDecimal(reader.GetOrdinal("EstoqueMaximo")),
                LocalizacaoEstoque = reader.IsDBNull(reader.GetOrdinal("LocalizacaoEstoque")) ? null : reader.GetString(reader.GetOrdinal("LocalizacaoEstoque")),
                PermiteEstoqueNegativo = reader.GetBoolean(reader.GetOrdinal("PermiteEstoqueNegativo")),
                PrecoCusto = reader.GetDecimal(reader.GetOrdinal("PrecoCusto")),
                PrecoVenda = reader.GetDecimal(reader.GetOrdinal("PrecoVenda")),
                MargemLucro = reader.GetDecimal(reader.GetOrdinal("MargemLucro")),
                PromocaoAtiva = reader.GetBoolean(reader.GetOrdinal("PromocaoAtiva")),
                PrecoPromocional = reader.IsDBNull(reader.GetOrdinal("PrecoPromocional")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("PrecoPromocional")),
                InicioPromocao = reader.IsDBNull(reader.GetOrdinal("InicioPromocao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("InicioPromocao")),
                FimPromocao = reader.IsDBNull(reader.GetOrdinal("FimPromocao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FimPromocao")),
                OrigemProduto = reader.IsDBNull(reader.GetOrdinal("OrigemProduto")) ? null : reader.GetString(reader.GetOrdinal("OrigemProduto")),
                NCM = reader.IsDBNull(reader.GetOrdinal("NCM")) ? null : reader.GetString(reader.GetOrdinal("NCM")),
                CFOP = reader.IsDBNull(reader.GetOrdinal("CFOP")) ? null : reader.GetString(reader.GetOrdinal("CFOP")),
                CSTCSOSN = reader.IsDBNull(reader.GetOrdinal("CSTCSOSN")) ? null : reader.GetString(reader.GetOrdinal("CSTCSOSN")),
                AliquotaICMS = reader.GetDecimal(reader.GetOrdinal("AliquotaICMS")),
                AliquotaPIS = reader.GetDecimal(reader.GetOrdinal("AliquotaPIS")),
                AliquotaCOFINS = reader.GetDecimal(reader.GetOrdinal("AliquotaCOFINS")),
                AliquotaIPI = reader.GetDecimal(reader.GetOrdinal("AliquotaIPI")),
                Imagem = reader.IsDBNull(reader.GetOrdinal("Imagem")) ? null : (byte[])reader["Imagem"],
                Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo")),
                Observacoes = reader.IsDBNull(reader.GetOrdinal("Observacoes")) ? null : reader.GetString(reader.GetOrdinal("Observacoes")),
                SKU = reader.IsDBNull(reader.GetOrdinal("SKU")) ? null : reader.GetString(reader.GetOrdinal("SKU")),
                DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                UltimaAlteracao = reader.GetDateTime(reader.GetOrdinal("UltimaAlteracao"))
            };
        }
        public async Task<int> InserirProdutoAsync(IProdutos produto)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("InserirProdutoComFornecedor", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Parâmetros do fornecedor
                    command.Parameters.AddWithValue("@RazaoSocial", produto.NomeFornecedor ?? "");
                    command.Parameters.AddWithValue("@NomeFantasia", DBNull.Value); // ou produto.NomeFantasia, se houver
                    command.Parameters.AddWithValue("@CNPJ", produto.NomeFornecedor ?? "00000000000000"); // ajuste conforme seu modelo
                    command.Parameters.AddWithValue("@DataFundacao", DBNull.Value);
                    command.Parameters.AddWithValue("@Telefone", DBNull.Value);
                    command.Parameters.AddWithValue("@Email", DBNull.Value);
                    command.Parameters.AddWithValue("@Site", DBNull.Value);
                    command.Parameters.AddWithValue("@Endereco", DBNull.Value);
                    command.Parameters.AddWithValue("@Numero", DBNull.Value);
                    command.Parameters.AddWithValue("@CEP", DBNull.Value);
                    command.Parameters.AddWithValue("@Logradouro", DBNull.Value);
                    command.Parameters.AddWithValue("@Bairro", DBNull.Value);
                    command.Parameters.AddWithValue("@Localidade", DBNull.Value);
                    command.Parameters.AddWithValue("@UF", DBNull.Value);
                    command.Parameters.AddWithValue("@Estado", DBNull.Value);
                    command.Parameters.AddWithValue("@Regiao", DBNull.Value);
                    command.Parameters.AddWithValue("@IBGE", DBNull.Value);
                    command.Parameters.AddWithValue("@Complemento", DBNull.Value);
                    command.Parameters.AddWithValue("@Contato", DBNull.Value);
                    command.Parameters.AddWithValue("@TipoFornecedor", DBNull.Value);
                    command.Parameters.AddWithValue("@Status", DBNull.Value);
                    command.Parameters.AddWithValue("@ObservacoesFornecedor", DBNull.Value);

                    // Parâmetros do produto
                    command.Parameters.AddWithValue("@CodigoProduto", produto.CodigoProduto ?? "");
                    command.Parameters.AddWithValue("@CodigoBarras", produto.CodigoBarras ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Nome", produto.Nome ?? "");
                    command.Parameters.AddWithValue("@Descricao", produto.Descricao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Peso", produto.Peso);
                    command.Parameters.AddWithValue("@Volume", produto.Volume);
                    command.Parameters.AddWithValue("@DataValidade", produto.DataValidade ?? DateTime.Now);
                    command.Parameters.AddWithValue("@Lote", produto.Lote ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Categoria", produto.Categoria ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Subcategoria", produto.Subcategoria ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@Marca", produto.Marca ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@UnidadeMedida", produto.UnidadeMedida ?? "UN");
                    command.Parameters.AddWithValue("@TipoProduto", produto.TipoProduto ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@QuantidadeAtual", produto.QuantidadeAtual);
                    command.Parameters.AddWithValue("@EstoqueMinimo", produto.EstoqueMinimo);
                    command.Parameters.AddWithValue("@EstoqueMaximo", produto.EstoqueMaximo);
                    command.Parameters.AddWithValue("@LocalizacaoEstoque", produto.LocalizacaoEstoque ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@PermiteEstoqueNegativo", produto.PermiteEstoqueNegativo);
                    command.Parameters.AddWithValue("@PrecoCusto", produto.PrecoCusto);
                    command.Parameters.AddWithValue("@PrecoVenda", produto.PrecoVenda);
                    command.Parameters.AddWithValue("@MargemLucro", produto.MargemLucro);
                    command.Parameters.AddWithValue("@PromocaoAtiva", produto.PromocaoAtiva);
                    command.Parameters.AddWithValue("@PrecoPromocional", produto.PrecoPromocional ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@InicioPromocao", produto.InicioPromocao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@FimPromocao", produto.FimPromocao ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@OrigemProduto", produto.OrigemProduto ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@NCM", produto.NCM ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CFOP", produto.CFOP ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@CSTCSOSN", produto.CSTCSOSN ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@AliquotaICMS", produto.AliquotaICMS);
                    command.Parameters.AddWithValue("@AliquotaPIS", produto.AliquotaPIS);
                    command.Parameters.AddWithValue("@AliquotaCOFINS", produto.AliquotaCOFINS);
                    command.Parameters.AddWithValue("@AliquotaIPI", produto.AliquotaIPI);
                    command.Parameters.AddWithValue("@Ativo", produto.Ativo);
                    command.Parameters.AddWithValue("@ObservacoesProduto", produto.Observacoes ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@SKU", produto.SKU ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@DataCadastro", produto.DataCadastro);
                    command.Parameters.AddWithValue("@UltimaAlteracao", produto.UltimaAlteracao);

                    await connection.OpenAsync();
                    var result = await command.ExecuteNonQueryAsync();
                    return result; // retorna o número de linhas afetadas
                }
            }
        }


    }
}
