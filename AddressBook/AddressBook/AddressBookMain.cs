using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class AddressBookMain
    {
        Contact contact;
        List<Contact> contacts;
        public AddressBookMain() 
        { 
            contact = new Contact();
            contacts= new List<Contact>();
            Console.WriteLine("Enter the number of contacts you want to add:");
            int numContacts = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numContacts; i++)
            {
                Console.WriteLine($"Enter details for contact {i + 1}:");
                contact.AcceptRecord();
                contacts.Add(contact); 
                Console.WriteLine("Contact added successfully.");
            }
        }
        public AddressBookMain(List<Contact> contacts)
        {
            this.contacts = contacts;
        }

        public List<Contact> GetContacts()
        {
            return contacts;
        }
        internal static void Menu()
        {
            List<Contact> ContactsList = new List<Contact>();
            Contact Contact = new Contact();
            
            while (true)
            {
                Console.WriteLine("Choose any operation : \n1.Add contacts\n2.Display contacts\n3.Edit contact\n4.Delete contact");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        return;
                    case 1:
                        Contact.AcceptRecord();
                        ContactsList.Add(Contact);
                        break;
                    case 2:
                        AddressBookMain addressBookMain = new AddressBookMain(ContactsList);
                        List<Contact> currentContacts = addressBookMain.GetContacts();
                        if (currentContacts.Count != 0)
                        {
                            foreach (Contact c in currentContacts)
                            {
                                c.DisplayRecord();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No contacts to display");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter name of contact to edit : ");
                        string name = Console.ReadLine();
                        if (ContactsList.Count != 0)
                        {
                            foreach (Contact c in ContactsList)
                            {
                                if (c.FirstName == name)
                                {
                                    c.AcceptRecord();
                                }
                                else
                                {
                                    Console.WriteLine("Name not found");
                                }
                            }
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter name of contact to delete");
                        string name1 = Console.ReadLine();
                        if (ContactsList.Count != 0)
                        {
                            foreach (Contact c in ContactsList)
                            {
                                if (c.FirstName == name1)
                                {
                                    ContactsList.Remove(c);
                                }
                            }
                        }
                        break;
                    default:
                        Console.WriteLine("Enter valid choice");
                        return;
                }
            }
            static void Main(string[] args)
            {
                Menu();
            }
        }
    }
}
