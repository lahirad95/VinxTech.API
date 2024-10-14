using System.Security.Cryptography;
using System.Text;

namespace VinxTech.API.Functions
{
    public class CommonFunctions
    {
        public static string HashPassword(string password)
        {
            // Create a new instance of the SHA256 class
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Compute the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a hexadecimal string
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
