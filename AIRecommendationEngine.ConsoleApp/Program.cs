using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AIRecommendationEngine;
using AIRecommendationEngine.Common.Entities;

namespace AIRecommendationEngine.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AIRecommendationEngine.Integrator.AIRecommendationEngine engine = new Integrator.AIRecommendationEngine();

            while (true)
            {
                Console.Write("Enter the ISBN : ");
                string ISBN = Console.ReadLine();
                Console.Write("Enter the State : ");
                string state = Console.ReadLine();
                int age = GetInt("Enter the Age : ");

                Preference preference = new Preference() {
                    ISBN = ISBN,
                    State = state,
                    Age = age
                };

                IList<Book> books = engine.Recommend(preference, 10);

                Console.WriteLine($"Found {books.Count} similar books");
                foreach (Book book in books)
                {
                    Console.WriteLine($"{book.ISBN}:{book.BookTitle}");
                }
                Console.WriteLine("\n\n");
            }
        }

        static int GetInt(string mess)
        {
            while (true)
            {
                try
                {
                    Console.Write(mess);
                    int i = int.Parse(Console.ReadLine());
                    return i;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid Age");
                }
            }
        }
    }
}
