using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isValid = false;
            string pin = "1234";
            string wrongPin = "ab25";
            string longPin = "12345";

            if (!CheckPin(pin))
            {
                isValid = false;
            }
            else
            {
                isValid = true;
            }
            
        }

        private static bool CheckPin(string pin)
        {
            var chars = pin.ToCharArray();

            if (chars.Length == 4 || chars.Length == 6)
            {
                foreach (var item in chars)
                {
                    if (!int.TryParse(item.ToString(), out int temporaryDigit))
                    {
                        return false;
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}
