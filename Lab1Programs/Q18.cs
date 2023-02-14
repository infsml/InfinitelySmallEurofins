using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q18
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number of items : ");
            int n = int.Parse(Console.ReadLine());
            int total = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter item code : ");
                Console.ReadLine();
                Console.WriteLine("Enter item description :");
                Console.ReadLine();
                Console.WriteLine("Enter item quantity : ");
                int qty = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter item price : ");
                int price = int.Parse(Console.ReadLine());
                total += qty * price;
            }
            Console.WriteLine("Enter payment mode (C/R)");
            char c = Console.ReadLine().ToCharArray()[0];
            if (total > 10000)
            {
                total = total * 9 / 10;
            }
            else
            {
                if(total<1000 && (c == 'R' || c == 'r')){
                    total = total * 1025 / 1000;
                }
            }
            Console.WriteLine($"Total is {total}");
        }
    }
}
