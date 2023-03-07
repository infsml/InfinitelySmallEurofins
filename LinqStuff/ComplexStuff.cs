using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace LinqStuff
{
    public class ComplexStuff
    {
        static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("book.xml");

            var stuff = from book in doc.Descendants("book")
                        where book.Element("genre").Value == "Fantasy"
                        select new
                        {
                            title = book.Element("title").Value,
                            author = book.Element("author").Value,
                            id = book.Attribute("id").Value,
                        };

            XElement xElement = new XElement("books",
                from book in doc.Descendants("book")
                where book.Element("genre").Value == "Fantasy"
                select new XElement("book",
                    new XElement("title", book.Element("title").Value),
                    new XElement("author", book.Element("author").Value),
                    new XElement("id", book.Attribute("id").Value)
                ));
            xElement.Save("samp.xml");
        }
    }
}
