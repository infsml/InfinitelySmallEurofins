using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1Programs
{
    internal class Q7
    {
        static void Main()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter empid");
            string empid = Console.ReadLine();
            Console.WriteLine("Enter basic");
            int basic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter special_allowances");
            int special_allowances = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter bonus percentage");
            int bonus_percentage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter tax saving investments");
            int tax_save_investments = Convert.ToInt32(Console.ReadLine());
            int gross_monthly = basic + special_allowances;
            int gross_annual = gross_monthly * 12;
            gross_annual = (gross_annual * (100 + bonus_percentage)) / 100;

        }
    }
}
