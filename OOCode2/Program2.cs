using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2
{
    class Program2
    {
        public static void Main()
        {

            Company company = new Company();
            Customer customer = new Customer();
            Item item1 = new Item() { desc="good item", rate=10};
            Item item2 = new Item() { desc = "very good item", rate = 20 };
            Item item3 = new Item() { desc = "legendary item", rate = 50 };
            Item item4 = new Item() { desc = "god", rate = 1 };
            Item item5 = new Item() { desc = "statue", rate = 100 };

            Order order = new Order() { customer = customer };
            order.orderedItems.Add(new OrderedItem() { Item = item1, qty = 10 });
            order.orderedItems.Add(new OrderedItem { Item = item2, qty = 20 });
            customer.orders.Add(order);
            order = new Order() { customer = customer };
            order.orderedItems.Add(new OrderedItem() { Item = item3, qty = 10 });
            order.orderedItems.Add(new OrderedItem { Item = item4, qty = 23 });
            customer.orders.Add(order);
            company.customers.Add(customer);

            customer = new RegCustomer() { splDiscount = 10 };
            order = new Order() { customer = customer };
            order.orderedItems.Add(new OrderedItem() { Item=item5,qty = 10 });
            customer.orders.Add(order);

            company.customers.Add(customer);
            Console.WriteLine(company.getTotalWorthOfOrdersPlaced());
        }
    }
    class Company
    {
        public List<Item> items { get; set;}= new List<Item>();
        public List<Customer> customers{get;set;}= new List<Customer>();
        public double getTotalWorthOfOrdersPlaced()
        {
            double res = 0;
            foreach(Customer customer in customers)
            {

                //double discount = 0;
                //double bill = 0;
                //foreach(Order order in customer.orders)
                //{
                //    foreach(OrderedItem item in order.orderedItems)
                //    {
                //        bill+= item.qty * item.Item.rate;
                //    }
                //}
                //if (customer is RegCustomer)
                //{
                //    //RegCustomer regCustomer = (RegCustomer)customer;
                //    //RegCustomer regCustomer = customer as RegCustomer;
                //    //discount = (regCustomer.splDiscount * bill) / 100.0;
                //    discount = ((customer as RegCustomer).splDiscount * bill) / 100.0;
                //}
                //res += bill - discount;

                res += customer.GetOrderTotal();
            }
            return res;
        }
    }
    class Item
    {
        public string desc { get; set; }
        public double rate { get; set; }

    }
    class Customer
    {
        public List<Order> orders {get;set;}= new List<Order>();
        public virtual double GetOrderTotal()
        {
            double res = 0;
            foreach(Order order in orders)
            {
                res += order.GetOrderPrice();
            }
            return res;
        }
    }
    class RegCustomer : Customer
    {
        public double splDiscount { get;set;}
        public override double GetOrderTotal()
        {
            double res = base.GetOrderTotal();
            double discount = (res * splDiscount) / 100.0;
            return res - discount;
        }
    }
    class Order
    {
        public Customer customer { get; set; }
        public List<OrderedItem> orderedItems{get;set;}= new List<OrderedItem>();

        public double GetOrderPrice()
        {
            double res = 0;
            foreach(OrderedItem orderedItem in orderedItems)
            {
                res += orderedItem.GetOrderPrice();
            }
            return res;
        }
    }
    class OrderedItem
    {
        public int qty { get; set; }
        public Item Item { get; set; }

        public double GetOrderPrice()
        {
            return qty * Item.rate;
        }
    }
}
