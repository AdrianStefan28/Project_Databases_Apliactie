using Microsoft.AspNetCore.Mvc;
using MTAApp.DataAccess.Model;
using MTAApp.Logic;
using System.Diagnostics.Contracts;

namespace MTAApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactService contactService;

        public ContactsController(ContactService contaService)
        {
            contactService = contaService;
        }

        public ActionResult Index()
        {
            var contacts = contactService.GetContacts();
            return View(contacts);
        }

        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contacts = contactService.GetContact(id);
            if (contacts == null)
            {
                return NotFound();
            }

            return View(contacts);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,FirstName,LastName,Email,Subject,Context,AssociationId")] Contact contact)
        {
            try
            {
                contactService.AddContact(contact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contact);
            }
        }

        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind("Id,FirstName,LastName,Email,Subject,Context,AssociationId")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            try
            {
                contactService.UpdateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(contact);
            }
            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = contactService.GetContact(id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                contactService.DeleteContact(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
