using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q27
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number of elements : ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements : ");
            int[] a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
            }
            for(int i=0;i < n; i++)
            {
                for(int j = 1; j < n - i; j++)
                {
                    if (a[j] < a[j - 1])
                    {
                        int r = a[j];
                        a[j] = a[j - 1];
                        a[j- 1] = r;
                    }
                }
            }
            Console.WriteLine("The sorted array : ");
            for (int i = 0; i < n; i++) Console.Write(a[i] + ", ");
            Console.WriteLine("\b\b  ");
            Console.WriteLine("Enter the number to search for : ");
            int h = int.Parse(Console.ReadLine());
            int l = 0;int u = n - 1;
            bool flag = false;
            while (l<=u)
            {
                int r = l + (u - l) / 2;
                if (a[r] == h)
                {
                    Console.WriteLine($"{h} found at index {r}");
                    flag = true;
                    break;
                }
                if (a[r] < h)
                {
                    l = r + 1;
                }
                else
                {
                    u = r - 1;
                }
            }
            if (!flag) Console.WriteLine("Element not found");
        }
    }
}
