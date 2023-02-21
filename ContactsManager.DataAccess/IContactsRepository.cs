﻿using ContactsManager.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.DataAccess
{
    public interface IContactsRepository
    {
        void Save(Contact contact);
        void Delete(int id);
        void Edit(int id,Contact contact);
        Contact GetContact(int id);
        List<Contact> GetAll();
        List<Contact> GetContactsByLocation(string location);
        
    }
}
