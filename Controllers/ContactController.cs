using Microsoft.AspNetCore.Mvc;

namespace mvc_project.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
