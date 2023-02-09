using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q20
    {
        public static void Main()
        {
            Console.WriteLine("Enter the base : ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the exponent : ");
            int n = int.Parse(Console.ReadLine());
            long[] powers = new long[32];
            powers[0] = a;
            for(int i = 1; i < 32; i++)
            {
                powers[i] = powers[i - 1] * powers[i-1];
            }
            long res = 1;
            int j = 0;
            for (int i = n; i > 0; i /= 2)
            {
                if (i % 2 == 1)
                {
                    res *= powers[j];
                }
                j++;
            }
            Console.WriteLine("Result : " + res);
        }
    }
}
