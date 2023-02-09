using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q12
    {
        static void Main()
        {
            Console.WriteLine("Enter a number ");
            int n = Convert.ToInt32(Console.ReadLine());
            //4,16,36,64...
            for(int i=2; i<=2*n; i+=2) { 
                Console.Write(i*i+", ");
            }
            Console.WriteLine("\b\b   \n");
            //1, -2, 3, -4, 5, -6
            int j = 1;
            for(int i=1; i<=n; i++)
            {
                Console.Write(j*i+", ");
                j = -j;
            }
            Console.WriteLine("\b\b   \n");
            //1, 4, 27, 256, 3125 ...
            int k;
            for (int i=1; i <= n; i++)
            {
                j = 1;
                for (k = 0; k < i; k++) j *= i;
                Console.Write(j+", ");
            }
            Console.WriteLine("\b\b   \n");
            // TODO 1, 4, 7, 12, 23, 42, 77 ..
            int h = 1;k = 4;j = 7;
            for(int i=0; i<=n; i++)
            {
                Console.Write(h+", ");
                int r = h + k + j;
                h = k;k = j;j=r;
            }
            Console.WriteLine("\b\b   \n");
            // 1, 4, 9, 25, 36, 49, 81, 100, ..
            for (int i=0; i<=n; i++)
            {
                if(i%4!=0)Console.Write(i*i+", ");
            }
            Console.WriteLine("\b\b   \n");
            // 1, 5, 13, 29, 49, 77, … 
            j = 4;
            k = 1;
            int cnt = 1;
            for(int i = 0; i < n; i++)
            {
                if (cnt != 0)
                {
                    Console.Write(k + ", ");
                    k += j;
                }
                j += 4;
                cnt = (cnt + 1) % 3;
            }
            Console.WriteLine("\b\b   \n");

        }
    }
}
