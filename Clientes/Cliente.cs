using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Data.SqlClient;

namespace Acessos
{
    public class Cliente:ICliente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string CPFCNPJ { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public decimal? RendaDeclarada { get; set; }
        public string CEP { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Estado { get; set; }
        public string Regiao { get; set; }
        public string IBGE { get; set; }
        public string Complemento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimaModificacao { get; set; }
        public bool Ativo { get; set; }
        public string Telefone { get; set; }
    }   
}
