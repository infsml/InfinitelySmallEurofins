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
                Console.WriteLine(i*i+", ");
            }
            //1, -2, 3, -4, 5, -6
            int j = 1;
            for(int i=1; i<=n; i++)
            {
                Console.WriteLine(j*i+", ");
                j = -j;
            }
            //1, 4, 27, 256, 3125 ...
            int k;
            for (int i=1; i <= n; i++)
            {
                j = 1;
                for (int k = 0; k < i; k++) j *= i;
                Console.WriteLine(j+", ");
            }
            // TODO 1, 4, 7, 12, 23, 42, 77 ..
            // 1, 4, 9, 25, 36, 49, 81, 100, ..
            for(int i=0; i<=n; i++)
            {
                if(i%4!=0)Console.WriteLine(i*i+", ");
            }
            // 1, 5, 13, 29, 49, 77, … 
            j = 4;
            k = 1;
            for(int i = 0; i < n; i++)
            {
                Console.WriteLine(k+", ");
                k += j;
                j += 4;
            }
        }
    }
}
