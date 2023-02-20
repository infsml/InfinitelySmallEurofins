using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 5, 7, 2, 1, 6, 9, 8, 1, 3, 5 };
            Array.Sort(numbers);
            Array.Reverse(numbers);
            foreach(int i in numbers) { Console.WriteLine(i); }

            Item[] items =
            {
                new Item{Cost=1},
                new Item{Cost=3},
                new Item{Cost=2},
            };
            Array.Sort<Item>(items,new CostComparer());
            foreach(var item in items) { Console.WriteLine(item.Cost);}
        }
    }
    class CostComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return x.Cost - y.Cost;
        }
    }
    class Item : IComparable<Item>
    {
        public int Cost { get; set; }

        public int CompareTo(Item other)
        {
            return Cost - other.Cost;
        }
    }
}
