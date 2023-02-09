using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q22
    {
        public static void Main()
        {
            Console.WriteLine("Enter a string : ");
            string s = Console.ReadLine();
            char[] carr = s.ToCharArray();
            bool flag = false;
            for(int i = 0; i < carr.Length / 2 + 1; i++)
            {
                if (carr[i] != carr[carr.Length - i - 1])
                {
                    flag = true;
                    break;
                }
            }
            if(flag)
            {
                Console.WriteLine("The string is not palindrome");
            }
            else
            {
                Console.WriteLine("The string is a palindrome");
            }
        }
    }
}
