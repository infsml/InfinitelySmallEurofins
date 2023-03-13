using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDatabaseADO
{
    public class TicketBookingService : ITicketBookingService
    {
        public void DisplayReport(string movieName)
        {
            IDbCommand cmd = GetDbCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DisplayReport";
            cmd.AddParameter("@movie_name", movieName);
            Console.WriteLine("-----------------------------------------------------------------------------------------------\n TheatreName | MovieName | NumberOfTicketsSold\r\n-----------------------------------------------------------------------------------------------");
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine($"{reader.GetString(0)}\t|{reader.GetString(1)}\t|{reader.GetInt32(2)}");
                }
            }
        }

        public List<string> GetAllMovieNamesSeenByUserInTheatre(string theatreName, string loginName)
        {
            IDbCommand cmd = GetDbCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAllMovieNamesSeenByUserInTheatre";
            cmd.AddParameter("@theatre_name", theatreName);
            cmd.AddParameter("@user_id", loginName);
            List<string> res = new List<string>();
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    res.Add(reader.GetString(0));
                }
            }
            return res;
        }

        public double GetTotalIncomeEarnedByTheatre(string theatreName)
        {
            IDbCommand cmd = GetDbCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTotalIncomeEarnedByTheatre";
            cmd.AddParameter("@theatre_name", theatreName);
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                IDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) return -1;
                return ((double)reader.GetDecimal(0));
            }
        }

        public int GetTotalNumberOfTicketsBookedByCity(string cityName)
        {
            IDbCommand cmd = GetDbCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTotalNumberOfTicketsBookedByCity";
            cmd.AddParameter("@city_name", cityName);
            using (cmd.Connection)
            {
                cmd.Connection.Open();
                IDataReader reader = cmd.ExecuteReader();
                if (!reader.Read()) return -1;
                return reader.GetInt32(0);
            }
        }

        private IDbCommand GetDbCommand()
        {
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(provider);
            IDbConnection connection = dbProviderFactory.CreateConnection();
            string connString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            connection.ConnectionString = connString;
            return connection.CreateCommand();
        }
        
    }
    static class ParameterStuff
    {
        public static void AddParameter<T>(this IDbCommand command,string name, T value)
        {
            IDbDataParameter p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            command.Parameters.Add(p);
        }
    }
}
