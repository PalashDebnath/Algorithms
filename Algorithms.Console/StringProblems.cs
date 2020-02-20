using System.Text;

namespace Algorithms.Application
{
    public class String
    {
        //Time Complexity: O(n)
        //Space Complexity: O(1)
        public static bool CheckPalindroneUsingTraversal(string value)
        {
            int left = 0;
            int right = value.Length - 1;
            bool isPalindrome = true;
            while(left < right)
            {
                if(value[left] == value[right])
                {
                    left = left + 1;
                    right = right - 1;
                }
                else
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }

        //Time Complexity: O(n)
        //Space Complexity: O(n) -- for each recursive call there will be a frame in call stack
        public static bool CheckPalindromeUsingRecursion(string value)
        {
            int left = 0;
            int right = value.Length - 1;
            return left == right ? true : value[left] == value[right] && CheckPalindromeUsingRecursion(value.Substring(1, right - 1));
        }

        //You have to loop through the entire string which is O(n) and each time you will end up creating new string, which is another O(n)
        //Time Complexity: O(n*n) == O(n^2)
        //Space Complexity: O(n) --- Because you create a new reverse string of the same size of given array.
        public static bool CheckPalindroneUsingNewString(string value)
        {
            string reverseString = "";

            for(int i = value.Length - 1; i >= 0 ; i--)
            {
                //Everytime when add an element to the string it will delete the old string and create a new string with all the character
                //which is basically a time complexity of O(n)
                reverseString += value[i];
            }

            return reverseString.Equals(value);
        }

        //You have to loop through the entire string which is O(n) and and append it to the existing string
        //Time Complexity: O(n)
        //Space Complexity: O(n) --- Because you create a new reverse string of the same size of given array.
        public static bool CheckPalindroneUsingStringBuilder(string value)
        {
            StringBuilder reverseString = new StringBuilder();

            for(int i = value.Length - 1; i >= 0 ; i--)
            {
                reverseString.Append(value[i]);
            }

            return reverseString.Equals(value);
        }
    }

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