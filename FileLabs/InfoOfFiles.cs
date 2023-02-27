using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLabs
{
    class InfoOfFiles
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("hehe");
            Directory.CreateDirectory("lamo");
            FileInfo fin = new FileInfo("names.txt");
            Console.WriteLine("Name : "+fin.FullName);
            Console.WriteLine("Size : "+fin.Length);
            File.Copy("names.txt", "hehe/names.txt");
            Console.WriteLine("File copied");
            File.Move("hehe/names.txt", "lamo/names.txt");
            Console.WriteLine("File moved");

            StreamReader stream = fin.OpenText();
            Console.WriteLine("File contents : ");
            for (int i = 0; i < 100; i++) Console.Write((char)stream.Read());
            Console.WriteLine();
            stream.Close();

            FileStream stream2 = fin.OpenRead();
            Console.WriteLine("File contents with open read : ");
            for (int i = 0; i < 100; i++) Console.Write((char)stream2.ReadByte());
            Console.WriteLine();
            stream2.Close();

            FileStream stream3 = fin.Open(FileMode.Open);
            Console.WriteLine("File contents with open : ");
            for (int i = 0; i < 100; i++) Console.Write((char)stream3.ReadByte());
            Console.WriteLine();
            stream3.Close();
        }
    }
}
