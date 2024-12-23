using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Tools
{
    public class StringManipulator
    {
        public static string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input; 
            }

            return char.ToUpper(input[0]) + input.ToLower().Substring(1);
        }
        public static bool ContainsInteger(string input)
        {
            
            foreach (char c in input)
            {
                if (char.IsDigit(c)) 
                {
                    return true; 
                }
            }
            return false;
        }
    }
}
