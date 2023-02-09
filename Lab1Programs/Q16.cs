using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q16
    {
        static void Main()
        {
            Console.WriteLine("Enter a number : ");
            string bin = Console.ReadLine();
            char[] chars = bin.ToCharArray();
            int n = 0;
            for(int i=0; i<chars.Length; i++)
            {
                n = (n << 1) + chars[i] - '0';
            }
            Console.WriteLine("Decimal : "+n);
        }
    }
}
