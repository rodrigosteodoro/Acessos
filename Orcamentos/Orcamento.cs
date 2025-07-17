using System;
using System.Collections.Generic;
using System.Linq;
using Acessos.Orcamentos;

namespace Acessos
{

    public class ItemOrcamento: IItemOrcamento
    {
        public int ID { get; set; }
        public int OrcamentoID { get; set; }
        public int ProdutoID { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal Total => (Quantidade * PrecoUnitario) - ((Quantidade * PrecoUnitario) * Desconto / 100);
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
       
        public ItemOrcamento()
        {
            DataCadastro = DateTime.Now;
            Ativo = true;
            Desconto = 0;
        }
    }

    public class Orcamento : IOrcamento
    {
        public int ID { get; set; }
        public string CodigoOrcamento { get; set; }
        public int ClienteID { get; set; }
        public ICliente Cliente { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataValidade { get; set; }
        public decimal DescontoGeral { get; set; }
        public string Observacoes { get; set; }
        public StatusOrcamento Status { get; set; }
        public List<IItemOrcamento> Itens { get; set; } = new List<IItemOrcamento>();
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaModificacao { get; set; }
        public bool Ativo { get; set; }

        public decimal Subtotal => Itens.Where(i => i.Ativo).Sum(i => i.Total);
        public decimal ValorDesconto => Subtotal * DescontoGeral / 100;
        public decimal ValorTotal => Math.Max(0, Subtotal - ValorDesconto);

        public string StatusLabel => Status.ToString();

        public Orcamento()
        {
            var agora = DateTime.Now;
            DataCriacao = agora;
            DataCadastro = agora;
            UltimaModificacao = agora;
            DataValidade = agora.AddDays(30);
            Status = StatusOrcamento.Novo;
            Ativo = true;
            DescontoGeral = 0;
        }

        public void AdicionarItem(IItemOrcamento item)
        {
            if (item != null)
                Itens.Add(item);
            UltimaModificacao = DateTime.Now;
        }
        public void RemoverItem(IItemOrcamento item)
        {
            if (item != null)
                Itens.Remove(item);
            UltimaModificacao = DateTime.Now;
        }
    }


    public enum StatusOrcamento
    {
        Novo = 0,
        Pendente = 1,
        Aprovado = 2,
        Rejeitado = 3,
        Cancelado = 4,
        Expirado = 5
    }

}
