using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLabs
{
    public class Q1
    {
        static void Main(string[] args)
        {
            IAccountCalculator accountCalculator = new SavingsAccountCalculator();
            Console.WriteLine(accountCalculator.CalcIntrest());
        }
    }
    public interface IAccountCalculator
    {
        double CalcIntrest();
    }
    public class SavingsAccountCalculator : IAccountCalculator
    {
        public double CalcIntrest()
        {
            return 100;
        }
    }
    public class FDAccountCalculator : IAccountCalculator
    {
        public double CalcIntrest()
        {
            return 1000;
        }
    }

}
