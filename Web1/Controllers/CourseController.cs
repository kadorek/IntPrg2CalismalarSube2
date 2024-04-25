using Microsoft.AspNetCore.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var list= MockData.Courses.ToList();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var course = MockData.Courses.FirstOrDefault(x => x.Id == id);
            
            course.Students.Add(MockData.Students[2]);
            course.Students.Add(MockData.Students[4]);

            return View ("D",course);
        }
    }
}
