using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q14
    {
        public static void Main()
        {
            Console.WriteLine("Enter a number : ");
            int n = int.Parse(Console.ReadLine());
            int sm = 1;
            for(int i=1; i<=n; i++) sm*=i;
            Console.WriteLine("Factorial : " + sm);
        }
    }
}
