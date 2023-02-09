using SimpleCalculator.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args) //UI Logic
        {
            //Accept two ints and find the sum then display

            //Accept two ints
            int fno;
            int sno;
            int sum;
            Console.WriteLine("Enter the first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the second number: ");
            sno = int.Parse(Console.ReadLine());

            //Find the sum
            //sum = fno + sno;
            sum = Calculator.FindSum(fno,sno);

            //Display the result
            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
        }
    }
    /*class Calculator
    {
        public static int FindSum(int fno, int sno)//SRP Buiseness Logic
        {
            return fno + sno;
        }
    }*/
}
