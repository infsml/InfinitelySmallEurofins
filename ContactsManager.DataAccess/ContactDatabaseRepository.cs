using ContactsManager.DataAccess.Entities;
using ContactsManager.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess
{
    public class ContactDatabaseRepository : IContactsRepository
    {
        public void Delete(int id)
        {
            IDbCommand command = GetCommand();
            command.CommandText = "delete from [Contacts] where [ContactID] = @id";
            command.Parameters.Add(GetParameter("@id", id, command));
            execute(command);
        }

        public void Edit(int id, Contact contact)
        {
            IDbCommand command = GetCommand();
            command.CommandText = @"update [Contacts] set
                [ContactID] = @id,
                [Name] = @name,
                [Email] = @email,
                [Phone] = @phone,
                [Location] = @loc
                where [ContactID] = @id2";
            FillCommand(contact, command);
            command.Parameters.Add(GetParameter("@id2",id, command));
            execute(command);
        }

        public List<Contact> GetAll()
        {
            IDbCommand command = GetCommand();
            //command.CommandText = "select * from [Contacts]";
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "sp_GetAllContacts";
            return executeData(command);
        }

        private static List<Contact> executeData(IDbCommand command)
        {
            IDataReader reader;
            List<Contact> result = new List<Contact>();
            using (command.Connection)
            {
                command.Connection.Open();
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Contact contact = new Contact()
                    {
                        ContactId = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Email = reader.GetString(2),
                        Phone = reader.GetString(3),
                        Location = reader.GetString(4)
                    };
                    result.Add(contact);
                }
            }
            return result;
        }

        public Contact GetContact(int id)
        {
            IDbCommand command = GetCommand();
            command.CommandText = "select * from [Contacts] where [ContactID] = @id";
            command.Parameters.Add(GetParameter("@id", id, command));
            List<Contact> contacts = executeData(command);
            if (contacts.Count == 0) throw new ContactNotFoundException();
            return contacts[0];
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            IDbCommand command = GetCommand();
            command.CommandText = "select * from [Contacts] where [Location] like @location";
            command.Parameters.Add(GetParameter("@location", location, command));
            return executeData(command);
        }
        
        private IDbDataParameter GetParameter<T>(string name, T value,IDbCommand command)
        {
            IDbDataParameter p = command.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }
        public void Save(Contact contact)
        {
            //Step 1: connect with db
            //IDbConnection connection = GetConnection();

            //Step 2: prepare sql insert cmd and send
            //string insertSql = $"insert into [Contacts] values ('{contact.Name}','{contact.Email}','{contact.Phone}','{contact.Location}')";
            string insertSql2 = "insert into [Contacts] values (@name,@email,@phone,@loc)";
            //IDbCommand command = connection.CreateCommand();
            IDbCommand command = GetCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = insertSql2;
            FillCommand(contact, command);


            //try
            //{
            //    connection.Open();
            //    command.ExecuteNonQuery();
            //}
            ////Step 3: Close the DB connection
            //finally { connection.Close(); }

            execute(command);
        }

        private void FillCommand(Contact contact, IDbCommand command)
        {
            command.Parameters.Add(GetParameter("@name", contact.Name, command));
            command.Parameters.Add(GetParameter("@email", contact.Email, command));
            command.Parameters.Add(GetParameter("@phone", contact.Phone, command));
            command.Parameters.Add(GetParameter("@loc", contact.Location, command));
        }

        private static void execute(IDbCommand command)
        {
            using (command.Connection)
            {
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        private static IDbCommand GetCommand()
        {
            return GetConnection().CreateCommand();
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
