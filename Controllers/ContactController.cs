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
    }
}
