using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess.Exceptions
{
    public class ContactAlreadyExistsException : ApplicationException
    {
        public ContactAlreadyExistsException() :base("Contact already exists.") { }
    }
}
