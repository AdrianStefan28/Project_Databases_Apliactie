using MTAApp.DataAccess.Abstractions;
using MTAApp.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTAApp.Logic
{
    public class ContactService
    {
        private readonly IContactRepository contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this.contactRepository = contactRepository;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return contactRepository.GetAll();
        }

        public Contact GetContact(int id)
        {
            return contactRepository.Get(id);
        }

        public Contact AddContact(Contact contact)
        {
            return contactRepository.Add(contact);
        }
        public Contact UpdateContact(Contact contact)
        {
            return contactRepository.Update(contact);
        }

        public void DeleteContact(int id)
        {
            contactRepository.Remove(id);
        }

    }
}
