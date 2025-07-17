using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Acessos
{
    public class OrcamentoHistorico : IOrcamentoHistorico
    {
        public int Id { get; set; }
        public int OrcamentoId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DataAlteracao { get; set; }
        public string Acao { get; set; }
        public string Detalhes { get; set; }

        public OrcamentoHistorico ObterHistoricoPorId(SqlConnection conexao, int id)
        {
            using (var cmd = new SqlCommand("SELECT Id, OrcamentoId, UsuarioId, DataAlteracao, Acao, Detalhes FROM OrcamentoHistorico WHERE Id = @Id", conexao))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return Mapear(reader);
                    }
                }
            }
            return null;
        }

        public List<OrcamentoHistorico> ObterHistoricoPorOrcamentoId(SqlConnection conexao, int orcamentoId)
        {
            var lista = new List<OrcamentoHistorico>();
            using (var cmd = new SqlCommand("SELECT Id, OrcamentoId, UsuarioId, DataAlteracao, Acao, Detalhes FROM OrcamentoHistorico WHERE OrcamentoId = @OrcamentoId ORDER BY DataAlteracao DESC", conexao))
            {
                cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(Mapear(reader));
                    }
                }
            }
            return lista;
        }

        public List<OrcamentoHistorico> ObterHistoricoPorUsuarioId(SqlConnection conexao, int? usuarioId)
        {
            var lista = new List<OrcamentoHistorico>();
            using (var cmd = new SqlCommand("SELECT Id, OrcamentoId, UsuarioId, DataAlteracao, Acao, Detalhes FROM OrcamentoHistorico WHERE UsuarioId = @UsuarioId ORDER BY DataAlteracao DESC", conexao))
            {
                cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(Mapear(reader));
                    }
                }
            }
            return lista;
        }

        public void RegistrarHistorico(SqlConnection conexao, int orcamentoId, int usuarioId, string acao, string detalhes)
        {
            try
            {
                using (var cmd = new SqlCommand(
                    "INSERT INTO OrcamentoHistorico (OrcamentoId, UsuarioId, DataAlteracao, Acao, Detalhes) " +
                    "VALUES (@OrcamentoId, @UsuarioId, @DataAlteracao, @Acao, @Detalhes)", conexao))
                {
                    cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                    cmd.Parameters.AddWithValue("@DataAlteracao", DateTime.Now);
                    cmd.Parameters.AddWithValue("@Acao", acao);
                    cmd.Parameters.AddWithValue("@Detalhes", detalhes ?? "");
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Logar o erro especificamente (pode ser substituído por log mais robusto)
                Console.WriteLine("Erro ao registrar histórico: " + ex.Message);
            }
        }

        // Método auxiliar para popular um objeto a partir do SqlDataReader
        private OrcamentoHistorico Mapear(SqlDataReader reader)
        {
            return new OrcamentoHistorico
            {
                Id = (int)reader["Id"],
                OrcamentoId = (int)reader["OrcamentoId"],
                UsuarioId = (int)reader["UsuarioId"],
                DataAlteracao = (DateTime)reader["DataAlteracao"],
                Acao = reader["Acao"].ToString(),
                Detalhes = reader["Detalhes"].ToString()
            };
        }
    }
}
