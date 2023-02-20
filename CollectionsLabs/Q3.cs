using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLabs
{
    internal class Q3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of product");
            int n = int.Parse(Console.ReadLine());
            Q3_Product[] arr = new Q3_Product[n];
            for(int i=0; i<n; i++)
            {
                Console.WriteLine($"Product {i}");
                Console.Write("ProductID : ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name : ");
                string name = Console.ReadLine();
                Console.Write("Description : ");
                string desc = Console.ReadLine();
                Console.Write("Price : ");
                double price = double.Parse(Console.ReadLine());
                arr[i] = new Q3_Product() { ProductID= id, Name = name,Description= desc,Price=price };
            }
            int c = 0;
            while (c != 5)
            {
                Console.WriteLine("Enter option:\n1.Display(sorted id)\n2.Sort Name\n3.Sort Price\n4.Exit");
                c = int.Parse(Console.ReadLine());
                if (c == 1) Array.Sort(arr,new Q3_Comparator_ID());
                else if (c == 2)Array.Sort(arr,new Q3_Comparator_Name());
                else if (c == 3)Array.Sort(arr, new Q3_Comparator_Price());
                else if (c == 4) { break; }
                else { Console.WriteLine("Invalid Option"); continue; }

                Console.WriteLine("------------------------------------------------------");
                Console.WriteLine("ProductID\t\tName\t\tDescription\t\tPrice");
                Console.WriteLine("------------------------------------------------------");
                foreach(Q3_Product product in arr)
                {
                    Console.WriteLine($"{product.ProductID}\t\t{product.Name}\t\t{product.Description}\t\t{product.Price}");
                }
                Console.WriteLine("------------------------------------------------------");
            }
        }
    }
    class Q3_Comparator_ID : IComparer<Q3_Product>
    {
        public int Compare(Q3_Product a, Q3_Product b)
        {
            return a.ProductID - b.ProductID;
        }
    }
    class Q3_Comparator_Name : IComparer<Q3_Product>
    {
        public int Compare(Q3_Product a, Q3_Product b)
        {
            int res = a.Name.CompareTo(b.Name);
            if(res == 0) res = a.Description.CompareTo(b.Description);
            return res;
        }
    }
    class Q3_Comparator_Price : IComparer<Q3_Product>
    {
        public int Compare(Q3_Product a, Q3_Product b)
        {
            return Math.Sign(a.Price-b.Price);
        }
    }

    class Q3_Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProductID { get; set; }
        public double Price {get; set;}
    }
}

/*
4
200
Dell
15 inch Monitor
3400.44
120
Dell 
Laptop 
45000.00
150
Microsoft 
Windows 7 
7000.50
100
Logitech 
Optical Mouse 
540.00
*/