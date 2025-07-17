using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;



namespace  Acessos
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.Threading.Tasks;

    namespace Acessos
    {
        public class OrcamentoAprovacao : IOrcamentoAprovacaoService
        {
            public int Id { get; set; }
            public int OrcamentoId { get; set; }
            public int UsuarioId { get; set; }
            public DateTime DataAprovacao { get; set; }
            public string Status { get; set; }
            public string Observacoes { get; set; }

            public async Task<bool> SolicitarAprovacaoAsync(SqlConnection conexao, int orcamentoId, int usuarioSolicitanteId)
            {
                try
                {
                    // Atualiza status do orçamento
                    using (var cmdAtualizaStatus = new SqlCommand(
                        "UPDATE Orcamentos SET Status = 'Pendente' WHERE Id = @OrcamentoId",
                        conexao))
                    {
                        cmdAtualizaStatus.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                        await cmdAtualizaStatus.ExecuteNonQueryAsync();
                    }

                    // Registra solicitação de aprovação
                    using (var cmd = new SqlCommand(
                        "INSERT INTO OrcamentoAprovacoes (OrcamentoId, UsuarioId, Status) VALUES (@OrcamentoId, @UsuarioId, 'Pendente')",
                        conexao))
                    {
                        cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioSolicitanteId);
                        await cmd.ExecuteNonQueryAsync();
                    }

                    // Registra no histórico
                    var OrcamentoHistorico = new OrcamentoHistorico();
                    OrcamentoHistorico.RegistrarHistorico(
                        conexao, orcamentoId, usuarioSolicitanteId, "Solicitação de Aprovação", "Orçamento enviado para aprovação"
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao solicitar aprovação: " + ex.Message);
                    return false;
                }
            }

            public async Task<bool> AprovarOrcamentoAsync(SqlConnection conexao, int orcamentoId, int usuarioAprovadorId, string observacoes)
            {
                try
                {
                    // Atualiza status do orçamento
                    using (var cmdAtualizaStatus = new SqlCommand(
                        "UPDATE Orcamentos SET Status = 'Aprovado' WHERE Id = @OrcamentoId", conexao))
                    {
                        cmdAtualizaStatus.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                        await cmdAtualizaStatus.ExecuteNonQueryAsync();
                    }

                    // Atualiza registro de aprovação
                    int rowsAffected;
                    using (var cmd = new SqlCommand(
                        "UPDATE OrcamentoAprovacoes SET Status = 'Aprovado', DataAprovacao = GETDATE(), " +
                        "Observacoes = @Observacoes, UsuarioId = @UsuarioId WHERE OrcamentoId = @OrcamentoId AND Status = 'Pendente'",
                        conexao))
                    {
                        cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioAprovadorId);
                        cmd.Parameters.AddWithValue("@Observacoes", observacoes ?? "");
                        rowsAffected = await cmd.ExecuteNonQueryAsync();
                    }

                    if (rowsAffected == 0)
                    {
                        // Se não havia registro pendente, cria um novo
                        using (var cmd = new SqlCommand(
                            "INSERT INTO OrcamentoAprovacoes (OrcamentoId, UsuarioId, Status, Observacoes) " +
                            "VALUES (@OrcamentoId, @UsuarioId, 'Aprovado', @Observacoes)",
                            conexao))
                        {
                            cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                            cmd.Parameters.AddWithValue("@UsuarioId", usuarioAprovadorId);
                            cmd.Parameters.AddWithValue("@Observacoes", observacoes ?? "");
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    // Registra no histórico
                    var OrcamentoHistorico = new OrcamentoHistorico();
                    OrcamentoHistorico.RegistrarHistorico(
                        conexao, orcamentoId, usuarioAprovadorId, "Aprovado", $"Orçamento aprovado. Observações: {observacoes}"
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao aprovar orçamento: " + ex.Message);
                    return false;
                }
            }

            public async Task<bool> RejeitarOrcamentoAsync(SqlConnection conexao, int orcamentoId, int usuarioAprovadorId, string observacoes)
            {
                try
                {
                    // Atualiza status do orçamento
                    using (var cmdAtualizaStatus = new SqlCommand(
                        "UPDATE Orcamentos SET Status = 'Rejeitado' WHERE Id = @OrcamentoId",
                        conexao))
                    {
                        cmdAtualizaStatus.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                        await cmdAtualizaStatus.ExecuteNonQueryAsync();
                    }

                    // Atualiza registro de aprovação
                    int rowsAffected;
                    using (var cmd = new SqlCommand(
                        "UPDATE OrcamentoAprovacoes SET Status = 'Rejeitado', DataAprovacao = GETDATE(), " +
                        "Observacoes = @Observacoes, UsuarioId = @UsuarioId " +
                        "WHERE OrcamentoId = @OrcamentoId AND Status = 'Pendente'",
                        conexao))
                    {
                        cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioAprovadorId);
                        cmd.Parameters.AddWithValue("@Observacoes", observacoes ?? "");
                        rowsAffected = await cmd.ExecuteNonQueryAsync();
                    }

                    if (rowsAffected == 0)
                    {
                        // Se não havia registro pendente, cria um novo
                        using (var cmd = new SqlCommand(
                            "INSERT INTO OrcamentoAprovacoes (OrcamentoId, UsuarioId, Status, Observacoes) " +
                            "VALUES (@OrcamentoId, @UsuarioId, 'Rejeitado', @Observacoes)",
                            conexao))
                        {
                            cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);
                            cmd.Parameters.AddWithValue("@UsuarioId", usuarioAprovadorId);
                            cmd.Parameters.AddWithValue("@Observacoes", observacoes ?? "");
                            await cmd.ExecuteNonQueryAsync();
                        }
                    }

                    // Registra no histórico
                    var OrcamentoHistorico = new OrcamentoHistorico();
                    OrcamentoHistorico.RegistrarHistorico(
                        conexao, orcamentoId, usuarioAprovadorId, "Rejeitado", $"Orçamento rejeitado. Observações: {observacoes}"
                    );

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao rejeitar orçamento: " + ex.Message);
                    return false;
                }
            }

            public async Task<DataTable> ObterHistoricoAprovacoesAsync(SqlConnection conexao, int orcamentoId)
            {
                DataTable dt = new DataTable();
                try
                {
                    using (var cmd = new SqlCommand(
                        "SELECT oa.DataAprovacao, u.Nome AS Aprovador, oa.Status, oa.Observacoes " +
                        "FROM OrcamentoAprovacoes oa " +
                        "JOIN Usuarios u ON oa.UsuarioId = u.Id " +
                        "WHERE oa.OrcamentoId = @OrcamentoId " +
                        "ORDER BY oa.DataAprovacao DESC", conexao))
                    {
                        cmd.Parameters.AddWithValue("@OrcamentoId", orcamentoId);

                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            dt.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao obter histórico de aprovações: " + ex.Message);
                }

                return dt;
            }
        }
    }

   
public interface IOrcamentoAprovacaoService
    {
        Task<bool> SolicitarAprovacaoAsync(SqlConnection conexao, int orcamentoId, int usuarioSolicitanteId);
        Task<bool> AprovarOrcamentoAsync(SqlConnection conexao, int orcamentoId, int usuarioAprovadorId, string observacoes);
        Task<bool> RejeitarOrcamentoAsync(SqlConnection conexao, int orcamentoId, int usuarioAprovadorId, string observacoes);
        Task<DataTable> ObterHistoricoAprovacoesAsync(SqlConnection conexao, int orcamentoId);
    }


}
