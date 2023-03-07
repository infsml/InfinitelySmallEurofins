using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace LinqStuff
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> num = new List<int>() { 1,2,3,4,5,6,7,8,9 };
            foreach (int i in num) { Console.Write(i+", "); }Console.WriteLine("\b\b  ");

            var e1 = from i in num where i%2 == 0 orderby i descending select i;
            var e2 = num.Where(i=>i%2 == 0);
            num.Add(10);
            foreach (int i in e1) { Console.Write(i+", "); }Console.WriteLine("\b\b  ");
            foreach (int i in e2) { Console.Write(i+", "); }Console.WriteLine("\b\b  ");

            XDocument doc = XDocument.Load("XMLFile1.xml");
            var wor = from w in doc.Descendants("word")
                      where w.Value.Length < 3
                      select w.Value;
            foreach(var k in wor) { Console.Write(k+", "); }Console.WriteLine("\b\b  ");
        }
    }
}
