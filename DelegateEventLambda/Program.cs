using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateEventLambda
{
    public delegate int GrettingDelegate(string param);
    internal class Program
    {
        static void Main(string[] args)
        {
            Greeting("hehe"); // Direct method invocation; 
            GrettingDelegate gretting = new GrettingDelegate(Greeting);
            //subscription
            gretting += new GrettingDelegate(NotGreeting);
            gretting += Greeting;
            gretting += Greeting;
            gretting += NotGreeting;
            gretting -= Greeting;
            Console.WriteLine(gretting("zxcvbnmasdfg"));
            Console.WriteLine(gretting.Invoke("qwertyiop"));
        }
        static int Greeting(string text)
        {
            Console.WriteLine($"Greeting : {text}");
            return text.Length;
        }
        static int NotGreeting(string text)
        {
            text = "Not " + text;
            Console.WriteLine($"Greeting : {text}");
            return text.Length;
        }
    }
}
