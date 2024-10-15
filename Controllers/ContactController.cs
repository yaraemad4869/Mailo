using Microsoft.AspNetCore.Mvc;

namespace Mailo.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
