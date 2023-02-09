using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q15
    {
        static void Main()
        {
            Console.WriteLine("Enter a number : ");
            int n = int.Parse(Console.ReadLine());
            string bin = "";
            for(int i = n; i > 0; i /= 2)
            {
                bin = (i%2)+bin;
            }
            Console.WriteLine(bin);
        }
    }
}
