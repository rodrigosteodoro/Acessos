using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace Acessos
{
    public class Produto : IProdutos
    {
        public int ID { get; set; }
        public string CodigoProduto { get; set; }
        public string CodigoBarras { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Peso { get; set; }
        public decimal Volume { get; set; }
        public DateTime? DataValidade { get; set; }
        public string Lote { get; set; }


        // Classificação
        public string Categoria { get; set; }
        public string Subcategoria { get; set; }
        public string Marca { get; set; }
        public int FornecedorID { get; set; }
        public string NomeFornecedor { get; set; }
        public string UnidadeMedida { get; set; }
        public string TipoProduto { get; set; }

        // Estoque
        public decimal QuantidadeAtual { get; set; }
        public decimal EstoqueMinimo { get; set; }
        public decimal EstoqueMaximo { get; set; }
        public string LocalizacaoEstoque { get; set; }
        public bool PermiteEstoqueNegativo { get; set; }

        // Preços
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public decimal MargemLucro { get; set; }
        public bool PromocaoAtiva { get; set; }
        public decimal? PrecoPromocional { get; set; }
        public DateTime? InicioPromocao { get; set; }
        public DateTime? FimPromocao { get; set; }

        // Tributação
        public string OrigemProduto { get; set; }
        public string NCM { get; set; }
        public string CFOP { get; set; }
        public string CSTCSOSN { get; set; }
        public decimal AliquotaICMS { get; set; }
        public decimal AliquotaPIS { get; set; }
        public decimal AliquotaCOFINS { get; set; }
        public decimal AliquotaIPI { get; set; }

        // Imagem
        public byte[] Imagem { get; set; }

        // Informações Complementares
        public bool Ativo { get; set; }
        public string Observacoes { get; set; }
        public string SKU { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaAlteracao { get; set; }


        public Produto()
        {
            DataCadastro = DateTime.Now;
            UltimaAlteracao = DateTime.Now;
            Ativo = true;
            PermiteEstoqueNegativo = false;
            PromocaoAtiva = false;
            DataCadastro = DateTime.Now;
            UltimaAlteracao = DateTime.Now;
            Ativo = true;
            PermiteEstoqueNegativo = false;
            PromocaoAtiva = false;
            Peso = 0;
            Volume = 0;
            EstoqueMinimo = 0;
            EstoqueMaximo = 0;
        }
        public async Task<List<Produto>> ObterTodosAsync()
        {
            using (var connection = new SqlConnection(ConnectionManager.GetConnectionString("Admin")))
            {
                var result = await connection.QueryAsync<Produto>("SELECT * FROM Produtos");
                return result.ToList();
            }
        }

        public Produto Clone()
        {
            return new Produto
            {
                //clonar as propriedades do produto
                ID = this.ID,
                DataValidade = this.DataValidade,
                Lote = this.Lote,
                CodigoProduto = this.CodigoProduto,
                CodigoBarras = this.CodigoBarras,
                Nome = this.Nome,
                Descricao = this.Descricao,
                Categoria = this.Categoria,
                Subcategoria = this.Subcategoria,
                Marca = this.Marca,
                FornecedorID = this.FornecedorID,
                NomeFornecedor = this.NomeFornecedor,
                UnidadeMedida = this.UnidadeMedida,
                TipoProduto = this.TipoProduto,
                QuantidadeAtual = this.QuantidadeAtual,
                EstoqueMinimo = this.EstoqueMinimo,
                EstoqueMaximo = this.EstoqueMaximo,
                LocalizacaoEstoque = this.LocalizacaoEstoque,
                PermiteEstoqueNegativo = this.PermiteEstoqueNegativo,
                PrecoCusto = this.PrecoCusto,
                PrecoVenda = this.PrecoVenda,
                MargemLucro = this.MargemLucro,
                PromocaoAtiva = this.PromocaoAtiva,
                PrecoPromocional = this.PrecoPromocional,
                InicioPromocao = this.InicioPromocao,
                FimPromocao = this.FimPromocao,
                OrigemProduto = this.OrigemProduto,
                NCM = this.NCM,
                CFOP = this.CFOP,
                CSTCSOSN = this.CSTCSOSN,
                AliquotaICMS = this.AliquotaICMS,
                AliquotaPIS = this.AliquotaPIS,
                AliquotaCOFINS = this.AliquotaCOFINS,
                AliquotaIPI = this.AliquotaIPI,
                Ativo = this.Ativo,
                Observacoes = this.Observacoes,
                SKU = this.SKU,
                DataCadastro = this.DataCadastro,
                UltimaAlteracao = this.UltimaAlteracao,
                Peso = this.Peso,
                Volume = this.Volume,
                Imagem = this.Imagem != null ? (byte[])this.Imagem.Clone() : null
            };
        }

    }
}

   
        

