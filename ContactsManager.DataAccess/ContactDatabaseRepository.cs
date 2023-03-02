using ContactsManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data;
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
            throw new NotImplementedException();
        }

        public void Edit(int id, Contact contact)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAll()
        {
            throw new NotImplementedException();
        }

        public Contact GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            //Step 1: connect with db
            IDbConnection connection = new SqlConnection();
            connection.ConnectionString = "Data Source=DESKTOP-AOF506V;Initial Catalog=MyContactsDB;Integrated Security=True;Pooling=False";
            connection.Open();

            //Step 2: prepare sql insert cmd and send
            string insertSql = $"insert into [Contacts] values ('{contact.Name}','{contact.Email}','{contact.Phone}','{contact.Location}')";
            IDbCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = insertSql;

            command.ExecuteNonQuery();

            //Step 3: Close the DB connection
            connection.Close();
        }
    }
}
