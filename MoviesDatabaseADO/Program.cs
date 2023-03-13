using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabaseADO
{
    public class Program
    {
        static void Main(string[] args)
        {
            TicketBookingService service = new TicketBookingService();
            Console.WriteLine($"TotalIncomeEarnedByTheatre IMax {service.GetTotalIncomeEarnedByTheatre("IMax")}");
            Console.WriteLine($"TotalNumberOfTicketsBookedByCity Bangalore {service.GetTotalNumberOfTicketsBookedByCity("Bangalore")}");
            Console.WriteLine("Movies watched by bird at IMax : ");
            foreach(string s in service.GetAllMovieNamesSeenByUserInTheatre("IMax", "bird"))
            {
                Console.WriteLine($"\t{s}");
            }
            Console.WriteLine("Report Vikram");
            service.DisplayReport("Vikram");
        }
    }
}
