using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q19
    {
        public static void Main()
        {
            Console.WriteLine("Enter a number : ");
            int n = int.Parse(Console.ReadLine());
            int i, j, k;
            //1, -2, 6, -15, 31, -56, … N
            j = 1;
            k = 1;
            for(i=1;i<=n;i++)
            {
                Console.Write(j * k+", ");
                k += i * i;
            }
            Console.WriteLine("\b\b  ");
            //1, 1, 2, 3, 5, 8, 13, … N
            j = 1; k = 1;
            for(i=0;i<n;i++)
            {
                Console.Write(j+", ");
                int r = j + k;
                k = j;j = r;
            }
            Console.WriteLine("\b\b  ");
            //1, -2, 4, -6, 7,-10, 10,-14… N
            j = 1;k = -2;
            for (i = 0; i < n; i++)
            {
                Console.Write((1+3*i)+", ");
                Console.Write((-2-(4*i))+", ");
            }
            //1, 5, 8, 14, 27, 49, … N
            int h = 1; k = 5; j = 8;
            for (i = 0; i <= n; i++)
            {
                Console.Write(h + ", ");
                int r = h + k + j;
                h = k; k = j; j = r;
            }
            Console.WriteLine("\b\b   \n");

        }
    }
}
