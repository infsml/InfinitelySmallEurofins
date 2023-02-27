using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalcUnitLibrary
{
    public class NumberOddException : ApplicationException
    {
        public NumberOddException() : base("Number is odd") { }
    }
}
