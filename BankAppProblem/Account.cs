using System;

namespace BankAppProblem
{
    class Account : IAccount
    {
        public int AccountNo { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; } = 0;
        public int PinNumber { get; set; }
        public bool isActive { get; set; } = false;
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        private bool accountClosed = false;

        public Account(int AccountNo, string Name, int PinNumber)
        {
            this.AccountNo = AccountNo;
            this.Name = Name;
            this.PinNumber = PinNumber;
        }
        public void Open()
        {
            if (isActive) throw new AccountAlreadyOpenedException();
            isActive = true;
            OpeningDate = DateTime.Now;
        }
        public void Close(int pin)
        {
            if (!isActive) throw new AccountNotOpenException();
            if (accountClosed) throw new AccountAlreadyClosedException();
            if (Balance != 0) throw new AccountBalanceNotZeroException();
            if (pin != PinNumber) throw new InvalidPinException();
            accountClosed = true;
            ClosingDate = DateTime.Now;
            isActive = false;
        }
        public void Deposit(double amount)
        {
            if (!isActive) throw new AccountNotOpenException();
            Balance+=amount;
        }
        public void Withdraw(double amount,int pin)
        {
            if (pin != PinNumber) throw new InvalidPinException();
            if (!isActive) throw new AccountNotOpenException();
            if (Balance < amount) throw new InsufficientBalanceException();
            Balance -= amount;
        }
        public void Transfer(IAccount account,double amount,int pin)
        {
            if (pin != PinNumber) throw new InvalidPinException();
            if (!isActive) throw new AccountNotOpenException();
            Withdraw(amount,pin);
            account.Deposit(amount);
        }
    }
}
