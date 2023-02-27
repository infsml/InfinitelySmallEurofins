using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProblem
{
    class AccountAlreadyOpenedException : ApplicationException{
        public AccountAlreadyOpenedException() : base("AccountAlreadyOpened") { }
    }
    class AccountAlreadyClosedException : ApplicationException{
        public AccountAlreadyClosedException():base("AccountAlreadyClosed"){}
    }
    class AccountNotOpenException : ApplicationException { 
        public AccountNotOpenException():base("AccountNotOpen"){}
    }
    class AccountBalanceNotZeroException : ApplicationException { 
        public AccountBalanceNotZeroException():base("AccountBalanceNotZero"){}
    }
    class InsufficientBalanceException : ApplicationException { 
        public InsufficientBalanceException():base("InsufficientBalance"){}
    }
    class InvalidPinException : ApplicationException { 
        public InvalidPinException():base("InvalidPin"){}
    }
    class AccountNotFoundException : ApplicationException { 
        public AccountNotFoundException():base("AccountNotFound"){}
    }
}
