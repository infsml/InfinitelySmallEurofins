using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q25
    {
        public static void Main()
        {
            Console.WriteLine("Enter a number : ");
            int n = int.Parse(Console.ReadLine());
            int k = 1;int h = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{k * k * h} ");
                    k++; h = -h;
                }
                Console.WriteLine("");
            }
            k = 1; h = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"{h} ");
                    h *= k++;
                }
                Console.WriteLine("");
            }
            k = 1; h = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (n-i+1); j++)
                {
                    Console.Write($"  ");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"* ");
                    h *= k++;
                }
                Console.WriteLine("");
            }
            k = 1; h = 1;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < (n - i + 1); j++)
                {
                    Console.Write($"  ");
                }
                for (int j = 0; j <= i; j++)
                {
                    Console.Write($"* ");
                    h *= k++;
                }
                for (int j = 0; j < i; j++)
                {
                    Console.Write($"* ");
                    h *= k++;
                }
                Console.WriteLine("");
            }
        }
    }
}
