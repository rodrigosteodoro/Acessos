using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Acessos.Orcamentos;
using Dapper;

namespace Acessos
{
    public class OrcamentoRepository : IOrcamentoRepository
    {
        private readonly string connectionString;

        public OrcamentoRepository()
        {
            connectionString = ConnectionManager.GetConnectionString("Admin");
        }

        public async Task<int> InserirOrcamentoAsync(IOrcamento orcamento)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlInsert = @"INSERT INTO Orcamentos 
                            (CodigoOrcamento, ClienteID, DataCriacao, DataValidade, 
                             DescontoGeral, Observacoes, Status, DataCadastro, UltimaModificacao, Ativo)
                            VALUES (@CodigoOrcamento, @ClienteID, @DataCriacao, @DataValidade, 
                                    @DescontoGeral, @Observacoes, @Status, @DataCadastro, @UltimaModificacao, @Ativo);
                            SELECT SCOPE_IDENTITY();";

                        using (var cmd = new SqlCommand(sqlInsert, connection, transaction))
                        {
                            AdicionarParametrosOrcamento(cmd, orcamento);
                            var result = await cmd.ExecuteScalarAsync();
                            orcamento.ID = Convert.ToInt32(result);
                        }

                        foreach (var item in orcamento.Itens)
                        {
                            string sqlItem = @"INSERT INTO ItensOrcamento 
                                (OrcamentoID, ProdutoID, DescricaoProduto, Quantidade, PrecoUnitario, 
                                 Desconto, DataCadastro, Ativo)
                                VALUES (@OrcamentoID, @ProdutoID, @DescricaoProduto, @Quantidade, 
                                        @PrecoUnitario, @Desconto, @DataCadastro, @Ativo);
                                SELECT SCOPE_IDENTITY();";

                            using (var cmd = new SqlCommand(sqlItem, connection, transaction))
                            {
                                AdicionarParametrosItem(cmd, item, orcamento.ID);
                                item.ID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                            }
                        }

                        transaction.Commit();
                        return orcamento.ID;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public async Task<bool> AtualizarOrcamentoAsync(IOrcamento orcamento)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string sqlUpdate = @"UPDATE Orcamentos SET
                                ClienteID = @ClienteID,
                                DataValidade = @DataValidade,
                                DescontoGeral = @DescontoGeral,
                                Observacoes = @Observacoes,
                                Status = @Status,
                                UltimaModificacao = @UltimaModificacao
                            WHERE ID = @ID";

                        using (var cmd = new SqlCommand(sqlUpdate, connection, transaction))
                        {
                            AdicionarParametrosOrcamento(cmd, orcamento, true);
                            int affected = await cmd.ExecuteNonQueryAsync();
                            if (affected == 0)
                                throw new Exception("Orçamento não encontrado.");
                        }

                        string sqlDisable = "UPDATE ItensOrcamento SET Ativo = 0 WHERE OrcamentoID = @OrcamentoID";
                        using (var cmd = new SqlCommand(sqlDisable, connection, transaction))
                        {
                            cmd.Parameters.AddWithValue("@OrcamentoID", orcamento.ID);
                            await cmd.ExecuteNonQueryAsync();
                        }

                        foreach (var item in orcamento.Itens)
                        {
                            if (item.ID == 0)
                            {
                                string sqlItem = @"INSERT INTO ItensOrcamento 
                                (OrcamentoID, ProdutoID, DescricaoProduto, Quantidade, PrecoUnitario, 
                                 Desconto, DataCadastro, Ativo)
                                VALUES (@OrcamentoID, @ProdutoID, @DescricaoProduto, @Quantidade, 
                                        @PrecoUnitario, @Desconto, @DataCadastro, @Ativo);
                                SELECT SCOPE_IDENTITY();";
                                using (var cmd = new SqlCommand(sqlItem, connection, transaction))
                                {
                                    AdicionarParametrosItem(cmd, item, orcamento.ID);
                                    item.ID = Convert.ToInt32(await cmd.ExecuteScalarAsync());
                                }
                            }
                            else
                            {
                                string sqlUpdateItem = @"UPDATE ItensOrcamento SET
                                    ProdutoID = @ProdutoID,
                                    DescricaoProduto = @DescricaoProduto,
                                    Quantidade = @Quantidade,
                                    PrecoUnitario = @PrecoUnitario,
                                    Desconto = @Desconto,
                                    Ativo = @Ativo
                                WHERE ID = @ID AND OrcamentoID = @OrcamentoID";

                                using (var cmd = new SqlCommand(sqlUpdateItem, connection, transaction))
                                {
                                    AdicionarParametrosItem(cmd, item, orcamento.ID, true);
                                    await cmd.ExecuteNonQueryAsync();
                                }
                            }
                        }

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

        public async Task<bool> CancelarOrcamentoAsync(int orcamentoId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "UPDATE Orcamentos SET Ativo = 0 WHERE ID = @ID";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", orcamentoId);
                    await connection.OpenAsync();
                    int result = await cmd.ExecuteNonQueryAsync();
                    return result > 0;
                }
            }
        }

        public async Task<IOrcamento> ObterOrcamentoPorIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Orcamentos WHERE ID = @ID AND Ativo = 1";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    await connection.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var orc = MapearOrcamento(reader);
                            var itens = await ObterItensOrcamentoAsync(orc.ID, connection);
                            orc.Itens = itens.Cast<IItemOrcamento>().ToList();
                            return orc; // retorna o orçamento localizado
                        }
                    }
                }
            }
            return null; // caso não encontre nenhum orçamento com esse ID
        }

        public async Task<List<IOrcamento>> ObterOrcamentosPorClienteAsync(int clienteId)
        {
            var orcamentos = new List<IOrcamento>();
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Orcamentos WHERE ClienteID = @ClienteID AND Ativo = 1";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@ClienteID", clienteId);
                    await connection.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var orc = MapearOrcamento(reader);
                            var itens = await ObterItensOrcamentoAsync(orc.ID, connection);
                            orc.Itens = itens.Cast<IItemOrcamento>().ToList();
                            orcamentos.Add((IOrcamento)orc);
                        }
                    }
                }
            }
            return orcamentos;
        }

        public async Task<List<IOrcamento>> ObterTodosOrcamentosAsync()
        {
            var orcamentos = new List<IOrcamento>();
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Orcamentos WHERE Ativo = 1";
                using (var cmd = new SqlCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var orc = MapearOrcamento(reader);
                            var itens = await ObterItensOrcamentoAsync(orc.ID, connection);
                            orc.Itens = itens.Cast<IItemOrcamento>().ToList();
                            orcamentos.Add((IOrcamento)orc);
                        }
                    }
                }
            }
            return orcamentos;
        }

        #region Métodos auxiliares

        private void AdicionarParametrosOrcamento(SqlCommand cmd, IOrcamento orcamento, bool update = false)
        {
            cmd.Parameters.AddWithValue("@CodigoOrcamento", orcamento.CodigoOrcamento ?? string.Empty);
            cmd.Parameters.AddWithValue("@ClienteID", orcamento.ClienteID);
            cmd.Parameters.AddWithValue("@DataCriacao", orcamento.DataCriacao);
            cmd.Parameters.AddWithValue("@DataValidade", (object)orcamento.DataValidade ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@DescontoGeral", orcamento.DescontoGeral);
            cmd.Parameters.AddWithValue("@Observacoes", orcamento.Observacoes ?? "");
            cmd.Parameters.AddWithValue("@Status", (int)orcamento.Status);
            cmd.Parameters.AddWithValue("@UltimaModificacao", DateTime.Now);
            if (!update)
            {
                cmd.Parameters.AddWithValue("@DataCadastro", orcamento.DataCadastro);
                cmd.Parameters.AddWithValue("@Ativo", orcamento.Ativo);
            }
            else
            {
                cmd.Parameters.AddWithValue("@ID", orcamento.ID);
            }
        }

        private void AdicionarParametrosItem(SqlCommand cmd, IItemOrcamento item, int orcamentoId, bool update = false)
        {
            cmd.Parameters.AddWithValue("@OrcamentoID", orcamentoId);
            cmd.Parameters.AddWithValue("@ProdutoID", item.ProdutoID);
            cmd.Parameters.AddWithValue("@DescricaoProduto", item.DescricaoProduto ?? "");
            cmd.Parameters.AddWithValue("@Quantidade", item.Quantidade);
            cmd.Parameters.AddWithValue("@PrecoUnitario", item.PrecoUnitario);
            cmd.Parameters.AddWithValue("@Desconto", item.Desconto);
            cmd.Parameters.AddWithValue("@DataCadastro", item.DataCadastro);
            cmd.Parameters.AddWithValue("@Ativo", item.Ativo);
            if (update)
                cmd.Parameters.AddWithValue("@ID", item.ID);
        }

        private Orcamento MapearOrcamento(IDataRecord reader)
        {
            return new Orcamento
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                CodigoOrcamento = reader.GetString(reader.GetOrdinal("CodigoOrcamento")),
                ClienteID = reader.GetInt32(reader.GetOrdinal("ClienteID")),
                DataCriacao = reader.GetDateTime(reader.GetOrdinal("DataCriacao")),
                DataValidade = reader.IsDBNull(reader.GetOrdinal("DataValidade")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataValidade")),
                DescontoGeral = reader.GetDecimal(reader.GetOrdinal("DescontoGeral")),
                Observacoes = reader.IsDBNull(reader.GetOrdinal("Observacoes")) ? null : reader.GetString(reader.GetOrdinal("Observacoes")),
                Status = (StatusOrcamento)reader.GetInt32(reader.GetOrdinal("Status")),
                DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                UltimaModificacao = reader.GetDateTime(reader.GetOrdinal("UltimaModificacao")),
                Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
            };
        }

        private async Task<List<ItemOrcamento>> ObterItensOrcamentoAsync(int orcamentoId, SqlConnection connection)
        {
            var itens = new List<ItemOrcamento>();
            var sql = @"SELECT * FROM ItensOrcamento WHERE OrcamentoID = @OrcamentoID AND Ativo = 1";
            using (var cmd = new SqlCommand(sql, connection))
            {
                cmd.Parameters.AddWithValue("@OrcamentoID", orcamentoId);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        itens.Add(new ItemOrcamento
                        {
                            ID = reader.GetInt32(reader.GetOrdinal("ID")),
                            OrcamentoID = reader.GetInt32(reader.GetOrdinal("OrcamentoID")),
                            ProdutoID = reader.GetInt32(reader.GetOrdinal("ProdutoID")),
                            DescricaoProduto = reader.IsDBNull(reader.GetOrdinal("DescricaoProduto")) ? null : reader.GetString(reader.GetOrdinal("DescricaoProduto")),
                            Quantidade = reader.GetDecimal(reader.GetOrdinal("Quantidade")),
                            PrecoUnitario = reader.GetDecimal(reader.GetOrdinal("PrecoUnitario")),
                            Desconto = reader.GetDecimal(reader.GetOrdinal("Desconto")),
                            DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                            Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
                        });
                    }
                }
            }
            return itens;
        }

        public async Task<List<OrcamentoAprovacaoModel>> ObterOrcamentosParaAprovacaoAsync(
            int? status,
            DateTime dataInicio,
            DateTime dataFim)
        {
            var result = new List<OrcamentoAprovacaoModel>();

            using (var conn = new SqlConnection(connectionString))
            {
                var sql = @"SELECT 
                o.ID, 
                o.CodigoOrcamento, 
                c.Nome AS NomeCliente, 
                c.CPFCNPJ, 
                o.DataCriacao, 
                o.ValorTotal,
                o.Status,
                CASE o.Status 
                    WHEN 1 THEN 'Aguardando Aprovação'
                    WHEN 2 THEN 'Aprovado'
                    WHEN 3 THEN 'Rejeitado'
                    ELSE 'Desconhecido'
                END AS StatusDescricao
            FROM Orcamentos o
            INNER JOIN Clientes c ON o.ClienteID = c.ID
            WHERE (@status IS NULL OR o.Status = @status)
            AND o.DataCriacao BETWEEN @dataInicio AND @dataFim
            ORDER BY o.DataCriacao DESC";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@status", (object?)status ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@dataFim", dataFim);

                    await conn.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            result.Add(new OrcamentoAprovacaoModel
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                CodigoOrcamento = reader.GetString(reader.GetOrdinal("CodigoOrcamento")),
                                NomeCliente = reader.GetString(reader.GetOrdinal("NomeCliente")),
                                CPFCNPJ = reader.GetString(reader.GetOrdinal("CPFCNPJ")),
                                DataCriacao = reader.GetDateTime(reader.GetOrdinal("DataCriacao")),
                                ValorTotal = reader.GetDecimal(reader.GetOrdinal("ValorTotal")),
                                Status = reader.GetInt32(reader.GetOrdinal("Status")),
                                StatusDescricao = reader.GetString(reader.GetOrdinal("StatusDescricao")),
                            });
                        }
                    }
                }
            }

            return result;
        }
        public async Task AtualizarStatusOrcamentoAsync(int orcamentoId, StatusOrcamento status)
        {
            using (var conn = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                await conn.OpenAsync();
                var sql = @"UPDATE Orcamentos 
                    SET Status = @status, UltimaModificacao = GETDATE()
                    WHERE ID = @id";

                using (var cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@status", (int)status);
                    cmd.Parameters.AddWithValue("@id", orcamentoId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        #endregion
        public async Task<List<Produto>> ObterProdutosDisponiveisAsync(string filtro = "")
        {
            using (var conn = new SqlConnection(connectionString))
            {
                string sql = @"SELECT * FROM Produtos WHERE Ativo = 1";
                if (!string.IsNullOrEmpty(filtro))
                    sql += " AND (Nome LIKE @filtro OR CodigoProduto LIKE @filtro OR CodigoBarras LIKE @filtro)";
                var produtos = await conn.QueryAsync<Produto>(sql, new { filtro = "%" + filtro + "%" });
                return produtos.ToList();
            }
        }

        public async Task<List<ICliente>> BuscarClientesAsync(string filtro = null)
        {
            var clientes = new List<ICliente>();
            var sql = @"SELECT ID, Nome, CPFCNPJ, DataNascimento, Endereco, Numero, Telefone, RendaDeclarada,
            CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao, IBGE, Complemento,
            DataCadastro, UltimaModificacao, Ativo FROM Clientes WHERE Ativo = 1";
            if (!string.IsNullOrWhiteSpace(filtro))
                sql += " AND (Nome LIKE @filtro OR CPFCNPJ LIKE @filtro)";

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                if (!string.IsNullOrWhiteSpace(filtro))
                    command.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        clientes.Add(MapearCliente(reader));
                    }
                }
            }
            return clientes;
        }
        private ICliente MapearCliente(SqlDataReader reader)
        {
            return new Cliente
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Nome = reader.IsDBNull(reader.GetOrdinal("Nome")) ? null : reader.GetString(reader.GetOrdinal("Nome")),
                CPFCNPJ = reader.IsDBNull(reader.GetOrdinal("CPFCNPJ")) ? null : reader.GetString(reader.GetOrdinal("CPFCNPJ")),
                DataNascimento = reader.IsDBNull(reader.GetOrdinal("DataNascimento")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataNascimento")),
                Endereco = reader.IsDBNull(reader.GetOrdinal("Endereco")) ? null : reader.GetString(reader.GetOrdinal("Endereco")),
                Numero = reader.IsDBNull(reader.GetOrdinal("Numero")) ? null : reader.GetString(reader.GetOrdinal("Numero")),
                Telefone = reader.IsDBNull(reader.GetOrdinal("Telefone")) ? null : reader.GetString(reader.GetOrdinal("Telefone")),
                RendaDeclarada = reader.IsDBNull(reader.GetOrdinal("RendaDeclarada")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("RendaDeclarada")),
                CEP = reader.IsDBNull(reader.GetOrdinal("CEP")) ? null : reader.GetString(reader.GetOrdinal("CEP")),
                Logradouro = reader.IsDBNull(reader.GetOrdinal("Logradouro")) ? null : reader.GetString(reader.GetOrdinal("Logradouro")),
                Bairro = reader.IsDBNull(reader.GetOrdinal("Bairro")) ? null : reader.GetString(reader.GetOrdinal("Bairro")),
                Localidade = reader.IsDBNull(reader.GetOrdinal("Localidade")) ? null : reader.GetString(reader.GetOrdinal("Localidade")),
                UF = reader.IsDBNull(reader.GetOrdinal("UF")) ? null : reader.GetString(reader.GetOrdinal("UF")),
                Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader.GetString(reader.GetOrdinal("Estado")),
                Regiao = reader.IsDBNull(reader.GetOrdinal("Regiao")) ? null : reader.GetString(reader.GetOrdinal("Regiao")),
                IBGE = reader.IsDBNull(reader.GetOrdinal("IBGE")) ? null : reader.GetString(reader.GetOrdinal("IBGE")),
                Complemento = reader.IsDBNull(reader.GetOrdinal("Complemento")) ? null : reader.GetString(reader.GetOrdinal("Complemento")),
                DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                UltimaModificacao = reader.GetDateTime(reader.GetOrdinal("UltimaModificacao")),
                Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
            };
        }

    }
}

