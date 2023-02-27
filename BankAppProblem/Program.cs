using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountManager manager= new AccountManager();
            while (true)
            {
                //Console.Clear();
                Console.WriteLine("Main Menu\n1.Create Account\n2.Close Account\n3.Withdraw\n4.Deposit\n5.Transfer\n6.Exit");
                int c = 0;
                try { c = int.Parse(Console.ReadLine()); }catch(Exception) {}
                try
                {
                    if (c == 1)
                    {
                        Console.Write("Enter your name : ");
                        string name = Console.ReadLine();
                        int pin = GetNumber("Enter pin for account : ");
                        Console.WriteLine($"Account No : {manager.CreateAccount(name, pin)}");
                    }
                    else if (c == 2)
                    {
                        int accountNo = GetNumber("Enter Account No (number) : ");
                        int pin = GetNumber("Enter Pin : ");
                        manager.CloseAccount(accountNo, pin);
                    }
                    else if (c == 3)
                    {
                        int accountNo = GetNumber("Enter Account No (number) : ");
                        int pin = GetNumber("Enter Pin : ");
                        int amount = GetNumber("Enter Amount : ");
                        manager.Withdraw(accountNo, amount, pin);
                    }
                    else if (c == 4)
                    {
                        int accountNo = GetNumber("Enter Account No (number) : ");
                        int amount = GetNumber("Enter Amount : ");
                        manager.Deposit(accountNo, amount);
                    }
                    else if (c == 5)
                    {
                        int accountNo = GetNumber("Enter Your Account No (number) : ");
                        int destAccountNo = GetNumber("Enter Destination Account No (number) : ");
                        int pin = GetNumber("Enter your Pin : ");
                        int amount = GetNumber("Enter Amount : ");
                        manager.Transfer(accountNo, amount, pin, destAccountNo);
                    }
                    else if (c == 6) break;
                    else
                    {
                        Console.WriteLine("\n\nInvalid Choice");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        public static int GetNumber(string msg)
        {
            while (true)
            {
                Console.WriteLine(msg);
                try {
                    int n = int.Parse(Console.ReadLine());
                    return n;
                }catch(Exception) {
                    Console.WriteLine("Invalid number");
                }
            }
        }
    }

    
}
