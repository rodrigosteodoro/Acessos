using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Linq;
using Acessos.Estoque.Fornecedores;

namespace Acessos
{
    public class Fornecedor : IFornecedores
    {
        #region Propriedades
        public int ID { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string CNPJ { get; set; }
        public DateTime? DataFundacao { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Site { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Estado { get; set; }
        public string Regiao { get; set; }
        public string IBGE { get; set; }
        public string Complemento { get; set; }
        public string Contato { get; set; }
        public string TipoFornecedor { get; set; }
        public string Status { get; set; }
        public string Observacoes { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaModificacao { get; set; }
        public bool Ativo { get; set; }

        // Propriedades calculadas para formatação
        public string CNPJFormatado => FormatarCNPJ(CNPJ);
        public string TelefoneFormatado => FormatarTelefone(Telefone);
        public string CEPFormatado => FormatarCEP(CEP);
        #endregion

        #region Campos Privados
        private readonly string connectionString;
        #endregion

        #region Construtor
        public Fornecedor()
        {
            connectionString = ConnectionManager.GetConnectionString("Admin");
            InicializarValoresPadrao();
        }

        private void InicializarValoresPadrao()
        {
            DataCadastro = DateTime.Now;
            UltimaModificacao = DateTime.Now;
            Ativo = true;
            Status = "Ativo";
            TipoFornecedor = "Produtos";
        }
        #endregion

        #region Métodos Síncronos (Compatibilidade)
        public List<Fornecedor> ObterTodosFornecedores()
        {
            return ObterTodosFornecedoresAsync().GetAwaiter().GetResult();
        }

        public Fornecedor ObterFornecedorPorId(int id)
        {
            return ObterFornecedorPorIdAsync(id).GetAwaiter().GetResult();
        }

        public int InserirFornecedor(Fornecedor fornecedor)
        {
            return InserirFornecedorAsync(fornecedor).GetAwaiter().GetResult();
        }

        public bool AtualizarFornecedor(Fornecedor fornecedor)
        {
            return AtualizarFornecedorAsync(fornecedor).GetAwaiter().GetResult();
        }

        public bool InativarFornecedor(int id)
        {
            return InativarFornecedorAsync(id).GetAwaiter().GetResult();
        }

        public bool FornecedorExistePorCNPJ(string cnpj)
        {
            return FornecedorExistePorCNPJAsync(cnpj).GetAwaiter().GetResult();
        }
        #endregion

        #region Métodos Assíncronos
        public async Task<List<Fornecedor>> ObterTodosFornecedoresAsync()
        {
            var fornecedores = new List<Fornecedor>();

            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT FornecedorID , RazaoSocial, NomeFantasia, CNPJ, DataFundacao, Telefone, Email, Site,
                           Endereco, Numero, CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao,
                           IBGE, Complemento, Contato, TipoFornecedor, Status, Observacoes,
                           DataCadastro, UltimaModificacao, Ativo
                    FROM Fornecedores 
                    WHERE Ativo = 1
                    ORDER BY RazaoSocial";

                using (var command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            fornecedores.Add(MapearFornecedor(reader));
                        }
                    }
                }
            }

            return fornecedores;
        }

        public async Task<Fornecedor> ObterFornecedorPorIdAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT FornecedorID , RazaoSocial, NomeFantasia, CNPJ, DataFundacao, Telefone, Email, Site,
                           Endereco, Numero, CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao,
                           IBGE, Complemento, Contato, TipoFornecedor, Status, Observacoes,
                           DataCadastro, UltimaModificacao, Ativo
                    FROM Fornecedores 
                    WHERE FornecedorID = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return MapearFornecedor(reader);
                        }
                    }
                }
            }

            return null;
        }

        public async Task<int> InserirFornecedorAsync(Fornecedor fornecedor)
        {
            ValidarFornecedor(fornecedor);

            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    INSERT INTO Fornecedores 
                    (RazaoSocial, NomeFantasia, CNPJ, DataFundacao, Telefone, Email, Site,
                     Endereco, Numero, CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao,
                     IBGE, Complemento, Contato, TipoFornecedor, Status, Observacoes,
                     DataCadastro, UltimaModificacao, Ativo)
                    VALUES 
                    (@RazaoSocial, @NomeFantasia, @CNPJ, @DataFundacao, @Telefone, @Email, @Site,
                     @Endereco, @Numero, @CEP, @Logradouro, @Bairro, @Localidade, @UF, @Estado, @Regiao,
                     @IBGE, @Complemento, @Contato, @TipoFornecedor, @Status, @Observacoes,
                     @DataCadastro, @UltimaModificacao, @Ativo);
                    SELECT SCOPE_IDENTITY();";

                using (var command = new SqlCommand(query, connection))
                {
                    AdicionarParametros(command, fornecedor);
                    await connection.OpenAsync();

                    var result = await command.ExecuteScalarAsync();
                    return Convert.ToInt32(result);
                }
            }
        }

        public async Task<bool> AtualizarFornecedorAsync(Fornecedor fornecedor)
        {
            ValidarFornecedor(fornecedor);

            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    UPDATE Fornecedores SET
                        RazaoSocial = @RazaoSocial,
                        NomeFantasia = @NomeFantasia,
                        CNPJ = @CNPJ,
                        DataFundacao = @DataFundacao,
                        Telefone = @Telefone,
                        Email = @Email,
                        Site = @Site,
                        Endereco = @Endereco,
                        Numero = @Numero,
                        CEP = @CEP,
                        Logradouro = @Logradouro,
                        Bairro = @Bairro,
                        Localidade = @Localidade,
                        UF = @UF,
                        Estado = @Estado,
                        Regiao = @Regiao,
                        IBGE = @IBGE,
                        Complemento = @Complemento,
                        Contato = @Contato,
                        TipoFornecedor = @TipoFornecedor,
                        Status = @Status,
                        Observacoes = @Observacoes,
                        UltimaModificacao = @UltimaModificacao
                    WHERE  FornecedorID = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    AdicionarParametros(command, fornecedor);
                    command.Parameters.AddWithValue("@ID", fornecedor.ID);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> InativarFornecedorAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    UPDATE Fornecedores 
                    SET Ativo = 0, 
                        Status = 'Inativo',
                        UltimaModificacao = @UltimaModificacao 
                    WHERE  FornecedorID  = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@UltimaModificacao", DateTime.Now);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<bool> FornecedorExistePorCNPJAsync(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT COUNT(*) FROM Fornecedores WHERE CNPJ = @CNPJ AND Ativo = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CNPJ", cnpj);
                    await connection.OpenAsync();

                    var count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        public async Task<bool> CNPJExisteParaOutroFornecedorAsync(string cnpj, int fornecedorId)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT COUNT(*) FROM Fornecedores WHERE CNPJ = @CNPJ AND  FornecedorID != @ID AND Ativo = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CNPJ", cnpj);
                    command.Parameters.AddWithValue("@ID", fornecedorId);
                    await connection.OpenAsync();

                    var count = (int)await command.ExecuteScalarAsync();
                    return count > 0;
                }
            }
        }

        public async Task<List<Fornecedor>> BuscarFornecedoresAsync(string termo)
        {
            var fornecedores = new List<Fornecedor>();

            if (string.IsNullOrWhiteSpace(termo))
                return await ObterTodosFornecedoresAsync();

            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT FornecedorID , RazaoSocial, NomeFantasia, CNPJ, DataFundacao, Telefone, Email, Site,
                           Endereco, Numero, CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao,
                           IBGE, Complemento, Contato, TipoFornecedor, Status, Observacoes,
                           DataCadastro, UltimaModificacao, Ativo
                    FROM Fornecedores 
                    WHERE Ativo = 1 
                      AND (RazaoSocial LIKE @Termo 
                           OR NomeFantasia LIKE @Termo 
                           OR CNPJ LIKE @Termo
                           OR Email LIKE @Termo)
                    ORDER BY RazaoSocial";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Termo", $"%{termo}%");
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            fornecedores.Add(MapearFornecedor(reader));
                        }
                    }
                }
            }

            return fornecedores;
        }

        public async Task<List<Fornecedor>> ObterFornecedoresPorStatusAsync(string status)
        {
            var fornecedores = new List<Fornecedor>();

            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    SELECT  FornecedorID , RazaoSocial, NomeFantasia, CNPJ, DataFundacao, Telefone, Email, Site,
                           Endereco, Numero, CEP, Logradouro, Bairro, Localidade, UF, Estado, Regiao,
                           IBGE, Complemento, Contato, TipoFornecedor, Status, Observacoes,
                           DataCadastro, UltimaModificacao, Ativo
                    FROM Fornecedores 
                    WHERE Status = @Status
                    ORDER BY RazaoSocial";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            fornecedores.Add(MapearFornecedor(reader));
                        }
                    }
                }
            }

            return fornecedores;
        }

        public async Task<bool> ReativarFornecedorAsync(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = @"
                    UPDATE Fornecedores 
                    SET Ativo = 1, 
                        Status = 'Ativo',
                        UltimaModificacao = @UltimaModificacao 
                    WHERE FornecedorID = @ID";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@UltimaModificacao", DateTime.Now);

                    await connection.OpenAsync();
                    return await command.ExecuteNonQueryAsync() > 0;
                }
            }
        }

        public async Task<int> ContarFornecedoresAsync()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT COUNT(*) FROM Fornecedores WHERE Ativo = 1";

                using (var command = new SqlCommand(query, connection))
                {
                    await connection.OpenAsync();
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }

        public async Task<int> ContarFornecedoresPorStatusAsync(string status)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var query = "SELECT COUNT(*) FROM Fornecedores WHERE Status = @Status";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Status", status);
                    await connection.OpenAsync();
                    return (int)await command.ExecuteScalarAsync();
                }
            }
        }
        #endregion

        #region Métodos Privados
        private void ValidarFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor == null)
                throw new ArgumentNullException(nameof(fornecedor), "Fornecedor não pode ser nulo");

            if (string.IsNullOrWhiteSpace(fornecedor.RazaoSocial))
                throw new ArgumentException("Razão Social é obrigatória", nameof(fornecedor.RazaoSocial));

            if (string.IsNullOrWhiteSpace(fornecedor.CNPJ))
                throw new ArgumentException("CNPJ é obrigatório", nameof(fornecedor.CNPJ));

            if (fornecedor.CNPJ.Length != 14)
                throw new ArgumentException("CNPJ deve ter 14 dígitos", nameof(fornecedor.CNPJ));
        }

        private void AdicionarParametros(SqlCommand command, Fornecedor fornecedor)
        {
            command.Parameters.AddWithValue("@RazaoSocial", fornecedor.RazaoSocial ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NomeFantasia", fornecedor.NomeFantasia ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CNPJ", fornecedor.CNPJ ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DataFundacao", fornecedor.DataFundacao ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Telefone", fornecedor.Telefone ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Email", fornecedor.Email ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Site", fornecedor.Site ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Endereco", fornecedor.Endereco ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Numero", fornecedor.Numero ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CEP", fornecedor.CEP ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Logradouro", fornecedor.Logradouro ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Bairro", fornecedor.Bairro ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Localidade", fornecedor.Localidade ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@UF", fornecedor.UF ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Estado", fornecedor.Estado ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Regiao", fornecedor.Regiao ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IBGE", fornecedor.IBGE ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Complemento", fornecedor.Complemento ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Contato", fornecedor.Contato ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@TipoFornecedor", fornecedor.TipoFornecedor ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Status", fornecedor.Status ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Observacoes", fornecedor.Observacoes ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@DataCadastro", fornecedor.DataCadastro);
            command.Parameters.AddWithValue("@UltimaModificacao", fornecedor.UltimaModificacao);
            command.Parameters.AddWithValue("@Ativo", fornecedor.Ativo);
        }

        private Fornecedor MapearFornecedor(IDataReader reader)
        {
            return new Fornecedor
            {
                ID = reader.GetInt32(reader.GetOrdinal("FornecedorID")),
                RazaoSocial = reader.IsDBNull(reader.GetOrdinal("RazaoSocial")) ? null : reader.GetString(reader.GetOrdinal("RazaoSocial")),
                NomeFantasia = reader.IsDBNull(reader.GetOrdinal("NomeFantasia")) ? null : reader.GetString(reader.GetOrdinal("NomeFantasia")),
                CNPJ = reader.IsDBNull(reader.GetOrdinal("CNPJ")) ? null : reader.GetString(reader.GetOrdinal("CNPJ")),
                DataFundacao = reader.IsDBNull(reader.GetOrdinal("DataFundacao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("DataFundacao")),
                Telefone = reader.IsDBNull(reader.GetOrdinal("Telefone")) ? null : reader.GetString(reader.GetOrdinal("Telefone")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                Site = reader.IsDBNull(reader.GetOrdinal("Site")) ? null : reader.GetString(reader.GetOrdinal("Site")),
                Endereco = reader.IsDBNull(reader.GetOrdinal("Endereco")) ? null : reader.GetString(reader.GetOrdinal("Endereco")),
                Numero = reader.IsDBNull(reader.GetOrdinal("Numero")) ? null : reader.GetString(reader.GetOrdinal("Numero")),
                CEP = reader.IsDBNull(reader.GetOrdinal("CEP")) ? null : reader.GetString(reader.GetOrdinal("CEP")),
                Logradouro = reader.IsDBNull(reader.GetOrdinal("Logradouro")) ? null : reader.GetString(reader.GetOrdinal("Logradouro")),
                Bairro = reader.IsDBNull(reader.GetOrdinal("Bairro")) ? null : reader.GetString(reader.GetOrdinal("Bairro")),
                Localidade = reader.IsDBNull(reader.GetOrdinal("Localidade")) ? null : reader.GetString(reader.GetOrdinal("Localidade")),
                UF = reader.IsDBNull(reader.GetOrdinal("UF")) ? null : reader.GetString(reader.GetOrdinal("UF")),
                Estado = reader.IsDBNull(reader.GetOrdinal("Estado")) ? null : reader.GetString(reader.GetOrdinal("Estado")),
                Regiao = reader.IsDBNull(reader.GetOrdinal("Regiao")) ? null : reader.GetString(reader.GetOrdinal("Regiao")),
                IBGE = reader.IsDBNull(reader.GetOrdinal("IBGE")) ? null : reader.GetString(reader.GetOrdinal("IBGE")),
                Complemento = reader.IsDBNull(reader.GetOrdinal("Complemento")) ? null : reader.GetString(reader.GetOrdinal("Complemento")),
                Contato = reader.IsDBNull(reader.GetOrdinal("Contato")) ? null : reader.GetString(reader.GetOrdinal("Contato")),
                TipoFornecedor = reader.IsDBNull(reader.GetOrdinal("TipoFornecedor")) ? null : reader.GetString(reader.GetOrdinal("TipoFornecedor")),
                Status = reader.IsDBNull(reader.GetOrdinal("Status")) ? null : reader.GetString(reader.GetOrdinal("Status")),
                Observacoes = reader.IsDBNull(reader.GetOrdinal("Observacoes")) ? null : reader.GetString(reader.GetOrdinal("Observacoes")),
                DataCadastro = reader.GetDateTime(reader.GetOrdinal("DataCadastro")),
                UltimaModificacao = (DateTime)(reader.IsDBNull(reader.GetOrdinal("UltimaModificacao")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("UltimaModificacao"))),
                Ativo = reader.GetBoolean(reader.GetOrdinal("Ativo"))
            };
        }

        #endregion

        #region Métodos de Formatação
        private string FormatarCNPJ(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
                return cnpj;

            return $"{cnpj.Substring(0, 2)}.{cnpj.Substring(2, 3)}.{cnpj.Substring(5, 3)}/{cnpj.Substring(8, 4)}-{cnpj.Substring(12, 2)}";
        }

        private string FormatarTelefone(string telefone)
        {
            if (string.IsNullOrWhiteSpace(telefone))
                return telefone;

            string digits = new string(telefone.Where(char.IsDigit).ToArray());

            if (digits.Length == 11)
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 5)}-{digits.Substring(7, 4)}";
            else if (digits.Length == 10)
                return $"({digits.Substring(0, 2)}) {digits.Substring(2, 4)}-{digits.Substring(6, 4)}";

            return telefone;
        }

        private string FormatarCEP(string cep)
        {
            if (string.IsNullOrWhiteSpace(cep) || cep.Length != 8)
                return cep;

            return $"{cep.Substring(0, 5)}-{cep.Substring(5, 3)}";
        }
        #endregion

        #region Métodos Estáticos Utilitários
        public static string LimparCNPJ(string cnpj)
        {
            return cnpj?.Replace(".", "").Replace("/", "").Replace("-", "").Replace(" ", "") ?? "";
        }

        public static string LimparTelefone(string telefone)
        {
            return telefone?.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "") ?? "";
        }

        public static string LimparCEP(string cep)
        {
            return cep?.Replace("-", "").Replace(" ", "") ?? "";
        }
        #endregion
    }
}
