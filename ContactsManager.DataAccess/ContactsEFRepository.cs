using ContactsManager.DataAccess.EFDbAccess;
using ContactsManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ContactsManager.DataAccess
{
    public class ContactsEFRepository : IContactsRepository
    {
        private ContactsDBContext db = new ContactsDBContext();
        public void Delete(int id)
        {
            db.Contacts.Remove(db.Contacts.Find(id));
            db.SaveChanges();
        }

        public void Edit(int id, Entities.Contact contact)
        {
            db.Entry(contact).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }

        public List<Entities.Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public Entities.Contact GetContact(int id)
        {
            return db.Contacts.Find(id);
        }

        public List<Entities.Contact> GetContactsByLocation(string location)
        {
            return (from  contact in db.Contacts
                    where contact.Location == location
                    select contact).ToList();
        }

        public void Save(Entities.Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
        }
    }
}
