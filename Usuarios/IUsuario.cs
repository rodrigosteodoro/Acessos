using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acessos
{
    public interface IUsuario
    {
        int UsuarioID { get; set; }
        string Nome { get; set; }
        string Email { get; set; }
        string Senha { get; set; }
        string Cargo { get; set; }
        DateTime DataCriacao { get; set; }
        bool Ativo { get; set; }
        int NivelAcesso { get; set; }
        string UsuarioAplicacao { get; set; } // Nome do usuário ou aplicação que está realizando a ação
    }
    public enum Cargo
    {
        Admin = 5,
        Gerente = 4,
        Supervisor = 3,
        Encarregado = 2,
        Comum = 1
    }

    public enum Acao
    {
        Visualizar,
        Editar,
        Excluir,
        Inserir
    }

}
