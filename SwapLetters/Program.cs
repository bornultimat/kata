using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwapLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] listOfStrings = new string[args.Length];

            for (int i = 0; i < args.Length; i++)
            {
                char[] seperatedString = args[i].ToCharArray();

                for (int j = 0; j < seperatedString.Length; j++)
                {
                    if (char.IsUpper(seperatedString[j]))
                    {
                        seperatedString[j] = char.ToLower(seperatedString[j]);
                    }
                    else
                    {
                        seperatedString[j] = char.ToUpper(seperatedString[j]);
                    }
                }
                listOfStrings[i] = new string(seperatedString);
            }

            foreach (var item in listOfStrings)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
