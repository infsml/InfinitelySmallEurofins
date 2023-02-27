namespace BankAppProblem
{
    internal interface IAccount
    {
        void Close(int pin);
        void Deposit(double amount);
        void Open();
        void Transfer(IAccount account,double amount, int pin);
        void Withdraw(double amount, int pin);
    }
}