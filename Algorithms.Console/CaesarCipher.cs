using System.Text;

namespace Algorithms.Application
{
    public class CaesarCipher
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static string Encryptor(string value, int key)
        {
            StringBuilder encryptValue = new StringBuilder();
            int ascii = 0;
            for(int i = 0; i < value.Length; i++)
            {
                ascii = (int)value[i] + key;
                ascii = ascii > 122 ? 96 + ((ascii - 122) % 26) : ascii;
                encryptValue.Append((char)ascii);
            }
            return encryptValue.ToString();
        }
    }
}