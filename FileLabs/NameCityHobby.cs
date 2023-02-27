using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLabs
{
    class NameCityHobby
    {
        static void Main(string[] args)
        {
            while(true)
            {
                try
                {
                    Console.WriteLine("1.Enter\n2.View All\n3.Exit");
                    int c = int.Parse(Console.ReadLine());
                    if (c == 1)
                    {
                        Console.Write("Name : ");
                        string name = Console.ReadLine();
                        Console.Write("City of Birth : ");
                        string city = Console.ReadLine();
                        Console.Write("Hobbies : ");
                        string hobbies = Console.ReadLine();

                        StreamWriter streamWriter = new StreamWriter("NameCityHobby.txt", true);
                        streamWriter.WriteLine($"{name}, {city}, {hobbies}");
                        streamWriter.Close();
                    }
                    else if (c == 2)
                    {
                        StreamReader streamReader = new StreamReader("NameCityHobby.txt");
                        Console.WriteLine("Name, City of Birth, Hobbies");
                        Console.WriteLine(streamReader.ReadToEnd());
                        streamReader.Close();
                    }
                    else if (c == 3) break;
                    else Console.WriteLine("Invalid Choice");
                }
                catch (Exception e) { Console.WriteLine(e); }
            }
        }
    }
}
