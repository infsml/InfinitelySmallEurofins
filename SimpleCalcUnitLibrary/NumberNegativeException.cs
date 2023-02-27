using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalcUnitLibrary
{
    public class NumberNegativeException : ApplicationException
    {
        public NumberNegativeException() : base("The number was negative man XD") { }
    }
}
