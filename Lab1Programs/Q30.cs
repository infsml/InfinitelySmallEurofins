using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q30
    {
        public static void Main()
        {
            Console.WriteLine("Enter the number of rows : ");
            int n = int.Parse(Console.ReadLine());
            //Console.WriteLine("Enter the number of columns : ");
            int m = n; // int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the elements : ");
            int[][] a = new int[n][];
            for (int i = 0; i < n; i++)
            {
                a[i] = new int[m];
                for (int j = 0; j < m; j++)
                {
                    a[i][j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("The matrix : ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($"{a[i][j]}, ");
                }
                Console.WriteLine("\b\b  ");
            }
            bool flag = true;
            for (int i = 0; i < n && flag; i++)
            {
                for (int j = 0; j <i; j++)
                {
                    if (a[i][j] != a[j][i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            if (flag) Console.WriteLine("Symmetric matrix");
            else Console.WriteLine("Not Symmetric matrix");
        }
    }
}
