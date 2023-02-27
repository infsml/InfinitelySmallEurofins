using SimpleCalcUnitDataAccess;

namespace SimpleCalcUnitLibrary
{
    public class Calculator
    {
        // find the sum of two ints
        // non negative numbers
        // even numbers
        // throws suitable exp if business rules voilated
        ICalculatorRepo repo;

        public Calculator(ICalculatorRepo repo)
        {
            this.repo = repo;
        }

        public int Sum(int x, int y)
        {
            if(x<0 || y<0) throw new NumberNegativeException();
            if(x%2==1 || y%2==1) throw new NumberOddException();
            int res = x + y;
            repo.Save($"{x}+{y}={res}");
            return res;
        }
    }
}
