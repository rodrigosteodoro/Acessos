using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
    public interface IProdutos
    {
          int ID { get; set; }
          string CodigoProduto { get; set; }
          string CodigoBarras { get; set; }
          string Nome { get; set; }
          string Descricao { get; set; }
          decimal Peso { get; set; }
          decimal Volume { get; set; }
          DateTime DataValidade { get; set; }
          string Lote { get; set; }


        // Classificação
          string Categoria { get; set; }
          string Subcategoria { get; set; }
          string Marca { get; set; }
          int FornecedorID { get; set; }
          string NomeFornecedor { get; set; }
          string UnidadeMedida { get; set; }
          string TipoProduto { get; set; }

        // Estoque
          decimal QuantidadeAtual { get; set; }
          decimal EstoqueMinimo { get; set; }
          decimal EstoqueMaximo { get; set; }
          string LocalizacaoEstoque { get; set; }
          bool PermiteEstoqueNegativo { get; set; }

        // Preços
          decimal PrecoCusto { get; set; }
          decimal PrecoVenda { get; set; }
          decimal MargemLucro { get; set; }
          bool PromocaoAtiva { get; set; }
          decimal? PrecoPromocional { get; set; }
          DateTime? InicioPromocao { get; set; }
          DateTime? FimPromocao { get; set; }

        // Tributação
          string OrigemProduto { get; set; }
          string NCM { get; set; }
          string CFOP { get; set; }
          string CSTCSOSN { get; set; }
          decimal AliquotaICMS { get; set; }
          decimal AliquotaPIS { get; set; }
          decimal AliquotaCOFINS { get; set; }
          decimal AliquotaIPI { get; set; }

        // Imagem
          byte[] Imagem { get; set; }

        // Informações Complementares
          bool Ativo { get; set; }
          string Observacoes { get; set; }
          string SKU { get; set; }
          DateTime DataCadastro { get; set; }
          DateTime UltimaAlteracao { get; set; }
    }
}
