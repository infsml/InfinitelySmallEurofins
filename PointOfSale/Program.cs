using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSale
{
    class Program
    {
        static void Main(string[] args)
        {
            new BillingSystem().GenerateBill();
        }
    }
    public class BillingSystem
    {
        ITaxCalc taxCalc = null;
        public void GenerateBill()
        {
            //scan
            double amount = 6500.90;
            //discount
            double discount = 125.00;
            //CalculatorFactory.GetInstance().CreateTaxCalc().calcTax();
            CalculatorFactory.Instance.CreateTaxCalc().calcTax();
        }
    }

    public interface ITaxCalc
    {
        void calcTax();
    }
    class KATaxCalc : ITaxCalc
    {
        public void calcTax()
        {
            Console.WriteLine("KA tax calculated");
        }
    }
    class TNTaxCalc : ITaxCalc
    {
        public void calcTax()
        {
            Console.WriteLine("TN tax calculated");
        }
    }

    public class CalculatorFactory
    {
        private CalculatorFactory() { }
        public static readonly CalculatorFactory Instance = new CalculatorFactory();
        //private static CalculatorFactory instance = new CalculatorFactory();
        //public static CalculatorFactory GetInstance()
        //{
        //    return instance;
        //}
        public ITaxCalc CreateTaxCalc()
        {
            // read the config file and create a ITaxCalc
            string calcClassName = ConfigurationManager.AppSettings["TAX_CALC"];

            Type theCalculator = Type.GetType(calcClassName);
            //RTTI - Run Time Type Identification
            //Reflection
            ITaxCalc taxCalc = (ITaxCalc)Activator.CreateInstance(theCalculator);

            return taxCalc;
        }
    }
    class USTaxCalc : ITaxCalc
    {
        public void calcTax()
        {
            new USTaxStuff().taxCalc();
        }
    }

    //DLL
    class USTaxStuff
    {
        public void taxCalc()
        {
            Console.WriteLine("US tax stuff..");
        }
    }
}
