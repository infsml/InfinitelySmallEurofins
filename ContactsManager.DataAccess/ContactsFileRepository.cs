using ContactsManager.DataAccess.Entities;
using ContactsManager.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess
{
    public class ContactsFileRepository : IContactsRepository
    {
        SortedDictionary<int, Contact> contacts;
        const string fileName = "contacts.bin";
        public ContactsFileRepository() {
            if (File.Exists("contacts.bin"))
            {
                StreamReader streamReader = new StreamReader(fileName);
                BinaryFormatter formatter = new BinaryFormatter();
                contacts = (SortedDictionary<int, Contact>)formatter.Deserialize(streamReader.BaseStream);
                streamReader.Close();
            }
            else
            {
                contacts = new SortedDictionary<int, Contact>();
            }

        }
        public void Delete(int id)
        {
            if (!contacts.ContainsKey(id)) throw new ContactNotFoundException();
            Contact contact= contacts[id];
            contacts.Remove(id);
            try
            {
                UpdateFile();
            }catch(Exception ex)
            {
                contacts[id]= contact;
                throw new PersistenceException(ex);
            }
        }

        public void Edit(int id, Contact contact)
        {
            if (!contacts.ContainsKey(id)) throw new ContactNotFoundException();
            Contact contact1= contacts[id];
            contacts[id] = contact;
            try
            {
                UpdateFile();
            }catch(Exception ex)
            {
                contacts[id]= contact1;
                throw new PersistenceException(ex);
            }
        }

        public List<Contact> GetAll()
        {
            return contacts.Values.ToList();
        }

        public Contact GetContact(int id)
        {
            if (!contacts.ContainsKey(id)) throw new ContactNotFoundException();
            return contacts[id];
        }

        public List<Contact> GetContactsByLocation(string location)
        {
            List<Contact> list = new List<Contact>();
            foreach(Contact contact in contacts.Values)
            {
                if (contact.Location.Equals(location))
                {
                    list.Add(contact);
                }
            }
            return list;
        }

        public void Save(Contact contact)
        {
            if (contacts.ContainsKey(contact.ContactId))
                throw new ContactAlreadyExistsException();
            contacts[contact.ContactId] = contact;
            try
            {
                UpdateFile();
            }catch(Exception ex)
            {
                contacts.Remove(contact.ContactId);
                throw new PersistenceException(ex);
            }
        }
        private void UpdateFile()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(fileName);
                formatter.Serialize(writer.BaseStream, contacts);
            }
            finally
            {
               if(writer!=null)writer.Close();
            }
        }
    }
}
