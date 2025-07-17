using System.Collections.Generic;
using System.Threading.Tasks;

namespace Acessos.Orcamentos
{
  

    public interface IOrcamentoRepository
    {
        Task<int> InserirOrcamentoAsync(IOrcamento orcamento);
        Task<bool> AtualizarOrcamentoAsync(IOrcamento orcamento);
        Task<bool> CancelarOrcamentoAsync(int orcamentoId);
        Task<IOrcamento> ObterOrcamentoPorIdAsync(int id);
        Task<List<IOrcamento>> ObterOrcamentosPorClienteAsync(int clienteId);
        Task<List<IOrcamento>> ObterTodosOrcamentosAsync();
    }

}
