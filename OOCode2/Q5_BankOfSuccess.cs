using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2_Q5
{
    class Q5_BankOfSuccess
    {
    }
    interface IDepositable
    {
        bool Deposit(double amount);
    }
    abstract class Account : IDepositable
    {
        public string AccountNumber { get; set; }
        public int Balance { get; set; }
        public int IntrestRate { get; set; }
        public int MonthsHeld { get; set; }
        public IIntrestCalculator IntrestCalculator { get; set; }
        public Customer customer { get; set; }
        public bool Deposit(double amount)
        {
            return false;
        }
        public double CalculateIntrest()
        {
            return IntrestCalculator.CalculateIntrest(this);
        }
    }
    class Bank
    {
        public List<Account> accounts { get; set; }
    }
    interface Withdrawable
    {
        bool Withdraw(double amount);
    }
    class Savings : Account
    {

    }
    class Loan : Account { }
    class Mortage : Account { }

    abstract class Customer
    {

    }
    class Individual : Customer { }
    class Company : Customer { }

    interface IIntrestCalculator
    {
        double CalculateIntrest(Account account);

    }
    class LoanIndividualIntrestCalculator : IIntrestCalculator
    {
        public double CalculateIntrest(Account account) {
            return 0;
        }
    }
    class LoanCompanyIntrestCalculator : IIntrestCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class MortageIndividualIntrestCalculator : IIntrestCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class MortageCompanyIntrestCalculator : IIntrestCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class SavingsIntrestCalculator : IIntrestCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
}
