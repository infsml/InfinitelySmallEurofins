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
        public IInterseCalculator InterseCalculator { get; set; }
        public Customer customer { get; set; }
        public bool Deposit(double amount)
        {
            return false;
        }
        public double CalculateIntrest()
        {
            return InterseCalculator.CalculateIntrest(this);
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

    interface IInterseCalculator
    {
        double CalculateIntrest(Account account);

    }
    class LoanIndividualIntrestCalculator : IInterseCalculator
    {
        public double CalculateIntrest(Account account) {
            return 0;
        }
    }
    class LoanCompanyIntrestCalculator : IInterseCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class MortageIndividualIntrestCalculator : IInterseCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class MortageCompanyIntrestCalculator : IInterseCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
    class SavingsIntrestCalculator : IInterseCalculator
    {
        public double CalculateIntrest(Account account)
        {
            return 0;
        }
    }
}
