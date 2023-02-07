using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q1
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Principle : ");
            int principle = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Rate of Interest : ");
            int rate = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Time in years : ");
            int time = Convert.ToInt32(Console.ReadLine());
            int simpleInterest = (principle * rate * time) / 100;
            Console.WriteLine("Simple Interst " + simpleInterest);
        }
    }
}
