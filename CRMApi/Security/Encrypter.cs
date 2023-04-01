using System.Security.Cryptography;
using System.Text;

namespace CRMApi.Security
{
    public class Encrypter
    {
        public static string EncryptText(string text)
        {
            try
            {
                text = text.ToUpper();
                SHA256 sha256 = SHA256.Create();
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                byte[] hash = sha256.ComputeHash(bytes);

                StringBuilder result = new();
                for (int i = 0; i < hash.Length; i++)
                    result.Append(hash[i].ToString("X2"));

                return result.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public static string CreateDefaultPassword()
        {
            try
            {
                int length = 10;
                string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
                StringBuilder result = new();
                Random rnd = new();
                while (0 < length --)
                {
                    result.Append(characters[rnd.Next(characters.Length)]);
                }
                return result.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
