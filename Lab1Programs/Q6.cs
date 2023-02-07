using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q6
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 3 numbers");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int num3 = Convert.ToInt32(Console.ReadLine());
            int t;
            if (num1 > num2)
            {
                t = num1; num1 = num2; num2 = t;
            }
            if (num2 > num3)
            {
                t = num3; num3 = num2; num2 = t;
            }
            if (num1 > num2)
            {
                t = num1; num1 = num2; num2 = t;
            }
            Console.WriteLine("Largest " + num3 + " Second largest " + num2);
        }
    }
}
