using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadStuff
{
    public class Tesiting
    {
        static void Main(string[] args)
        {
            string k = "hehe,lamo";
            string[] h = k.Split(',');
            string[] g = new string[3];
            for(int i=0;i< h.Length;i++)
            {
                g[i] = h[i];
            }
            Console.WriteLine(g[0]);
            Console.WriteLine(g[1]);
            Console.WriteLine(g[2]);
        }
    }
}
