using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos.Orcamentos
{
    public interface IItemOrcamento
    {
        int ID { get; set; }
        int OrcamentoID { get; set; }
        int ProdutoID { get; set; }
        string DescricaoProduto { get; set; }
        decimal Quantidade { get; set; }
        decimal PrecoUnitario { get; set; }
        decimal Desconto { get; set; }
        decimal Total { get; } // property de leitura/calculada
        DateTime DataCadastro { get; set; }
        bool Ativo { get; set; }
    }

}
