using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
   public interface ICliente
    {
         int ID { get; set; }
         string Nome { get; set; }
         string CPFCNPJ { get; set; }
         DateTime? DataNascimento { get; set; }
         string Endereco { get; set; }
         string Numero { get; set; }
         decimal? RendaDeclarada { get; set; }
         string CEP { get; set; }
         string Logradouro { get; set; }
         string Bairro { get; set; }
         string Localidade { get; set; }
         string UF { get; set; }
         string Estado { get; set; }
         string Regiao { get; set; }
         string IBGE { get; set; }
         string Complemento { get; set; }
         DateTime DataCadastro { get; set; }
         DateTime UltimaModificacao { get; set; }
         bool Ativo { get; set; }
         string Telefone { get; set; }
    }
    public interface IClienteRepository
    {
        Task<int> InserirClienteAsync(ICliente cliente);
        Task<bool> AtualizarClienteAsync(ICliente cliente);
        Task<bool> InativarClienteAsync(int id);
        Task<List<ICliente>> ObterTodosClientesAsync();
        Task<ICliente> ObterClientePorIdAsync(int id);
        Task<List<ICliente>> BuscarClientesPorNomeAsync(string nome);
        Task<int> ObterTotalClientesAsync();
    }
}
