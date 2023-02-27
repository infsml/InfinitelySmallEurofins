using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2_Q4_MembershipApp
{
    class Q4_MembershipApp
    {
        static void Main(string[] args)
        {
            Company company= new Company();
            for(int i = 0; i < 16; i++)
            {
                Customer customer = new Customer();
                company.Customers.Add(customer);
            }
            MembershipFactory factory = MembershipFactory.GetInstance();
            for(int i=0; i < 16; i++)
            {
                RegCustomer customer = new RegCustomer();
                customer.membership = factory.CreateMembership($"Noraml{i % 4}", 741.0 + i, 56.0 + i);
                company.Customers.Add(customer);
            }
        }
    }
    class Company
    {
        public string Name { get; set; }
        public List<Customer> Customers { get; set; } = new List<Customer>();
    }
    class Customer
    {
        public string CustID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
    class MembershipFactory
    {
        Dictionary<string, Membership> pool = new Dictionary<string, Membership>();
        static MembershipFactory instance;
        private MembershipFactory() { }
        public Membership CreateMembership(string TypeOfMemberShip, double fees,double discount)
        {
            Membership membership = new Membership()
            {
                typeOfMembership= TypeOfMemberShip,
                fees= fees,
                discount= discount
            };
            return membership;
        }
        static public MembershipFactory GetInstance()
        {
            if(instance== null)instance= new MembershipFactory();
            return instance;
        }
    }
    class RegCustomer : Customer
    {
        public string dtReg { get; set; }
        public Membership membership { get; set; }
        public RegCustomer() { }
        public string GetTyoeOfMembership()
        {
            return membership.typeOfMembership;
        }
        public double GetDiscount()
        {
            return membership.discount;
        }
        public double GetFees()
        {
            return membership.fees;
        }
    }
    class Membership
    {
        public string typeOfMembership { get; set; }
        public double discount { get; set; }
        public double fees { get; set; }
        internal Membership() { }
    }
}
