using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternLabs
{
    public class Q2
    {
        static void Main(string[] args)
        {

        }
    }
    public interface ICalculator
    {
        double Calculate();
    }
    public class Calculator : ICalculator
    {
        public double Calculate()
        {
            return 100;
        }
    }
    public class CalcDecorator : ICalculator
    {
        protected ICalculator _calculator;
        public CalcDecorator(ICalculator calculator) { this._calculator = calculator; }
        public virtual double Calculate()
        {
            return _calculator.Calculate();
        }
    }
    public class DiscountDecorator : CalcDecorator
    {
        public DiscountDecorator(ICalculator calculator):base(calculator) { }
        public override double Calculate()
        {
            double base_amount = base.Calculate();
            double discount = base_amount * 0.1;
            return base_amount - discount;
        }
    }
    public class DeductionDecorator : CalcDecorator
    {
        public DeductionDecorator(ICalculator calculator) : base(calculator) { }
        public override double Calculate()
        {
            return base.Calculate() - 50.0;
        }
    }
}
