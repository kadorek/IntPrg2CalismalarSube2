using Microsoft.AspNetCore.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class DenemeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserDetail()
        {
            Person p = new Person
            {
                BirthDate = DateTime.Now,
                ID = 10,
                Lastname = "YILMAZ",
                Name = "Hakkı"
            };

            return View(p);
        }


        public IActionResult YeniAction()
        {
            Person p = new Person
            {
                BirthDate = DateTime.Now,
                ID = 11,
                Lastname = "TÜRK",
                Name = "Ahmet"
            };
            return View("UserDetail", p);
        }

        public IActionResult Farkli()
        {
            return View("../Home/Index");
        }

        public IActionResult Test1()
        {
            Car c1 = new Car { Brand = "seat", Name = "leon", Id = 1 };
            ViewData["araba"] = c1;
            return View();
        }
        public IActionResult Test2() { return View(); }


    }
}
