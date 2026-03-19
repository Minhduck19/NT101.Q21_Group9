using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _2._3
{
    public class CipherProcessor
    {
        private const string ALPHABET = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string Normalize(string input)
        {
            string upper = input.ToUpper();
            return Regex.Replace(upper, "[^A-Z]", "");
        }
        public static string Decrypt(string ciphertext, string key)
        {
            StringBuilder plaintext = new StringBuilder(ciphertext.Length);

            foreach (char c in ciphertext)
            {
                if (char.IsLetter(c))
                {
                    bool isLower = char.IsLower(c);
                    char upperC = char.ToUpper(c);

                    //tìm ký tự trong Key, dịch về chữ gốc
                    int index = key.IndexOf(upperC);

                    if (index != -1)
                    {
                        char decryptedChar = ALPHABET[index];
                        // định dạng chữ hoa/thường ban đầu
                        plaintext.Append(isLower ? char.ToLower(decryptedChar) : decryptedChar);
                    }
                    else
                    {
                        plaintext.Append(c);
                    }
                }
                else
                {
                    plaintext.Append(c);//giữ nguyên dấu câu, cách
                }
            }
            return plaintext.ToString();
        }
    }
}
