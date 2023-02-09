using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q21
    {
        public static void Main()
        {
            Console.WriteLine("Enter a string : ");
            string s = Console.ReadLine();
            string rev = s.ToCharArray().Reverse().ToString();
            Console.WriteLine("Reverse : " + rev);
        }
    }
}
