using Microsoft.AspNetCore.Mvc;
using mvc_project.Context;
using mvc_project.Models;

namespace mvc_project.Controllers
{
    public class ContactController : Controller
    {
        private readonly ScheduleContext _context;

        public ContactController(ScheduleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contacts = _context.Contacts.ToList();
            return View(contacts);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        public IActionResult Edit(int id)
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return NotFound("Contact not exist");
                

            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            var existingContact = _context.Contacts.Find(contact.Id);

            existingContact.Name = contact.Name;
            existingContact.Email = contact.Email;
            existingContact.Number = contact.Number;
            existingContact.Active = contact.Active;

            _context.Contacts.Update(existingContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details (int id) 
        {
            var contact = _context.Contacts.Find(id);

            if (contact == null)
                return NotFound("Contact not exist");

            return View(contact);
        }


        public IActionResult Delete (int id)
        {
            var contact = _context.Contacts.Find(id);
        
            if (contact == null)
                return NotFound("Contact not exist");   

            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            var existingContact = _context.Contacts.Find(contact.Id);

            _context.Contacts.Remove(existingContact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
