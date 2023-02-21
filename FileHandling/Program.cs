using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FileHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("     ,'\"\".\r\n     )  ,|\r\n    /  /,'-.\r\n   /  //  /.`.\r\n ,'  //  /  `.`.\r\n(    )--.`.   //|\r\n|`--'|   `.`.// |\r\n `--'      `./  /\r\n   |         | /\r\n   |_________|/  -shimrod\r\nArt by Joan Stark");
        }

        private static void DispFiles()
        {
            string[] files = Directory.GetFiles("C:\\");
            files = Directory.GetDirectories(@"C:\");
            foreach (string i in files)
            {
                Console.WriteLine(i);
            }
        }

        private static void GetAllDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo i in drives)
            {
                Console.WriteLine(i);
            }
        }

        static void ReadContactBin()
        {
            var bin = new BinaryFormatter();
            Stream stream = File.OpenRead(@"contacts.txt"); // @"C:\cont\conta.txt"
            Contact contact = (Contact)bin.Deserialize(stream);
            Console.WriteLine(contact.Name);
        }
        static void SaveContactBin()
        {
            Contact c = new Contact() { ID = 100, Name = "N1", EmailID = "N1@j.co", PhoneNumber = "12345678", Address = "asdfghjk" };
            // text format - structured data
            string csvData = $"{c.ID},{c.Name},{c.Address},{c.EmailID},{c.PhoneNumber}";
            BinaryFormatter bf = new BinaryFormatter();
            StreamWriter sw = new StreamWriter("contacts.txt");
            bf.Serialize(sw.BaseStream, c);
            sw.Close();
        }
        static void ReadContact()
        {
            StreamReader reader = new StreamReader("somefile.txt");
            List<Contact> contacts = new List<Contact>();
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] data = line.Split(',');
                Contact contact = new Contact()
                {
                    ID = int.Parse(data[0]),
                    Name = data[1],
                    Address = data[2],
                    EmailID = data[3],
                    PhoneNumber = data[4]
                };
                contacts.Add(contact);
            }
            reader.Close();
            foreach (Contact contact in contacts)
            {
                //Console.WriteLine(contact.ID);
                Console.WriteLine(contact.Name);
                //Console.WriteLine(contact.Address);
                Console.WriteLine(contact.EmailID);
                Console.WriteLine(contact.PhoneNumber);

            }
        }
        static void SaveContact()
        {
            Contact c = new Contact() { ID = 100, Name = "N1", EmailID = "N1@j.co", PhoneNumber = "12345678", Address = "asdfghjk" };
            // text format - structured data
            string csvData = $"{c.ID},{c.Name},{c.Address},{c.EmailID},{c.PhoneNumber}";
            Save(csvData, false);
            Save(csvData, true);
            Save(csvData, true);
        }
        static void ReadLines()
        {
            StreamReader sr = new StreamReader("someFile.txt");
            while (!sr.EndOfStream)
            {
                string allLines = sr.ReadLine();
                Console.WriteLine(allLines);
            }
            sr.Close();
        }
        static void Read()
        {
            StreamReader sr = new StreamReader("someFile.txt");
            string allLines = sr.ReadToEnd();
            Console.WriteLine(allLines);
            sr.Close();
        }
        static void Save(string inp,bool overrite = false)
        {
            string someData = "Some data\nqwertyuiop";
            System.IO.StreamWriter sw = new System.IO.StreamWriter("somefile.txt",overrite);
            try
            {
                sw.WriteLine(inp);
                Console.WriteLine("Written");
            }
            finally
            {
                sw.Close();

            }
        }
        [Serializable]
        public class Contact
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }
            public string EmailID { get; set; }
            public string PhoneNumber { get; set; }
        }
    }
}
