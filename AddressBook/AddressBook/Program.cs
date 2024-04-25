
// See https://aka.ms/new-console-template for more information
using AddressBook;
using System;
using System.ComponentModel.Design;
using System.Data;

internal class Program
{
    static void MenuDriven()
    {
        Dictionary<string, AddressBookMain> dictionary = new Dictionary<string, AddressBookMain>();

        while(true)
        {
            Console.WriteLine("Choose any operation : \n1.Add address book\n2.Display address book\n3.Edit address book name\n4.Delete address book");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {       
                case 0:
                    return;
                case 1:
                    Console.WriteLine("Enter address book name : ");
                   
                    string name=Console.ReadLine();
                    if (dictionary.ContainsKey(name))
                    {
                        Console.WriteLine("Name not available");
                    }
                    else
                    {
                        dictionary.Add(name,new AddressBookMain());
                    }
                    break;

                case 2:
                    Console.WriteLine("Enter address book name:");
                    string name1 = Console.ReadLine();

                    if (dictionary.ContainsKey(name1))
                    {
                        Console.WriteLine($"Address book: {name1}");
                        Console.WriteLine("Contacts:");

                        foreach (var contact in dictionary[name1].GetContacts())
                        {
                            Console.WriteLine($"Name: {contact.FirstName}, Phone: {contact.PhoneNumber} ,Lastname: {contact.LastName}, Email : {contact.Email}, Address : {contact.Address}");
                            // Display other contact details as needed
                        }
                    }
                    else
                    {
                        Console.WriteLine("Address book not found.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter address book name : ");
                    string oldname=Console.ReadLine();
                    if(dictionary.ContainsKey(oldname))
                    {
                        Console.WriteLine("Enter new name");
                        string newname=Console.ReadLine();
                        AddressBookMain addressBook = dictionary[oldname];

                        // Remove the entry with the old name
                        dictionary.Remove(oldname);

                        // Add the entry with the new name and the stored value
                        dictionary.Add(newname, addressBook);

                        Console.WriteLine("Address book name edited successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Name not found");
                    }
                    break;

                case 4:
                    Console.WriteLine("Enter name of address book to be deleted");
                    string name3=Console.ReadLine();
                    foreach(var item in dictionary)
                    {
                        if (item.Key==name3)
                        {
                            dictionary.Remove(item.Key);
                            Console.WriteLine("Record deleted successfully");
                        }
                        else
                        {
                            Console.WriteLine("Name not found");
                        }
                    }
                    break;
                case 5:
                    Console.WriteLine("Enter valid choice");
                    break;
            }
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to address book");
        MenuDriven();
    }
}