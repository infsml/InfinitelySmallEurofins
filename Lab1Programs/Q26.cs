using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q26
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number of elements : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements : ");
            int[] a = new int[n];
            for(int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine()) ;
            }
            Console.WriteLine("Enter the number to search for : ");
            int h = int.Parse(Console.ReadLine());
            for(int i = 0; i < n; i++)
            {
                if (a[i] == h)
                {
                    Console.WriteLine($"{h} found at index {i}");
                }
            }
        }
    }
}
