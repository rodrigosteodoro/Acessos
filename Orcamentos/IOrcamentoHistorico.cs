using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
   public interface IOrcamentoHistorico
    {

         int Id { get; set; }
         int OrcamentoId { get; set; }
         int UsuarioId { get; set; }
         DateTime DataAlteracao { get; set; }
         string Acao { get; set; }
         string Detalhes { get; set; }

        OrcamentoHistorico ObterHistoricoPorId(SqlConnection conexao, int id);
        List<OrcamentoHistorico> ObterHistoricoPorOrcamentoId(SqlConnection conexao, int orcamentoId);
        List<OrcamentoHistorico> ObterHistoricoPorUsuarioId(SqlConnection conexao, int? usuarioId);
        void RegistrarHistorico(SqlConnection conexao, int orcamentoId, int usuarioId, string acao, string detalhes);    
      
    }
}
