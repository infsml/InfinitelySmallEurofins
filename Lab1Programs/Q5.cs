using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q5
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter student name ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter math marks ");
            int math = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter science marks ");
            int science = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter english marks ");
            int english = Convert.ToInt32(Console.ReadLine());
            int total = math+science+english;
            Console.WriteLine("Total marks : " + total);
            int average = total / 3;
            Console.WriteLine("Average marks : " + average);

        }
    }
}
