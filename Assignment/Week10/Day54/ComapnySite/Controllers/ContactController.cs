using Microsoft.AspNetCore.Mvc;

namespace ComapnySite.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
