using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnowLedgeHub.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public Address Address { get; set; } = new Address();
        public string Email { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
    }
}