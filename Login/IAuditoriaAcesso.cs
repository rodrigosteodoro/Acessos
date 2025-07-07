using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Acessos
{
    public interface IAuditoriaAcesso
    {
        int AuditoriaID { get; set; }
        int? UsuarioID { get; set; }
        string Acao { get; set; }
        DateTime DataHora { get; set; }
        string UsuarioAplicacao { get; set; }
        string Detalhes { get; set; }
    }
    public class AuditoriaAcesso : IAuditoriaAcesso
    {
        public int AuditoriaID { get; set; }
        public int? UsuarioID { get; set; }
        public string Acao { get; set; }
        public DateTime DataHora { get; set; }
        public string UsuarioAplicacao { get; set; }
        public string Detalhes { get; set; }


        private readonly string _connectionString = ConnectionManager.GetConnectionString("Admin");
          
        
        public void InserirAuditoria(IAuditoriaAcesso auditoria)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("INSERT INTO AuditoriaAcesso (UsuarioID, Acao, DataHora," +
                " UsuarioAplicacao, Detalhes) VALUES (@UsuarioID, @Acao, @DataHora, @UsuarioAplicacao, @Detalhes)", conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", (object)auditoria.UsuarioID ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Acao", auditoria.Acao);
                cmd.Parameters.AddWithValue("@DataHora", auditoria.DataHora);
                cmd.Parameters.AddWithValue("@UsuarioAplicacao", auditoria.UsuarioAplicacao);
                cmd.Parameters.AddWithValue("@Detalhes", auditoria.Detalhes);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<IAuditoriaAcesso> ConsultarAuditoria(int? usuarioId = null)
        {
            var lista = new List<IAuditoriaAcesso>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM AuditoriaAcesso WHERE (@UsuarioID IS NULL OR UsuarioID = @UsuarioID)", conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", (object)usuarioId ?? DBNull.Value);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var auditoria = new AuditoriaAcesso
                        {
                            AuditoriaID = Convert.ToInt32(reader["AuditoriaID"]),
                            UsuarioID = reader["UsuarioID"] != DBNull.Value ? Convert.ToInt32(reader["UsuarioID"]) : (int?)null,
                            Acao = reader["Acao"].ToString(),
                            DataHora = Convert.ToDateTime(reader["DataHora"]),
                            UsuarioAplicacao = reader["UsuarioAplicacao"].ToString(),
                            Detalhes = reader["Detalhes"].ToString()
                        };
                        lista.Add(auditoria);
                    }
                }
            }
            return lista;
        }

    }

}
