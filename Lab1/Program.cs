using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number;
            int[] divisors = { 2, 3, 4, 5, 6 };
            int j = 1;
            for(number=0;j<5; number+=7)
            {
                bool flag = true;
                foreach(int divisor in divisors)
                {
                    if (number % divisor != 1)
                    {
                        flag = false; break;
                    }
                    
                }
                if (flag && number % 7 == 0)
                {
                    if (j != 3)
                    {
                        Console.WriteLine(number);
                    }
                    j++;
                }
            }
        }
    }
}
