using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14._05._24
{
    public class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ContactManager
    {
        private List<Contact> contacts = new List<Contact>();

        public void AddContact(Contact contact)
        {
            contacts.Add(contact);
        }

        public void RemoveContact(Contact contact)
        {
            contacts.Remove(contact);
        }

        public List<Contact> GetAllContacts()
        {
            return contacts;
        }

        public void EditContact(Contact oldContact, Contact newContact)
        {
            int index = contacts.IndexOf(oldContact);
            if (index != -1)
            {
                contacts[index] = newContact;
            }
        }
    }

    public class Controller
    {
        private ContactManager contactManager = new ContactManager();

        public void Start()
        {
            while (true)
            {
                Console.WriteLine("1. Додати контакт");
                Console.WriteLine("2. Видалити контакт");
                Console.WriteLine("3. Переглянути всі контакти");
                Console.WriteLine("4. Редагувати контакт");
                Console.WriteLine("5. Вийти");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        RemoveContact();
                        break;
                    case "3":
                        ViewAllContacts();
                        break;
                    case "4":
                        EditContact();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Невідома опція");
                        break;
                }
            }
        }

        private void AddContact()
        {
            Console.WriteLine("Введіть ім'я:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введіть прізвище:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введіть номер телефону:");
            string phoneNumber = Console.ReadLine();

            Contact contact = new Contact { FirstName = firstName, LastName = lastName, PhoneNumber = phoneNumber };
            contactManager.AddContact(contact);
        }

        private void RemoveContact()
        {
            Console.WriteLine("Введіть ім'я:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введіть прізвище:");
            string lastName = Console.ReadLine();

            Contact contact = contactManager.GetAllContacts().Find(c => c.FirstName == firstName && c.LastName == lastName);
            if (contact != null)
            {
                contactManager.RemoveContact(contact);
            }
            else
            {
                Console.WriteLine("Контакт не знайдено");
            }
        }

        private void ViewAllContacts()
        {
            foreach (Contact contact in contactManager.GetAllContacts())
            {
                Console.WriteLine($"Ім'я: {contact.FirstName}, Прізвище: {contact.LastName}, Номер телефону: {contact.PhoneNumber}");
            }
        }

        private void EditContact()
        {
            Console.WriteLine("Введіть ім'я:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введіть прізвище:");
            string lastName = Console.ReadLine();

            Contact oldContact = contactManager.GetAllContacts().Find(c => c.FirstName == firstName && c.LastName == lastName);
            if (oldContact != null)
            {
                Console.WriteLine("Введіть нове ім'я:");
                string newFirstName = Console.ReadLine();

                Console.WriteLine("Введіть нове прізвище:");
                string newLastName = Console.ReadLine();

                Console.WriteLine("Введіть новий номер телефону:");
                string newPhoneNumber = Console.ReadLine();

                Contact newContact = new Contact { FirstName = newFirstName, LastName = newLastName, PhoneNumber = newPhoneNumber };
                contactManager.EditContact(oldContact, newContact);
            }
            else
            {
                Console.WriteLine("Контакт не знайдено");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.Start();
        }
    }
}
