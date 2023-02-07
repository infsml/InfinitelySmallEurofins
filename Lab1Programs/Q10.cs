using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q10
    {
        static void Main()
        {
            Console.WriteLine("Enter a number ");
            int number = Convert.ToInt32(Console.ReadLine());
            int reverse = 0;
            for(int i = number; i > 0; i /= 10)
            {
                reverse=reverse*10+(i%10);
            }
            Console.WriteLine("Reverse "+reverse);
        }
    }
}
