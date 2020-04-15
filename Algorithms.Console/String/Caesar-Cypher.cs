using System.Text;

namespace Algorithms.Problems
{
    public static class CaesarCypher
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

        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static string Decryptor(string value, int key)
        {
            StringBuilder encryptValue = new StringBuilder();
            int ascii = 0;
            for(int i = 0; i < value.Length; i++)
            {
                ascii = (int)value[i] - key;
                ascii = ascii < 97 ? 123 - (97 - ascii) : ascii;
                encryptValue.Append((char)ascii);
            }
            return encryptValue.ToString();
        }
    }
}