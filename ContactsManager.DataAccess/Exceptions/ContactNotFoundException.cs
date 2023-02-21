using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess.Exceptions
{
    public class ContactNotFoundException : ApplicationException
    {
        public ContactNotFoundException() : base("The contact was not found") { }
    }
}
