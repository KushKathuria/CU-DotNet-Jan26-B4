using Microsoft.AspNetCore.Mvc;

namespace TrainingApp.Controllers
{
    public class TrainingController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Courses()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
