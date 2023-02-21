using ContactsManager.DataAccess;
using ContactsManager.DataAccess.Entities;
using ContactsManager.DataAccess.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsManager.ConsoleApp
{
    public class Program
    {
        string MenuMessage = "";
        IContactsRepository repository;
        static void Main(string[] args)
        {
            IContactsRepository repository= new ContactsFileRepository();
            Program program= new Program { repository = repository };
            program.MainMenu();

        }
        void MainMenu()
        {
            while (true)
            {
                PrintHead();
                Console.WriteLine("1.New\n2.GetAll\n3.GetById\n4.GetAllByLocation\n5.Delete\n6.Edit");
                Console.WriteLine("Message : "+MenuMessage);
                Console.Write("Enter Your Choice : ");
                int choice = 0;
                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch (Exception) { }
                try
                {
                    if (choice == 1)
                    {
                        NewContact();
                    }
                    else if (choice == 2)
                    {
                        GetAll();
                    }
                    else if (choice == 3)
                    {
                        GetById();
                    }
                    else if (choice == 4)
                    {
                        GetAllByLocation();
                    }
                    else if (choice == 5)
                    {
                        Delete();
                    }
                    else if (choice == 6)
                    {
                        EditContact();
                    }
                    else
                    {
                        MenuMessage = "Invalid Choice";
                    }
                }
                catch (ContactAlreadyExistsException)
                {
                    MenuMessage = "Contact id already exists";
                }
                catch (ContactNotFoundException)
                {
                    MenuMessage = "Contact id not found.";
                }
                catch (PersistenceException)
                {
                    MenuMessage = "File could not be saved";
                }
                catch(Exception e)
                {
                    MenuMessage = e.Message;
                }
            }
        }

        void NewContact()
        {
            PrintHead();
            int id = GetID();
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Phone : ");
            string phone = Console.ReadLine();
            Console.WriteLine("Location : ");
            string location = Console.ReadLine();
            Contact contact = new Contact()
            {
                ContactId = id,
                Name = name,
                Email = email,
                Phone = phone,
                Location = location
            };
            repository.Save(contact);
            MenuMessage = "Contact added successfully";
        }
        void EditContact()
        {
            PrintHead();
            int id = GetID();
            Console.Write("Name : ");
            string name = Console.ReadLine();
            Console.Write("Email : ");
            string email = Console.ReadLine();
            Console.Write("Phone : ");
            string phone = Console.ReadLine();
            Console.WriteLine("Location : ");
            string location = Console.ReadLine();
            Contact contact = new Contact()
            {
                ContactId = id,
                Name = name,
                Email = email,
                Phone = phone,
                Location = location
            };
            repository.Edit(id,contact);
            MenuMessage = "Contact edited successfully";
        }
        void GetAll()
        {
            PrintHead();
            List<Contact> list = repository.GetAll();
            Console.WriteLine("ContactID\tName\tEmail\tPhone\tLocation");
            foreach(Contact c in list)
            {
                Console.WriteLine($"{c.ContactId}\t{c.Name}\t{c.Email}\t{c.Phone}\t{c.Location}");
            }
            Console.WriteLine("\n\nPress any key to continue..");
            Console.ReadKey();
            MenuMessage = "";
        }

        void GetById()
        {
            PrintHead();
            int id = GetID();
            Contact c;
            c = repository.GetContact(id);
            Console.WriteLine("ContactID\tName\tEmail\tPhone\tLocation");
            Console.WriteLine($"{c.ContactId}\t{c.Name}\t{c.Email}\t{c.Phone}\t{c.Location}");
            Console.WriteLine("\n\nPress any key to continue..");
            Console.ReadKey();
            MenuMessage = "";
        }
        void GetAllByLocation()
        {
            PrintHead();
            Console.Write("Location : ");
            string location = Console.ReadLine();
            List<Contact> list = repository.GetContactsByLocation(location);
            Console.WriteLine("ContactID\tName\tEmail\tPhone\tLocation");
            foreach (Contact c in list)
            {
                Console.WriteLine($"{c.ContactId}\t{c.Name}\t{c.Email}\t{c.Phone}\t{c.Location}");
            }
            Console.WriteLine("\n\nPress any key to continue..");
            Console.ReadKey();
            MenuMessage = "";
        }

        void Delete()
        {
            PrintHead();
            int id = GetID();
            try
            {
                repository.Delete(id);
                MenuMessage = "Contact deleted";
            }
            catch (ContactNotFoundException)
            {
                MenuMessage = "Contact not found";
            }
        }

        void PrintHead()
        {
            Console.Clear();
            Console.WriteLine("=====================================================================");
            Console.WriteLine(" ██████╗ ██████╗ ███╗   ██╗████████╗ █████╗  ██████╗████████╗███████╗\r\n██╔════╝██╔═══██╗████╗  ██║╚══██╔══╝██╔══██╗██╔════╝╚══██╔══╝██╔════╝\r\n██║     ██║   ██║██╔██╗ ██║   ██║   ███████║██║        ██║   ███████╗\r\n██║     ██║   ██║██║╚██╗██║   ██║   ██╔══██║██║        ██║   ╚════██║\r\n╚██████╗╚██████╔╝██║ ╚████║   ██║   ██║  ██║╚██████╗   ██║   ███████║\r\n ╚═════╝ ╚═════╝ ╚═╝  ╚═══╝   ╚═╝   ╚═╝  ╚═╝ ╚═════╝   ╚═╝   ╚══════╝\r\n                                                                     ");
            Console.WriteLine("=====================================================================");
        }

        int GetID()
        {
            int id;
            while (true)
            {
                try
                {
                    Console.Write("ContactID (number) : ");
                    id = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Number");
                }
            }
            return id;
        }
    }
}
