using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator.BusinessLayer
{
    public class Calculator //Business logic code
    {
        public static int FindSum(int fno, int sno)//SRP Buiseness Logic
        {
            return fno + sno;
        }
    }
}
