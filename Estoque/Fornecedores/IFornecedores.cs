using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos.Estoque.Fornecedores
{
      interface IFornecedores
    {
          int ID { get; set; }
          string RazaoSocial { get; set; }
          string NomeFantasia { get; set; }
          string CNPJ { get; set; }
          DateTime? DataFundacao { get; set; }
          string Telefone { get; set; }
          string Email { get; set; }
          string Site { get; set; }
          string Endereco { get; set; }
          string Numero { get; set; }
          string CEP { get; set; }
          string Logradouro { get; set; }
          string Bairro { get; set; }
          string Localidade { get; set; }
          string UF { get; set; }
          string Estado { get; set; }
          string Regiao { get; set; }
          string IBGE { get; set; }
          string Complemento { get; set; }
          string Contato { get; set; }
          string TipoFornecedor { get; set; }
          string Status { get; set; }
          string Observacoes { get; set; }
          DateTime DataCadastro { get; set; }
          DateTime UltimaModificacao { get; set; }
          bool Ativo { get; set; }
    }
}
