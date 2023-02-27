using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running sequentially");
            Stopwatch stopwatch = Stopwatch.StartNew();
            /*M1();
            M2();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);*/

            /*ThreadStart ts = new ThreadStart(M1);
            Thread t1 = new Thread(ts);
            t1.Start();
            Thread t2 = new Thread(M2);
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);*/

            //Task ts1 = new Task(M1);
            //ts1.Start();
            //Task ts2 = new Task(M2);
            //ts2.Start();
            //ts1.Wait();
            //ts2.Wait();
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);

            //Parallel.Invoke(M1, M2);
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            //Parallel.Invoke(M11, M22);
            //Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.WriteLine(Environment.ProcessorCount);
            M3();

        }
        static void M1()
        {
            for(int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
            }
            /*for(int i=0; i < 1000;i++)
            {
                Console.WriteLine($"M1 : {i}");
            }*/
        }
        static void M2()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
            }
            /*for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine($"\t\tM2 : {i}");
            }*/

        }

        static void M11()
        {
            Parallel.For(0, 10, x => Thread.Sleep(500));
        }
        static void M22()
        {
            Parallel.For(0, 10, x => Thread.Sleep(500));
        }
        static void M3()
        {
            Parallel.For(0, 100, x => Console.WriteLine($"Thread ID : {Thread.CurrentThread.ManagedThreadId}"));
        }
    }
}
