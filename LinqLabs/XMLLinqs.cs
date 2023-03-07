using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqLabs
{
    public class XMLLinqs
    {
        static void Main(string[] args)
        {
            pq(1);
            XDocument doc = XDocument.Load("XMLFile1.xml");
            Console.WriteLine(doc);

            pq(2);
            var q2 = from d in doc.Descendants("Employee")
                     select d.Element("Name").Value;
            foreach (var d in q2) { Console.WriteLine(d); }

            pq(3);
            var q3 = from d in doc.Descendants("Employee")
                     select new { name = d.Element("Name").Value, id = d.Element("EmpId").Value };
            foreach (var d in q3) { Console.WriteLine(d.id+", "+d.name); }

            pq(4);
            var q4 = from d in doc.Descendants("Employee")
                     where d.Element("Sex").Value.Equals("Female")
                     select new { name = d.Element("Name").Value, id = d.Element("EmpId").Value };
            foreach (var d in q4) { Console.WriteLine(d.id + ", " + d.name); }

            pq(5);
            var q5 = from d in doc.Descendants("Phone")
                     where d.Attribute("Type").Value.Equals("Home")
                     select new { ph = d.Value };
            foreach (var d in q5) { Console.WriteLine(d.ph); }

            pq(6);
            var q6 = from d in doc.Descendants("Employee")
                     where d.Element("Address").Element("City").Value.Equals("Alta")
                     select d.Element("Name").Value;
            foreach (var d in q6) { Console.WriteLine(d); }

            pq(7);
            var q7 = from d in doc.Descendants("Employee")
                     orderby d.Element("Address").Element("Zip").Value
                     select d;
            foreach (var d in q7) { Console.WriteLine(d); }

            pq(8);
            var q8 = (from d in doc.Descendants("Employee")
                     select d).Take(2);
            foreach (var d in q8) { Console.WriteLine(d); }

            pq(9);
            var q9 = from d in doc.Descendants("Employee")
                     where d.Element("Address").Element("State").Value.Equals("CA")
                     select d.Element("Name").Value;
            Console.WriteLine("Employees in CA : "+q9.Count());

            pq(10);
            var q10 = from d in doc.Descendants("Employee")
                     where d.Element("Sex").Value.Equals("Female")
                     select new { name = d.Element("Name").Value, city = d.Element("Address").Element("City").Value, gender = d.Element("Sex") };
            foreach (var d in q10) { Console.WriteLine($"Name:{d.name}, City:{d.city}, Gender:{d.gender}"); }
        }
        static void pq(int i)
        {
            Console.WriteLine($"\n======================= q{i} ==========================");
        }
    }
}
