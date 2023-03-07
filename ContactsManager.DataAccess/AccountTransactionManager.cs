using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess
{
    public class AccountTransactionManager
    {
        public bool transferFunds(int fromAccount, int toAccount, int amount)
        {
            IDbConnection conn = GetConnection();

            IDbCommand cmd1 = conn.CreateCommand();
            cmd1.CommandText = "update accounts set balance = balance - @amount where accno = @accno";
            AddParameter("@amount", amount, cmd1);
            AddParameter("@accno", fromAccount, cmd1);

            IDbCommand cmd2 = conn.CreateCommand();
            cmd2.CommandText = "update accounts set balance = balance + @amount where accno = @accno";
            AddParameter("@amount", amount, cmd2);
            AddParameter("@accno", toAccount, cmd2);
            
            conn.Open();
            IDbTransaction transaction = conn.BeginTransaction();
            cmd1.Transaction = transaction;
            cmd2.Transaction = transaction;

            try
            {
                cmd1.ExecuteNonQuery();
                throw new Exception("Server error");
                cmd2.ExecuteNonQuery();
                transaction.Commit();
            }catch (Exception ex)
            {
                transaction.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return true;
        }
        private void AddParameter<T>(string name, T value, IDbCommand command)
        {
            IDbDataParameter p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            command.Parameters.Add(p);
        }

        private static IDbConnection GetConnection()
        {
            //IDbConnection connection = new SqlConnection();
            string provider = ConfigurationManager.ConnectionStrings["appconfig"].ProviderName;
            DbProviderFactory dbProviderFactory = DbProviderFactories.GetFactory(provider);
            IDbConnection connection = dbProviderFactory.CreateConnection();
            string connString = ConfigurationManager.ConnectionStrings["appconfig"].ConnectionString;
            connection.ConnectionString = connString;
            return connection;
        }
    }
}
