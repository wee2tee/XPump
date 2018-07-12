using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XPump.Misc
{
    public static class StringEnh
    {
        public static string Encrypted(this string string_to_encrypt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(string_to_encrypt);

            string base64 = Convert.ToBase64String(bytes);

            return base64;
        }

        public static string Decrypted(this string string_to_decrypt)
        {
            byte[] bytes = Convert.FromBase64String(string_to_decrypt);

            string decrypted = Encoding.ASCII.GetString(bytes);

            return decrypted;
        }
    }
}
