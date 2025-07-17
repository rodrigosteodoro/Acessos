using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
    public class OrcamentoAprovacaoModel
    {
        public int ID { get; set; }
        public string CodigoOrcamento { get; set; }
        public string NomeCliente { get; set; }
        public string CPFCNPJ { get; set; }
        public DateTime DataCriacao { get; set; }
        public decimal ValorTotal { get; set; }
        public int Status { get; set; }
        public string StatusDescricao { get; set; }
    }
}
