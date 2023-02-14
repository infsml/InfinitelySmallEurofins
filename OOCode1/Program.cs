using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode1
{
    internal class Program
    {
        Customer customer1= new Customer(9999); //Has a
        static void Main(string[] args)
        {
            Console.WriteLine("Open");
            Customer customer = new Customer(); //Uses
            customer.Id = 1;
            customer.Name = "lam";
            customer.dispName();
            Console.WriteLine(customer.Name);
            Console.WriteLine("Lamo");

            //customer1.Name = "kkk";
            //Object initialization syntax
            Customer c = new Customer(700) { Name= customer.Name, Id=0 };

            Program Program = new Program();
            Program.hehe();
            Program program= new Program();
            string haha = "Haha";
            
        }
        void hehe() { }
    }
    class Customer
    {
        private int id; // field
        private string name; //field
        public string Name
        {
            get;
            set;
        }
        public void dispName()
        {
            Console.WriteLine(this.name);
        }
        private int age;
        public void SetAge(int age)
        {
            if(age<18) age = 18;
            if(age>60) age = 60;
            this.age = age;
        }
        public void SetName(string name)
        {
            this.name = name;
        }
        public int GetAge()
        {
            return this.age;
        }
        public string GetName()
        {
            return this.name;
        }
        //Property
        public int Id
        {
            get { return Id; }
            set { this.Id = value; }
        }
        public Customer(int id)
        {
            Console.WriteLine("ID " + id);
        }
        public Customer() : this(0) 
        {
            Console.WriteLine("Init boi");
        }
    }
    class Address
    {
        
    }
}
