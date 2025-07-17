using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _connectionString;

        public ClienteRepository()
        {
            _connectionString = ConnectionManager.GetConnectionString();
        }

        public async Task<int> InserirClienteAsync(ICliente cliente)
        {
            const string sql = @"
            INSERT INTO Clientes (
                Nome, CPFCNPJ, DataNascimento, Endereco, Numero, Telefone, RendaDeclarada,
                CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao, IBGE, Complemento
            ) VALUES (
                @Nome, @CPFCNPJ, @DataNascimento, @Endereco, @Numero, @Telefone, @RendaDeclarada,
                @CEP, @Logradouro, @Bairro, @Localidade, @UF, @Estado, @Regiao, @IBGE, @Complemento
            );
            SELECT SCOPE_IDENTITY();";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                AdicionarParametros(command, cliente);
                await connection.OpenAsync();

                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result);
            }
        }

        public async Task<bool> AtualizarClienteAsync(ICliente cliente)
        {
            const string sql = @"UPDATE Clientes SET
                Nome = @Nome,
                CPFCNPJ = @CPFCNPJ,
                DataNascimento = @DataNascimento,
                Endereco = @Endereco,
                Numero = @Numero,
                Telefone = @Telefone,
                RendaDeclarada = @RendaDeclarada,
                CEP = @CEP,
                Logradouro = @Logradouro,
                Bairro = @Bairro,
                Localidade = @Localidade,
                UF = @UF,
                Estado = @Estado,
                Regiao = @Regiao,
                IBGE = @IBGE,
                Complemento = @Complemento
            WHERE ID = @ID";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                AdicionarParametros(command, cliente);
                command.Parameters.AddWithValue("@ID", cliente.ID);
                await connection.OpenAsync();
                return (await command.ExecuteNonQueryAsync()) > 0;
            }
        }

        public async Task<bool> InativarClienteAsync(int id)
        {
            const string sql = "UPDATE Clientes SET Ativo = 0 WHERE ID = @ID";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                await connection.OpenAsync();
                return (await command.ExecuteNonQueryAsync()) > 0;
            }
        }

        public async Task<List<ICliente>> ObterTodosClientesAsync()
        {
            const string sql = @"SELECT ID, Nome, CPFCNPJ, DataNascimento, Endereco, Numero, Telefone, RendaDeclarada,
            CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao, IBGE, Complemento,
            DataCadastro, UltimaModificacao, Ativo FROM Clientes WHERE Ativo = 1 ORDER BY Nome";
            return await ExecutarConsultaAsync(sql);
        }

        public async Task<ICliente> ObterClientePorIdAsync(int id)
        {
            const string sql = @"SELECT ID, Nome, CPFCNPJ, DataNascimento, Endereco, Numero, Telefone, RendaDeclarada,
            CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao, IBGE, Complemento,
            DataCadastro, UltimaModificacao, Ativo FROM Clientes WHERE ID = @ID";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@ID", id);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapearCliente(reader);
                    }
                }
            }
            return null;
        }

        public async Task<List<ICliente>> BuscarClientesPorNomeAsync(string nome)
        {
            const string sql = @"SELECT ID, Nome, CPFCNPJ, DataNascimento, Endereco, Numero, Telefone, RendaDeclarada,
            CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao, IBGE, Complemento,
            DataCadastro, UltimaModificacao, Ativo
            FROM Clientes WHERE Nome LIKE @Nome AND Ativo = 1 ORDER BY Nome";

            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Nome", $"%{nome}%");
                return await ExecutarConsultaComComandoAsync(command, connection);
            }
        }

        public async Task<int> ObterTotalClientesAsync()
        {
            const string sql = "SELECT COUNT(*) FROM Clientes WHERE Ativo = 1";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                await connection.OpenAsync();
                return Convert.ToInt32(await command.ExecuteScalarAsync());
            }
        }

        // Métodos auxiliares privados (async)
        private void AdicionarParametros(SqlCommand command, ICliente cliente)
        {
            command.Parameters.AddWithValue("@Nome", cliente.Nome ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CPFCNPJ", cliente.CPFCNPJ ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DataNascimento", cliente.DataNascimento ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Endereco", cliente.Endereco ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Numero", cliente.Numero ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Telefone", cliente.Telefone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@RendaDeclarada", cliente.RendaDeclarada ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CEP", cliente.CEP ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Logradouro", cliente.Logradouro ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Bairro", cliente.Bairro ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Localidade", cliente.Localidade ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UF", cliente.UF ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Estado", cliente.Estado ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Regiao", cliente.Regiao ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IBGE", cliente.IBGE ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Complemento", cliente.Complemento ?? (object)DBNull.Value);
        }

        private async Task<List<ICliente>> ExecutarConsultaAsync(string sql)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(sql, connection))
            {
                return await ExecutarConsultaComComandoAsync(command, connection);
            }
        }

        private async Task<List<ICliente>> ExecutarConsultaComComandoAsync(SqlCommand command, SqlConnection connection)
        {
            var clientes = new List<ICliente>();

            if (connection.State != ConnectionState.Open)
                await connection.OpenAsync();

            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    clientes.Add(MapearCliente(reader));
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
        public async Task<List<ICliente>> BuscarClientesAsync(string filtro = null)
        {
            var clientes = new List<ICliente>();
            var sql = @"SELECT ID, Nome, CPFCNPJ, DataNascimento, Endereco, Numero, Telefone, RendaDeclarada,
            CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao, IBGE, Complemento,
            DataCadastro, UltimaModificacao, Ativo FROM Clientes WHERE Ativo = 1";
            if (!string.IsNullOrWhiteSpace(filtro))
                sql += " AND (Nome LIKE @filtro OR CPFCNPJ LIKE @filtro)";

            using (var connection = new SqlConnection(_connectionString))
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

    }

}
