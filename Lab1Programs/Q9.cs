using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q9
    {
        static void Main()
        {
            Console.WriteLine("Enter n ");
            int n = Convert.ToInt32(Console.ReadLine());
            int sumOfOddNumbers = 0;
            for(int i = 1; i <= n;i+=2)
            {
                sumOfOddNumbers += i;
            }
            Console.WriteLine("The sum of odd numbers from 1 to " + n + " is " + sumOfOddNumbers);
        }
    }
}
