using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string someData = "Some data\nqwertyuiop";
            System.IO.StreamWriter sw = new System.IO.StreamWriter("somefile.txt",true);
            sw.WriteLine(someData);
            Console.WriteLine("Written");
            //sw.Flush();
            sw.Close();
        }
    }
}
