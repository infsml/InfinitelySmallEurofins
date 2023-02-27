using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStuff
{
    class MTDemo2
    {
        static void Main(string[] args)
        {
            //Thread t1 = new Thread(M1);
            //Thread t2 = new Thread(() => M2(100));
            //Thread t3 = new Thread(M3);
            //Thread t4 = new Thread(M4);
            /*Console.WriteLine("Init");
            Task tt1 = new Task(M1);
            Task tt2 = new Task(() => M2(100));
            Task<int> tt3 = new Task<int>(M3);
            Task<int> tt4 = new Task<int>(()=> { return M4(20); });
            tt4.Start();
            Console.WriteLine(tt4.Result);*/

            Task t123456 = Task.Factory.StartNew(M1);

        }
        static void M1 (){}
        static void M2 (int i){}
        static int M3 (){ return 0; }
        static int M4(int i) { return i*200; }
    }
}
