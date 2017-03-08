using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPump.Misc
{
    public class StringEnh
    {
        public static string Encrypted(string string_to_encrypt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string_to_encrypt);

            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }

        public static string Decrypted(string string_to_decrypt)
        {
            byte[] bytes = Convert.FromBase64String(string_to_decrypt);

            string decrypted = Encoding.Default.GetString(bytes);

            return decrypted;
        }
    }
}
