using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisposeStuff
{
    public class Program
    {
        static void Main(string[] args)
        {
            BigData bigData = new BigData();
            //using(bigData)
            {

            }
            Console.WriteLine("Quit");
        }
    }
    class BigData : IDisposable
    {
        public BigData() {
            Console.WriteLine("Big mem alloc");
        }

        public void Dispose()
        {
            Console.WriteLine("Dealloc happende");
            GC.SuppressFinalize(this);
        }
        ~BigData()
        {
            Console.WriteLine("Destructo");
        }
    }
}
