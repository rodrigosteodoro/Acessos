
using System;
using Acessos;

namespace Acessos
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
  

    internal class Usuario : IUsuario
    {
        public int UsuarioID { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cargo { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public int NivelAcesso { get; set; }
        public   string UsuarioAplicacao { get; set; } // Nome do usuário ou aplicação que está realizando a ação
        //
        int UsuarioStatusID { get; set; }     
        string Situacao { get; set; }          // "Bloqueado", "Inativo", etc.
        DateTime DataStatus { get; set; }
        DateTime? DataMod { get; set; }
        bool AcessoLiberacao { get; set; }
        int NivelLiberacao { get; set; }


        private readonly string _connectionString;

        internal Usuario(string nomeConexao = "Windows")
        {
            _connectionString = ConnectionManager.GetConnectionString(nomeConexao);
        }

        internal void InserirUsuario(string nome, string email, string senha, string cargo,bool ativo, int nivelacesso, string usuarioaplicacao)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("InserirUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@Ativo", ativo);
                cmd.Parameters.AddWithValue("@NivelAcesso",nivelacesso);  
                cmd.Parameters.AddWithValue("@UsuarioAplicacao", usuarioaplicacao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void AtualizarUsuario(int usuarioId, string nome, string email, string senha, string cargo,bool ativo, int nivelacesso,string usuarioaplicacao)
        { 
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("AtualizarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);
                cmd.Parameters.AddWithValue("@Nome", nome);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Senha", senha);
                cmd.Parameters.AddWithValue("@Cargo", cargo);
                cmd.Parameters.AddWithValue("@Ativo", ativo);
                cmd.Parameters.AddWithValue("@NivelAcesso", nivelacesso);
                cmd.Parameters.AddWithValue("@UsuarioAplicacao", usuarioaplicacao); //para tabela auditoria

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal void ExcluirUsuario(int usuarioId, string usuarioAplicacao)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("ExcluirUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);
                cmd.Parameters.AddWithValue("@UsuarioAplicacao", usuarioAplicacao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        internal DataTable ConsultarUsuario(int? usuarioId = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("ConsultarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (usuarioId.HasValue)
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioId.Value);
                else
                    cmd.Parameters.AddWithValue("@UsuarioID", DBNull.Value);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }
        public List<IUsuario> ConsultarUsuarios()
        {
            var lista = new List<IUsuario>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("ConsultarUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new Usuario
                        {
                            UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                            Nome = reader["Nome"].ToString(),
                            Email = reader["Email"].ToString(),
                            Senha = reader["Senha"].ToString(),
                            Cargo = reader["Cargo"].ToString(),
                            DataCriacao = Convert.ToDateTime(reader["DataCriacao"]),
                            Ativo = Convert.ToBoolean(reader["Ativo"]),
                            NivelAcesso = Convert.ToInt32(reader["NivelAcesso"])
                        };
                        lista.Add(usuario);
                    }
                }
            }
            return lista;
        }

        public void InserirUsuario(IUsuario usuario)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand("InserirUsuario", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nome", usuario.Nome);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
                cmd.Parameters.AddWithValue("@Cargo", usuario.Cargo); 
                cmd.Parameters.AddWithValue("@NivelAcesso", usuario.NivelAcesso);              
                cmd.Parameters.AddWithValue("@Ativo", usuario.Ativo);              
               cmd.Parameters.AddWithValue("@UsuarioAplicacao", usuario.UsuarioAplicacao); 

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void InserirStatusUsuario(int usuarioId, string situacao, DateTime dataStatus, DateTime? dataMod, bool acessoLiberacao, int nivelLiberacao)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(
                "INSERT INTO usuarioStatus (UsuarioID, Situacao, DataStatus, DataMod, AcessoLiberacao, NivelLiberacao) " +
                "VALUES (@UsuarioID, @Situacao, @DataStatus, @DataMod, @AcessoLiberacao, @NivelLiberacao)", conn))
            {
                cmd.Parameters.AddWithValue("@UsuarioID", usuarioId);
                cmd.Parameters.AddWithValue("@Situacao", situacao);
                cmd.Parameters.AddWithValue("@DataStatus", dataStatus);
                cmd.Parameters.AddWithValue("@DataMod", (object)dataMod ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@AcessoLiberacao", acessoLiberacao);
                cmd.Parameters.AddWithValue("@NivelLiberacao", nivelLiberacao);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ConsultarStatusUsuario(int? usuarioId = null)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM usuarioStatus" + (usuarioId.HasValue ? " WHERE UsuarioID = @UsuarioID" : "");
                if (usuarioId.HasValue)
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioId.Value);

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }     


    }
}
////exemplo de uso
//var usuarioComum = new Usuario("Comum");
//usuarioComum.InserirUsuario(...);
////
//var usuarioAdmin = new Usuario("Admin");
//usuarioAdmin.ExcluirUsuario(...);
////
//var usuarioWindows = new Usuario(); // padrão é "Windows"
//usuarioWindows.ConsultarUsuario(...);

//// Criando um novo usuário
//IUsuario novoUsuario = new UsuarioModel
//{
//    Nome = "João Silva",
//    Email = "joao@email.com",
//    Senha = "senha123",
//    Cargo = "Comum",
//    DataCriacao = DateTime.Now,
//    Ativo = true
//};

//usuarioDAL.InserirUsuario(novoUsuario, "adminApp");

//// Consultando usuários
//List<IUsuario> usuarios = usuarioDAL.ConsultarUsuarios();
//foreach (var usuario in usuarios)
//{
//    Console.WriteLine(usuario.Nome + " - " + usuario.Email);
//}
//exermplo de auditoria
//var auditoriaDAL = new AuditoriaAcesso();
//auditoriaDAL.InserirAuditoria(new AuditoriaAcesso
//{
//    UsuarioID = SessaoUsuario.UsuarioAtual.UsuarioID,
//    Acao = "Login",
//    DataHora = DateTime.Now,
//    UsuarioAplicacao = SessaoUsuario.UsuarioAtual.Nome,
//    Detalhes = "Login realizado com sucesso."
//});