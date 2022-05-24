using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveValueFromList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 1 };
            int[] b = { 1};
            int[] c;

            c = RemoveValues(a, b);

            foreach (var item in c)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadLine();
        }

        public static int[] RemoveValues(int[] a, int[] b)
        {
            if (a.Length <= 0 || b.Length <= 0)
            {
                return new int[0];
            }
            else if (b.Length <= 0)
            {
                return a;
            }

            for (int i = 0; i < b.Length; i++)
            {
                a = a.Where(val => val != b[i]).ToArray();
            }

            return a;
        }
    }
}
