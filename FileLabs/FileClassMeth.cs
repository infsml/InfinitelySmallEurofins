using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLabs
{
    class FileClassMeth
    {
        static void Main(string[] args)
        {
            FileStream stream = File.Create("kimo.txt");
            char[] s = "I ma have to be that way".ToCharArray();
            byte[] buffer = new byte[1024];
            for (int i = 0; i < s.Length; i++) buffer[i] = (byte)s[i];
            stream.Write(buffer, 0, s.Length);
            stream.Close();
            Console.WriteLine("File content : "+File.ReadAllText("kimo.txt"));
            Directory.CreateDirectory("hehe");
            Directory.CreateDirectory("lamo");
            File.Copy("kimo.txt", "hehe/kimo.txt");
            Console.WriteLine("File copied");
            File.Move("hehe/kimo.txt", "lamo/kimo.txt");
            Console.WriteLine("File moved");

            File.Replace("names.txt", "kimo.txt", "kimo.bkp.txt");
            Console.WriteLine("File replaced");
        }
    }
}
