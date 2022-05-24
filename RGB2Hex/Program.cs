using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGB2Hex
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RGB2Hex(280, 120, 390));
            Console.ReadLine();
        }

        internal static string RGB2Hex(int r, int g, int b)
        {
            var hexLetters = new string[] { "A", "B", "C", "D", "E", "F" };
            var convertedHex = string.Empty;
            double secondaryResult = 0;
            int frontNumber;
            bool firstRun = true;
            string decimalNumber = string.Empty;
            
            int[] rgb = new int[3] { b,g,r };

            for (int i = 0; i < rgb.Length; i++)
            {
                secondaryResult = rgb[i];
                firstRun = true;
                do
                {
                    if (secondaryResult <= 0)
                    {
                        convertedHex += "00";
                        break;
                    }
                    else if (secondaryResult > 255)
                    {
                        convertedHex += "FF";
                        break;
                    }

                    secondaryResult = secondaryResult / 16d;

                    var result = secondaryResult.ToString().Split(',');
                    int.TryParse(result[0], out frontNumber);
                    
                    if(result.Length > 1)
                    {
                        result[0] = "0";
                        decimalNumber = result[0] + "," + result[1];
                    }
                    else
                    {
                        result[0] = "0";
                        decimalNumber = result[0];
                    }
                    

                    double.TryParse(decimalNumber, out double rest);

                    secondaryResult = rest * 16;

                    if (secondaryResult > 9)
                    {
                        int.TryParse(secondaryResult.ToString(), out int final);

                        if (frontNumber <= 0 && firstRun)
                        {
                            convertedHex += hexLetters[final - 10] + "0";
                        }
                        else
                        {
                            convertedHex += hexLetters[final - 10];
                        }
                    }
                    else
                    {
                        if (frontNumber <= 0 && firstRun)
                        {
                            convertedHex += secondaryResult.ToString() + "0";
                        }

                        convertedHex += secondaryResult.ToString();
                    }

                    if (frontNumber > 0)
                    {
                        secondaryResult = frontNumber;
                    }

                    firstRun = false;

                } while (frontNumber != 0);
                
            }

            char[] hex = convertedHex.ToCharArray();
            Array.Reverse(hex);
            var hexa = new string(hex);

            return hexa;
        }
    }
}
