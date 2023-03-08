using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLabs
{
    public delegate void NotificationDelegate(string message);
    public class Q3
    {

    }
    public class Loan
    {
        double intrest;
        protected NotificationDelegate Notify;
        public void Subscribe(IObserver observer)
        {
            Notify += observer.Notify;
        }
        public void UnSubscribe(IObserver observer)
        {
            Notify -= observer.Notify;
        }
    }
    public class FDA : Loan
    {
        public void ChangeIntrest()
        {
            Notify("FDA intrest changed");
        }
    }
    public class HousingLoan : Loan
    {
        public void ChangeIntrest()
        {
            Notify("HousingLoan intrest changed");
        }
    }
    public class BusinessLoan : Loan
    {
        public void ChangeIntrest()
        {
            Notify("BusinessLoan intrest changed");
        }
    }
    public interface IObserver
    {
        void Notify(string message);
    }
    public class Customer : IObserver
    {
        public void Notify(string message)
        {
            Console.WriteLine(message);
        }
    }
}
