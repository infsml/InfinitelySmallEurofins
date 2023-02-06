using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Meth2
    {
        public static int gcd(int num1,int num2)
        {
            while (num2 > 0)
            {
                int r = num1%num2;
                num1 = num2;
                num2 = r;
            }
            return num1;
        }
        public static int lcm(int num1,int num2)
        {
            return (num1/gcd(num1,num2))*num2;
        }
        static void Main(string[] args)
        {
            int number;
            int[] divisors = { 2, 3, 4, 5, 6 };
            int displayNumberIndex = 1;
            int lcmOfDivisors = 1;
            foreach(int divisior in divisors)
            {
                lcmOfDivisors = lcm(lcmOfDivisors,divisior);
            }
            for (number = 1; displayNumberIndex < 5; number += lcmOfDivisors)
            {
                if (number % 7 == 0)
                {
                    if (displayNumberIndex != 3)
                    {
                        Console.WriteLine(number);
                    }
                    displayNumberIndex++;
                }
            }
        }
    }
}
