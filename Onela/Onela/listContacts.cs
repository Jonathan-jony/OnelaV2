using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onela
{
    public class ListContacts
    {
        private List<Contact> contacts;

        public ListContacts()
        {
            contacts = new List<Contact>();
        }
        public void addContact(Contact contact)
        {
            contacts.Add(contact);
        }
        public List<Contact> getContacts()
        {
            return contacts;
        }
    }
}
