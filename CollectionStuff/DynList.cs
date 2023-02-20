using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionStuff
{
    class DynList
    {
        public static void Main()
        {
            /*List<int> list = new List<int>();
            for(int i=0; i < 200;i++)
            {
                list.Add(i);
                list.TrimExcess();
                Console.WriteLine($"Capacity { list.Capacity}");
            }
            Stack<int> stack = new Stack<int>();
            for(int i=0;i< 200;i++)
            {
                stack.Push(i);
                //stack.Pop();
                Console.WriteLine($"Capacity {stack.First()}");
                
            }
            Dictionary<int,int> dict = new Dictionary<int,int>();
            foreach(int i in list)
            {
                dict[i] = i;
            }*/
            //Dictionary<string,string> di= new Dictionary<string,string>();
            //Dictionary<Item1,string> mi = new Dictionary<Item1,string>();
            //Item1 item1 = new Item1();
            //mi.Add(item1, "5");
            //mi.Add(new Item1(), "6");
            //Console.WriteLine(mi[]);

            //Dictionary<int, string> Days = new Dictionary<int, string>()
            //{
            //    {1,"sunday" },
            //    {2,"monday" }
            //};
            //var k = new Dictionary<int, Dictionary<int, string>>();
            //k.Add(1, new Dictionary<int, string>());
            //k[1].Add(2,"heheheh");
            //k[1][2] = "lamo";
            //Console.WriteLine(k[1][2]);
            //Console.WriteLine(  k.ContainsKey(1));
            var k = new Dictionary<string, string> { { "am", "heh" } };
            Console.WriteLine($"Hehe {k["am"]}");
        }
    }
    class Item1
    {

    }
}
