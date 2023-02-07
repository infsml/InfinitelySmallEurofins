using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q11
    {
        static void Main()
        {
            string[] words = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
            Console.WriteLine("Enter a number ");
            int number = Convert.ToInt32(Console.ReadLine());
            string numWords = "";
            for(int i = number; i > 0; i /= 10)
            {
                numWords = words[i % 10]+" " + numWords;
            }
            Console.WriteLine(numWords);
        }
    }
}
