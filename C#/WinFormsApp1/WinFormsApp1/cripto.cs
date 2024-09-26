using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    internal class cripto
    {
        private const int SaltSize = 16; // 128 bits
        private const int HashSize = 32; // 256 bits
        private const int interacoes = 10000; // Iterações de hashing

        public string senha(string senha)
        {
            // Gera o salt aleatório
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SaltSize];
                rng.GetBytes(salt);

                // Aplica PBKDF2 com o salt
                using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, interacoes))
                {
                    byte[] hash = pbkdf2.GetBytes(HashSize);

                    // Concatena salt e hash em uma string base64 para armazenamento
                    byte[] hashBytes = new byte[SaltSize + HashSize];
                    Array.Copy(salt, 0, hashBytes, 0, SaltSize);
                    Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

                    return Convert.ToBase64String(hashBytes);
                }
            }
        }
        public bool verificar(string storedHash, string senha)
        {
            // Decodifica a string armazenada
            byte[] hashBytes = Convert.FromBase64String(storedHash);

            // Extrai o salt do hash armazenado
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Aplica PBKDF2 com o salt extraído
            using (var pbkdf2 = new Rfc2898DeriveBytes(senha, salt, interacoes))
            {
                byte[] hash = pbkdf2.GetBytes(HashSize);

                // Compara byte a byte o hash gerado com o armazenado
                for (int i = 0; i < HashSize; i++)
                {
                    if (hashBytes[i + SaltSize] != hash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

    }
}
