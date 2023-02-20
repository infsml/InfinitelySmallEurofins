using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsLabs
{
    class Q1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string : ");
            string s = Console.ReadLine();
            Dictionary<string,int> map = new Dictionary<string,int>();
            foreach (string str in s.Split(' '))
            {
                if (map.ContainsKey(str)) map[str]++;
                else map[str] = 1;
            }
            List<Q1_freq> list = new List<Q1_freq>();
            foreach(string str in map.Keys)
            {
                list.Add(new Q1_freq() { Word= str, frequency = map[str] });
            }
            list.Sort();
            foreach(Q1_freq freq in list)
            {
                Console.Write(freq);
            }
        }
    }
    class Q1_freq : IComparable<Q1_freq> 
    {
        public string Word { get; set; }
        public int frequency { get; set; }
        public int CompareTo(Q1_freq b)
        {
            return Word.CompareTo(b.Word);
        }
        public override string ToString()
        {
            return Word + " = " + frequency+" ";
        }
    }
}
