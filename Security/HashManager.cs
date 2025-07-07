
namespace Acessos
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    public static class HashSenhaManager
    {
        private const int TamanhoSalt = 16;       // 128 bits
        private const int TamanhoHash = 64;       // 512 bits
        private const int Iteracoes = 150_000; //aumentar aqui quando o hardware for mais potente

        /// <summary>
        /// Cria um hash seguro PBKDF2 da senha informada com salt aleatório.
        /// </summary>
        public static string CriarHash(string senha)
        {
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentException("Senha não pode ser vazia ou nula.");

            byte[] salt = GerarSaltAleatorio();

            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, Iteracoes, HashAlgorithmName.SHA512))
            {
                byte[] hash = pbkdf2.GetBytes(TamanhoHash);

                byte[] hashComSalt = new byte[TamanhoSalt + TamanhoHash];
                Buffer.BlockCopy(salt, 0, hashComSalt, 0, TamanhoSalt);
                Buffer.BlockCopy(hash, 0, hashComSalt, TamanhoSalt, TamanhoHash);

                return Convert.ToBase64String(hashComSalt);
            }
        }

        /// <summary>
        /// Verifica se a senha fornecida corresponde ao hash armazenado (contendo salt).
        /// </summary>
        public static bool VerificarSenha(string senha, string hashArmazenado)
        {
            if (string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(hashArmazenado))
                return false;

            try
            {
                byte[] hashComSalt = Convert.FromBase64String(hashArmazenado);

                if (hashComSalt.Length != (TamanhoSalt + TamanhoHash))
                    return false;

                byte[] salt = new byte[TamanhoSalt];
                Buffer.BlockCopy(hashComSalt, 0, salt, 0, TamanhoSalt);

                using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, Iteracoes, HashAlgorithmName.SHA512))
                {
                    byte[] novoHash = pbkdf2.GetBytes(TamanhoHash);

                    for (int i = 0; i < TamanhoHash; i++)
                    {
                        if (hashComSalt[TamanhoSalt + i] != novoHash[i])
                            return false;
                    }
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Gera um salt aleatório seguro.
        /// </summary>
        private static byte[] GerarSaltAleatorio()
        {
            var salt = new byte[TamanhoSalt];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }
        public static async Task AtualizarHashSenhaNoBanco(int usuarioId, string novaHash)
        {
            using (var conn = new SqlConnection(ConnectionManager.GetConnectionString()))
            {
                await conn.OpenAsync();
                using (var cmd = new SqlCommand("UPDATE usuario SET senha = @Senha WHERE id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Senha", novaHash);
                    cmd.Parameters.AddWithValue("@Id", usuarioId);
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
      

    }
    public static class HashSenhaMigrador
    {
        public static bool PrecisaMigrar(string senhaArmazenada)
        {
            if (string.IsNullOrWhiteSpace(senhaArmazenada))
                return true;

            // PBKDF2 com salt + hash deve ter 80 bytes → ~108 chars Base64
            try
            {
                var bytes = Convert.FromBase64String(senhaArmazenada);
                return bytes.Length != 80;
            }
            catch
            {
                return true; // não é Base64 válido = precisa migrar
            }
        }

        // SHA256 antigo como exemplo (caso tenha usado isso antes)
        public static string GerarHashSHA256(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }

        public static bool ValidarSenhaAntiga(string senha, string senhaArmazenada)
        {
            // Aqui pode ser só comparação direta (texto puro)
            return senha == senhaArmazenada
                || GerarHashSHA256(senha) == senhaArmazenada;
        }
        

    }

} // Exemplo de uso:
  //string hashSenha = HashSenhaManager.CriarHash("MinhaSenhaForte123!");
  // // Salvar hashSenha na coluna [Senha] do usuário

// bool senhaValida = HashSenhaManager.VerificarSenha(senhaDigitada, usuario.Senha);
// // Retorna true se bater com o hash do banco


