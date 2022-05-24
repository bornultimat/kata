using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sequence_Classifier
{
    /// <summary>
    /// PLEASE DONT LOOK AT THIS CODE....IT'S JUST SH*T
    /// </summary>
    internal class Program
    {
 
        //0bxxx => binary system
        static void Main(string[] args)
        {
            //[2] = increasing;
            //[3] = decreasing;
            //[4] = even;
            var mask = 0b000;
            var values = new int[args.Length];
            int result;

            for (int i = 0; i < args.Length; i++)
            {
                int.TryParse(args[i], out values[i]);
            }

            for (int i = 0; i < values.Length - 1; i++)
            {
                if (values[i] < values[i + 1])
                {
                    mask |= 0b100;
                }
                else if (values[i] > values[i + 1])
                {
                    mask |= 0b010;
                }
                else
                {
                    mask |= 0b001;
                }
            }

            switch (mask)
            {
                case 0b100:
                    result = 1;
                    break;
                case 0b101:
                    result = 2;
                    break;
                case 0b010:
                    result = 3;
                    break;
                case 0b011:
                    result = 4;
                    break;
                case 0b001:
                    result = 5;
                    break;
                default:
                    result = 0;
                    break;
            }

            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}




/* IGNORE THIS SHIT
 * 
 * 
 * 
 * 
 *        public enum CompareResults
        {
            increasing,
            decreasing,
            even
        }
 * 
         /// <summary>
        /// 0 = ungeordnet
        /// 1 = streng monoton steigend
        /// 2 = monoton steigend
        /// 3 = streng monoton fallend
        /// 4 = monoton fallend
        /// 5 = konstant
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        internal static int Comparer(int[] array)
        {
            List<CompareResults> results = new List<CompareResults>();
            int firstNumber;
            bool konstantCourse = true;

            if (array.Length < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(array), "Array must be greater than zero!");
            }
            else if (array.Length == 1)
            {
                return 5;
            }

            firstNumber = array[0];

            for (int i = 0; i < array.Length - 1; i++)
            {
               results.Add(CompareTwoInt(array[i], array[i + 1]));
            }

            for (int i = 0; i < results.Count; i++)
            {
                if (results[0] == results[i])
                {
                    if (!konstantCourse)
                    {
                        if (i == results.Count - 1 && results[i] == CompareResults.decreasing)
                        {
                            return 4;
                        }
                        else if (i == results.Count - 1 && results[i] == CompareResults.increasing)
                        {
                            return 2;
                        }
                        else
                        {
                            if (CompareTwoInt(array[0], array[i + 1]) == CompareResults.decreasing)
                            {
                                return 4;
                            }
                            else if(CompareTwoInt(array[0], array[i + 1]) == CompareResults.increasing)
                            {
                                return 2;
                            }
                        }
                    }
                    else
                    {
                        if (i == results.Count - 1 && results[i] == CompareResults.even)
                        {
                            return 5;
                        }
                        else if (i == results.Count - 1 && results[i] == CompareResults.decreasing)
                        {
                            return 3;
                        }
                        else if (i == results.Count - 1 && results[i] == CompareResults.increasing)
                        {
                            return 1;
                        }
                    }

                    continue;
                }
                else if (results[0] != results[i] && results[i] == CompareResults.even || results[0] == CompareResults.even)
                {
                    if (i == results.Count - 1)
                    {
                        if (CompareTwoInt(array[0], array[i + 1]) == CompareResults.decreasing)
                        {
                            return 4;
                        }
                        else if (CompareTwoInt(array[0], array[i + 1]) == CompareResults.increasing)
                        {
                            return 2;
                        }
                    }

                    konstantCourse = false;
                    continue;
                }
                else
                {
                    continue;
                }
            }

            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private static CompareResults CompareTwoInt(int v1, int v2)
        {
            if (v1 < v2)
            {
                return CompareResults.increasing;
            }
            else if(v1 == v2)
            {
                return CompareResults.even;
            }
            else
            {
                return CompareResults.decreasing;
            }
        }
 
 
 */
