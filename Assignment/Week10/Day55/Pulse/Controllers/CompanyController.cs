using Microsoft.AspNetCore.Mvc;
using Pulse.Models;
namespace Pulse.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Index()
        {
            List<Emp> emp = new List<Emp>()
            {
                new Emp{EmpID=1,EmpName="A1",Position="Manager",Salary=25000},
                new Emp{EmpID=2,EmpName="A2",Position="Accountant",Salary=36000},
                new Emp{EmpID=3,EmpName="A3",Position="Receptionist",Salary=17000},
                new Emp{EmpID=4,EmpName="A4",Position="Trainer",Salary=45000}

            };
            string announcement = "First Match Is Of SRH vs RCB";
            ViewBag.Announcement = announcement;
            ViewData["deptname"] = "IT";
            ViewData["serverStatus"] = true;
            return View();
        }
    }
}
