using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter two numbers : ");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(num1 + " " + num2);
            int t = num1;
            num1 = num2;
            num2 = t;
            Console.WriteLine(num1 + " " + num2);
        }
    }
}
