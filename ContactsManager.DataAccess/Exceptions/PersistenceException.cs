using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess.Exceptions
{
    public class PersistenceException : ApplicationException
    {
        public PersistenceException(Exception ex) : base("Could not persist data",ex) { }
    }
}
