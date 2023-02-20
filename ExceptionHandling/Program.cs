using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandling
{
    class Program // UI Logic
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter first number : ");
                    int a = int.Parse(Console.ReadLine());
                    Console.Write("Enter Second number : ");
                    int b = int.Parse(Console.ReadLine());
                    int s = Calculator.Sum(a,b);
                    Console.WriteLine($"Sum : {s}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter number ");
                }
                catch (OverflowException)
                {
                    Console.WriteLine($"Too big to handle ({int.MinValue},{int.MaxValue})");
                }
                //catch (NegativeNumberException)
                //{
                //    Console.WriteLine("Enter a positive number");
                //}
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                finally
                {

                }
            }
        }
    }
    /// <summary>
    /// A Calculator but just returns whatever u put XD;
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Returns Same stuff
        /// </summary>
        /// <param name="a">The number u want to get back</param>
        /// <param name="b">The other number</param>
        /// <returns></returns>
        /// <exception cref="NegativeNumberException"></exception>
        public static int Sum(int a,int b)
        {
            try
            {
            InputValidator.Validate(a);
            InputValidator.Validate(b);
            }catch(Exception e)
            {
                //log the exception
                LogManager.LoadConfiguration("nLog.config");
                var log = LogManager.GetCurrentClassLogger();
                log.Debug("Stf up");
                throw e;
            }
            int res = a + b;
            //Save
            try
            {
                CalculatorRepository.Save($"{a}+{b}={res}");
            }
            catch (Exception e)
            {
                //convert system exception to custom and rethrow
                UnableToSaveException exception= new UnableToSaveException();
                throw exception;
            }
            return res;
        }
    }
    public class NegativeNumberException : ApplicationException { 
        public NegativeNumberException(string message) : base(message) { }
        public NegativeNumberException():base("Neg came bai XD") { }
    }

    public class UnableToSaveException : ApplicationException
    {
        public UnableToSaveException(string message) : base(message) { }
        public UnableToSaveException(string message=null,Exception innerException=null) : base(message, innerException) { }
        public UnableToSaveException()
        {
            Console.WriteLine("My gc stuff");
        }
        public UnableToSaveException(Exception e):base("Unable to save pa XD",e) { }
    }
    class InputValidator
    {
        public static bool Validate(int a)
        {
            if (a < 0)
            {
                NegativeNumberException exception = new NegativeNumberException();
                throw exception;
            }
            return true;
        }
    }

    public class CalculatorRepository
    {
        public static void Save(string input)
        {
            File.WriteAllText("calculator.txt", input);
        }
    }
}
