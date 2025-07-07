using System;
using System.Data.SqlClient;

namespace Acessos
{
    public interface IUsuarioStatus
    {
        int UsuarioStatusID { get; set; }
        int UsuarioID { get; set; }
        string Situacao { get; set; }          // "Bloqueado", "Inativo", etc.
        DateTime DataStatus { get; set; }
        DateTime? DataMod { get; set; }
        bool AcessoLiberacao { get; set; }
        int NivelLiberacao { get; set; }
    }
    public class UsuarioStatus : IUsuarioStatus
    {
        private readonly string _connectionString= ConnectionManager.GetConnectionString("Admin");

        public int UsuarioStatusID { get; set; }
        public int UsuarioID { get; set; }
        public string Situacao { get; set; }          // "Bloqueado", "Inativo", etc.
        public DateTime DataStatus { get; set; }
        public DateTime? DataMod { get; set; }
        public bool AcessoLiberacao { get; set; }
        public int NivelLiberacao { get; set; }

        internal UsuarioStatus(string nomeConexao = "Windows")
        {
            _connectionString = ConnectionManager.GetConnectionString(nomeConexao);
        }

        public IUsuarioStatus CarregarStatusUsuario(int usuarioId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM usuarioStatus WHERE UsuarioID = @UsuarioID ORDER BY DataStatus DESC", conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new UsuarioStatus
                        {
                            UsuarioStatusID = Convert.ToInt32(reader["UsuarioStatusID"]),
                            UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                            Situacao = reader["Situacao"].ToString(),
                            DataStatus = Convert.ToDateTime(reader["DataStatus"]),
                            DataMod = reader["DataMod"] != DBNull.Value ? (DateTime?)reader["DataMod"] : null,
                            AcessoLiberacao = Convert.ToBoolean(reader["AcessoLiberacao"]),
                            NivelLiberacao = Convert.ToInt32(reader["NivelLiberacao"])
                        };
                    }
                }
            }
            return null;
        }
        public void BloquearUsuario(int usuarioId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO usuarioStatus (UsuarioID, Situacao, DataStatus, AcessoLiberacao, NivelLiberacao) " +
                "VALUES (@UsuarioID, 'Bloqueado', @DataStatus, 0, 0)", conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);
                cmd.Parameters.AddWithValue("@DataStatus", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void AtivarUsuario(int usuarioId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO UsuarioStatus (UsuarioID, Situacao, DataStatus, AcessoLiberacao, NivelLiberacao) " +
                "VALUES (@UsuarioID, 'Ativo', @DataStatus, 1, 1)", conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);
                cmd.Parameters.AddWithValue("@DataStatus", DateTime.Now);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }

}
