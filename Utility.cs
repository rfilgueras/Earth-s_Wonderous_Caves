using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace VirtualEcosystemTwo
{
    public class Utility
    {
        public static string Print(string output)
        {
            string text = "";
            text += (output);
            return text;
        }
        
       public static string SuccessTxt(string text)
        {
            ForegroundColor = ConsoleColor.Green;
            Print(text);
            ResetColor();
            return text;
        }

        public static string WarningTxt(string text)
        {
            ForegroundColor = ConsoleColor.Red;
            Print(text);
            ResetColor();
            return text;
        }
    }
}
