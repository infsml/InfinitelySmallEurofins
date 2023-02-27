using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLabs
{
    class NamesScores
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("names.txt");
            string[] simp = reader.ReadToEnd().ToUpper().Split(',');
            int res = 0;
            for(int i=0;i<simp.Length;i++)
            {
                char[] simpchar = simp[i].ToCharArray();
                int value = 0;
                for(int j=1;j<simpchar.Length-1;j++)
                {
                    value += simpchar[j] - 'A' + 1;
                }
                res += value;
                /*Console.Write(simp[i]+" ");
                Console.WriteLine(value);*/
            }
            Console.WriteLine(res);
        }
    }
}
