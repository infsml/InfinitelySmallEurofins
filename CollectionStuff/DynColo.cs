using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStuff
{
    class DynColo
    {
        static void Main()
        {
            DynamicIntArray numbers = new DynamicIntArray();
            Random random= new Random(0);
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            numbers.Add(random.Next(20));
            for (int i=0;i<numbers.Size;i++)
            {
                Console.WriteLine(numbers.Get(i));
            }
        }
    }

    internal class DynamicIntArray
    {
        public int Size { 
            get { return index; } 
        }
        private int[] numbers = new int[10];
        private int index = 0;
        internal void Add(int v)
        {
            if(index >= numbers.Length)
            {
                //int[] temp = new int[numbers.Length * 2];
                ///*for(int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}*/
                //Array.Copy(numbers, temp, numbers.Length);
                //numbers= temp;
                Array.Resize(ref numbers, numbers.Length*2);
            }
            numbers[index++] = v;
        }

        internal int Get(int i)
        {
            return numbers[i];
        }
    }

    internal class DynamicGenericArray<T>
    {
        public int Size
        {
            get { return index; }
        }
        private T[] numbers = new T[10];
        private int index = 0;
        internal void Add(T v)
        {
            if (index >= numbers.Length)
            {
                //int[] temp = new int[numbers.Length * 2];
                ///*for(int i = 0; i < numbers.Length; i++)
                //{
                //    temp[i] = numbers[i];
                //}*/
                //Array.Copy(numbers, temp, numbers.Length);
                //numbers= temp;
                Array.Resize(ref numbers, numbers.Length * 2);
            }
            numbers[index++] = v;
        }

        internal T Get(int i)
        {
            return numbers[i];
        }

        public void pika<chu>()
        {
            
        }
    }
}
