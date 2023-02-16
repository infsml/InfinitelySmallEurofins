using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2Big
{
    class BigProgram
    {
        public static void Main()
        {
            Company company = new Company() { Name = "Micro" };
            Employee employee = new Employee() { Name = "N1", EmpID = 1, Basic = 10, Experience = 1 };
            company.Employees.Add(employee);
            employee = new Employee() { Name = "N2", EmpID = 2, Basic = 50, Experience = 3 };
            company.Employees.Add(employee);
            employee = new Employee() { Name = "N3", EmpID = 3, Basic = 60, Experience = 5 };
            company.Employees.Add(employee);
            employee = new Employee() { Name = "N4", EmpID = 4, Basic = 70, Experience = 7 };
            company.Employees.Add(employee);

            Console.WriteLine(company.Name);
            Console.WriteLine(company.GetTotalCustomers());
            Console.WriteLine(company.GetTotalEmployees());
            Console.WriteLine(company.GetTotalSalaryPayout());

            Console.WriteLine(company.GetEmployee(3).Name);
        }
    }
    class Company
    {
        public string Name { get; set; }
        public DateTime IncorporatedDt { get; set; }

        public Branch Reg { get; set; }
        public Branch Corp { get; set; }
        public List<Branch> Branches { get; set; } = new List<Branch>();

        public List<Employee> Employees { get; set; } = new List<Employee>();
        public List<Customer> Customers { get; set; } = new List<Customer>();

        public Employee GetEmployee(int EmpID)
        {
            foreach(Employee emp in Employees)
            {
                if(emp.EmpID==EmpID) return emp;
            }
            return null;
        }
        public double GetTotalSalaryPayout()
        {
            double total = 0;
            foreach (Employee emp in Employees) total += emp.GetSalary();
            return total;
        }
        public int GetTotalCustomers()
        {
            return Customers.Count;
        }
        public int GetTotalEmployees()
        {
            return Employees.Count;
        }
    }
    class Branch
    {

    }
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
    }
    class Employee : Person
    {
        public int EmpID { get; set; }
        public double Basic { get; set; }
        public double Experience { get; set; }
        public double GetSalary()
        {
            return SalaryCalculator.CalculateSalary(Experience, Basic);
        }
    }
    class Customer : Person
    {
        public int CustomerID { get; set; }
        public string Email { get; set; }
    }
    class SalaryCalculator
    {
        public static double CalculateSalary(double Experience, double Basic)
        {
            double allowancePercentage;
            if (Experience <= 2) allowancePercentage = 30;
            else if (Experience <= 4) allowancePercentage = 40;
            else if (Experience <= 6) allowancePercentage = 50;
            else allowancePercentage = 65;

            double allowance = (Basic * allowancePercentage)/100.0;
            return Basic + allowance;
        }
    }
}
