using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListFiltering
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = new List<object>() { 1, 2, "a", "b", 0, 15 };
            var result = GetIntegers(a);

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString()); ;
            }
            Console.ReadLine();
        }

        public static IEnumerable<int> GetIntegers(List<object> listOfObjects)
        {
            var result = new List<int>();

            foreach (var item in listOfObjects)
            {
                if (item is int)
                {
                    int.TryParse(item.ToString(), out int value);
                    result.Add(value);
                }
            }

            return result;
        }
    }
}
