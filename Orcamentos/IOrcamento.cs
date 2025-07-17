using System;
using System.Collections.Generic;
using Acessos.Orcamentos;

namespace Acessos
{
    
    public interface IOrcamento
    {
        int ID { get; set; }
        string CodigoOrcamento { get; set; }
        int ClienteID { get; set; }        public ICliente Cliente { get; set; }
        DateTime DataCriacao { get; set; }
        DateTime? DataValidade { get; set; }
        decimal DescontoGeral { get; set; }
        string Observacoes { get; set; }
        StatusOrcamento Status { get; set; }
        List<IItemOrcamento> Itens { get; set; }
        DateTime DataCadastro { get; set; }
        DateTime UltimaModificacao { get; set; }
        bool Ativo { get; set; }

        decimal Subtotal { get; }
        decimal ValorDesconto { get; }
        decimal ValorTotal { get; }
        string StatusLabel { get; }
       
    }

}
