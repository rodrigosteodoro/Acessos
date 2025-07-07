using System;

namespace Acessos
{
    public  class UsuarioLogado: IUsuarioStatus
    {
        public int UsuarioID { get; set; }
        public  string Nome { get; set; }
        public  string Email { get; set; }
        public  string Cargo { get; set; }
        public int NivelAcesso { get; set; }
        public  DateTime DataLogin { get; set; }
        public int UsuarioStatusID { get; set; }      
        public string Situacao { get; set; }
        public DateTime DataStatus { get; set; }
        public DateTime? DataMod { get; set; }
        public bool AcessoLiberacao { get; set; }
        public int NivelLiberacao { get; set; }

    }

    // Classe estática para manter o usuário logado acessível globalmente
    public static class SessaoUsuario
    {
        public static UsuarioLogado UsuarioAtual { get; set; }
    }

}
//SessaoUsuario.UsuarioAtual = new UsuarioLogado
//{
//    UsuarioID = usuarioDoBanco.UsuarioID,
//    Nome = usuarioDoBanco.Nome,
//    Email = usuarioDoBanco.Email,
//    Cargo = usuarioDoBanco.Cargo,
//    DataLogin = DateTime.Now
//};



//var usuario = SessaoUsuario.UsuarioAtual;

//// Exemplo de uso em auditoria:
//var auditoria = new AuditoriaAcessoModel
//{
//    UsuarioID = usuario.UsuarioID,
//    Acao = "Login",
//    DataHora = DateTime.Now,
//    UsuarioAplicacao = usuario.Nome,
//    Detalhes = "Usuário efetuou login."
//};
