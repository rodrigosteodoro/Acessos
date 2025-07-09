namespace Acessos
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;

    /// <summary>
    /// Enum para os diferentes tipos de cargo/nível de acesso.
    /// </summary>
    internal enum TipoCargo
    {
        Admin,
        Comum,
        Windows
    }

    /// <summary>
    /// Gerencia conexões com o banco de dados de acordo com o tipo de acesso.
    /// </summary>
   public class ConnectionManager : IDisposable
    {
        private SqlConnection _connection;

        /// <summary>
        /// Obtém a string de conexão do App.config pelo nome.
        /// </summary>
        /// <param name="name">Nome da string de conexão.</param>
        /// <returns>String de conexão.</returns>
        internal static string GetConnectionString(string name = "Windows")
        {
            if (string.IsNullOrEmpty(name))
                name = "Windows";

            var connString = ConfigurationManager.ConnectionStrings[name]?.ConnectionString;

            if (string.IsNullOrEmpty(connString))
                throw new InvalidOperationException($"String de conexão '{name}' não encontrada no App.config.");

            return connString;
        }

        /// <summary>
        /// Inicializa o ConnectionManager com o tipo de cargo.
        /// </summary>
        /// <param name="cargo">Tipo de cargo.</param>
        internal ConnectionManager(TipoCargo cargo = TipoCargo.Windows)
        {
            string connName = cargo.ToString();
            _connection = new SqlConnection(GetConnectionString(connName));
        }

        /// <summary>
        /// Abre a conexão, se ainda não estiver aberta.
        /// </summary>
        /// <returns>SqlConnection aberta.</returns>
        internal SqlConnection OpenConnection()
        {
            if (_connection.State != ConnectionState.Open)
                _connection.Open();
            return _connection;
        }

        /// <summary>
        /// Fecha a conexão, se estiver aberta.
        /// </summary>
        internal void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
                _connection.Close();
        }

        /// <summary>
        /// Estado atual da conexão.
        /// </summary>
        internal ConnectionState EstadoConexao => _connection.State;

        /// <summary>
        /// Libera recursos da conexão.
        /// </summary>
        public void Dispose()
        {
            if (_connection != null)
            {
                if (_connection.State != ConnectionState.Closed)
                    _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}
