using Microsoft.AspNetCore.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var list = MockData.Students.ToList();
            return View(list);
        }
    }
}
