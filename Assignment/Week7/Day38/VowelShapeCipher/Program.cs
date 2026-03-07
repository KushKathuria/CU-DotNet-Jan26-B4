using System.Runtime.CompilerServices;

namespace VowelShapeCipher
{
    internal class Program
    {
        static string transform(string s)
        {
            string result = "";
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

            foreach (char i in s)
            {
                if (vowels.Contains(i))
                {
                    int ind = Array.IndexOf(vowels, i) + 1;
                    ind = ind % vowels.Length;

                    result += vowels[ind];
                }
                else
                {
                    if (i == 'z')
                    {
                        result += 'b';
                        continue;
                    }
                    char r = (char)(i + 1);
                    if (vowels.Contains(r)) result += (char)(r + 1);
                    //else if (r == 'z') result += 'b';
                    else { result += (char)(r); }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {

            string s = "crypt";
            Console.WriteLine(transform(s));
        }
    }
}
