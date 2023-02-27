using System.IO;

namespace SimpleCalcUnitDataAccess
{
    public class CalculatorRepo : ICalculatorRepo
    {
        public bool Save(string data)
        {
            // logic to save data
            File.WriteAllText("kima/result.txt", data);
            return true;
        }
    }
}