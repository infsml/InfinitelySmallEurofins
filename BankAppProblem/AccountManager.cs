using System;
using System.Collections.Generic;
using System.Runtime.Hosting;

namespace BankAppProblem
{
    class AccountManager : IAccountManager
    {
        Dictionary<int,IAccount> Accounts = new Dictionary<int,IAccount>();
        int NAccouts= 0;

        public void CloseAccount(int accountNo, int pin)
        {
            if (!Accounts.ContainsKey(accountNo)) throw new AccountNotFoundException();
            Accounts[accountNo].Close(pin);
        }

        public int CreateAccount(string Name, int pin)
        {
            Account account = new Account(NAccouts,Name,pin);
            Accounts[NAccouts] = account;
            account.Open();
            return NAccouts++;
        }

        public void Deposit(int accountNo, double amount)
        {
            if (!Accounts.ContainsKey(accountNo)) throw new AccountNotFoundException();
            Accounts[accountNo].Deposit(amount);
        }

        public void Transfer(int accountNo, double amount, int pin, int recieverAccountNo)
        {
            if (!Accounts.ContainsKey(accountNo)) throw new AccountNotFoundException();
            if (!Accounts.ContainsKey(recieverAccountNo)) throw new AccountNotFoundException();
            Accounts[accountNo].Transfer(Accounts[recieverAccountNo], amount, pin);
        }

        public void Withdraw(int accountNo, double amount, int pin)
        {
            if (!Accounts.ContainsKey(accountNo)) throw new AccountNotFoundException();
            Accounts[accountNo].Withdraw(amount, pin);
        }
    }
    interface IAccountManager
    {
        int CreateAccount(string Name, int pin);
        void CloseAccount(int accountNo, int pin);
        void Deposit(int accountNo, double amount);
        void Withdraw(int accountNo, double amount, int pin);
        void Transfer(int accountNo, double amount, int pin, int recieverAccountNo);
    }

    
}
