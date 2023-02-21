using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace DelegateEventLambda
{
    delegate bool DoUWant(Process process);
    class DelegateStuff
    {
        static void Main(string[] args)
        {
            //ProcessManager.ShowProcesses(new DoUWant(Client1));
            //ProcessManager.ShowProcesses(new DoUWant(Client2));
            //ProcessManager.ShowProcesses(Client2);

            //Anonymous delegate
            ProcessManager.ShowProcesses(delegate(Process p) {
                return true;
            });

            //Lambda
            //Lambda Statements
            ProcessManager.ShowProcesses((p) => { return true; });
            //Lambda Expressions
            //Remove all language dependent symbols 
            ProcessManager.ShowProcesses((p) => true);
            ProcessManager.ShowProcesses(_ => true);

        }
        static bool Client1(Process process)
        {
            return true;
        }
        static bool Client2(Process process)
        {
            return process.ProcessName.StartsWith("S");
        }
    }
    class ProcessManager
    {
        public static void ShowProcesses(DoUWant doUWant)
        {
            Process[] p = Process.GetProcesses();
            foreach(Process process in p)
            {
                if(doUWant(process))
                Console.WriteLine(process.ProcessName);
            }
        }
    }
    
}
