using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;

namespace ThreadStuff
{
    class BigDataStuff
    {
        static void Main(string[] args)
        {
            BigData b = new BigData();
            //b.Fill();
            b.Fill();
            Console.WriteLine(b.Count);
        }
    }
    public class BigData
    {
        private ConcurrentStack<int> stack = new ConcurrentStack<int>();
        //private Stack<int> stack = new Stack<int>();
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Fill()
        {
            // Fill a million numbers
            /*for (int i = 0; i < 1000000; i++)
            {
                //Monitor.Enter(this);
                //lock (this)
                //{
                    stack.Push(i);
                //}
                //Monitor.Exit(this);
            }*/
            //Mutex.. Global
            //Semaphore.. Fixed number of threads
            //
            int pcount = Environment.ProcessorCount;
            ParallelOptions options = new ParallelOptions();
            HashSet<int> visited = new HashSet<int>();
            options.MaxDegreeOfParallelism = pcount/2;

            Parallel.For(0, 100, i => { lock (visited) { visited.Add(Thread.CurrentThread.ManagedThreadId); } });
            Console.WriteLine(visited.Count);

        }
        public long Count
        {
            get { return stack.Count; }
        }
    }
}
