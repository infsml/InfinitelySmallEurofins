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
            int monthly_tax_save_investments = Convert.ToInt32(Console.ReadLine());
            int gross_monthly = basic + special_allowances;
            int gross_annual = gross_monthly * 12;
            gross_annual = (gross_annual * (100 + bonus_percentage)) / 100;
            int annual_tax_save_investments = monthly_tax_save_investments* 12;
            int tax_payable = 0;

            if (gross_annual > 150000) tax_payable = (gross_annual * 30) / 100;
            else if(gross_annual > 100000) tax_payable = (gross_annual * 20) / 100;

            if(annual_tax_save_investments>100000)annual_tax_save_investments=100000;

            tax_payable = tax_payable - annual_tax_save_investments;
            if(tax_payable < 0)tax_payable= 0;
            int net_salary = gross_annual - tax_payable;
            Console.WriteLine($"Net salary = {net_salary}");
        }
    }
}
