using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter a double ");
            double number = Convert.ToDouble(Console.ReadLine());
            int integerPart = (int)number;
            double fractionPart = number-integerPart;
            Console.WriteLine("Integer part " + integerPart);
            Console.WriteLine("Fraction part " + fractionPart);
        }
    }
}
