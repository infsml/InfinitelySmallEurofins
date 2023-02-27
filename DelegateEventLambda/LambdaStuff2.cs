using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventLambda
{
    class LambdaStuff2
    {
        static void Main(string[] args)
        {
            Account account = new Account();
            account.notificationService += Notification.SendEmail;
            account.notificationService += Notification.SendSms;
            account.Deposit(5000);
            Console.WriteLine(account.Balance);
            account.Withdraw(1000);
            Console.WriteLine(account.Balance);
        }
        class Account
        {
            public int Balance { get; private set; }
            public event NotificationDelegate notificationService;
            public void Withdraw(int amount)
            {
                Balance -= amount;
                if(notificationService!=null)
                notificationService($"Account decreased with {amount}");
            }
            public void Deposit(int amount) {
                Balance += amount;
                if(notificationService!=null)
                notificationService($"Account increased with {amount}");
            }
        }
        delegate void NotificationDelegate(string message);
        class Notification
        {
            public static void SendEmail(string message)
            {
                Console.WriteLine("Mail : "+message);
            }
            public static void SendSms(string message)
            {
                Console.WriteLine("SMS : " + message);
            }
        }
    }
}
