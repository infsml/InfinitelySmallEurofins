using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLabs
{
    class Kiosk
    {
        const string shopName = "Infinitely Small Shop";
        static void Main(string[] args)
        {

        }
    }
    class Computer
    {
        public int ComputerID{get;set;}
        public string computerType{get;set;}
        public int CPUSpeed{get;set;}
        public string HardDiskCapacity{get;set;}
        public string GraphicsCard{get;set;}
        public double price { get; set; }
    }
    class Desktop : Computer
    {
        public int MonitorSize { get; set; }
    }
    class Laptop : Computer
    {
        public int Weight { get; set; }
        public int BatteryDuration { get; set; }
    }
    class Person
    {
        public string Name{get;set;}
        public int Age{get;set;}
        public string Gender { get; set; }
    }
    class Customer:Person
    {
        public int CustomerID{get;set;}
        public string Address{get;set;}
    }
    class Order
    {
        public int OrderID{get;set;}
        public Computer Computer{get;set;}
        public Customer Customer{get;set;}
        public OrderStatus Status { get; set; }
    }
    enum OrderStatus
    {
        PENDING,DELIVERED
    }
    class Admin : Person
    {
        public string AdminID{get;set;}
        public string Password { get; set; }
    }
}
