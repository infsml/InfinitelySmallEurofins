using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLabs
{
    internal class Q2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of strings");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the strings");
            string[] arr = new string[n];
            for(int i=0;i<arr.Length; i++) { arr[i] = Console.ReadLine();}
            int c = 0;
            while (c != 5)
            {
                Console.WriteLine("Enter option:\n1.Lexiographic\n2.Lexiographic reverse\n3.Length\n4.Length Reverse\n5.Exit");
                c = int.Parse(Console.ReadLine());
                if (c == 1) Array.Sort(arr);
                else if (c == 2)
                {
                    Array.Sort(arr);
                    Array.Reverse(arr);
                }
                else if (c == 3)
                {
                    Array.Sort(arr, new LengthComparator() { reverse = false });
                }
                else if (c == 4)
                {
                    Array.Sort(arr, new LengthComparator() { reverse = true });
                }
                else if (c == 5) { break; }
                else { Console.WriteLine("Invalid Option"); continue; }
                foreach(string s in arr)
                {
                    Console.WriteLine(s);
                }
            }
        }
    }
    class LengthComparator : IComparer<string>
    {
        public bool reverse { get; set; }
        public int Compare(string x, string y)
        {
            int res = x.Length-y.Length;
            if (reverse) res = -res;
            return res;
        }
    }
}
