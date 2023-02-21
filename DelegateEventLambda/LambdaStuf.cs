using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventLambda
{
    class LambdaStuf
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1,2,3,4,5,6 };
            Func<int, bool> func = new Func<int, bool>(IsEven);
            list.Where(n => n % 2 == 0);
            Dictionary<int,string> dic = new Dictionary<int,string>();
        }
        static bool IsEven(int x)
        {
            return x % 2 == 0;
        }
    }
}
