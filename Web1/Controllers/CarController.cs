using Microsoft.AspNetCore.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class CarController : Controller
    {
        List<Car> Cars { get; set; }

        public CarController()
        {
            Cars = new List<Car>() {
                new Car(){Id=10,Brand="Audi",Name="Q8" },
                new Car(){Id=15,Brand="Ford",Name="Mokka" },
                new Car(){Id=100,Brand="BMW",Name="M3" }
            };
        }

        public IActionResult Index()
        {
            return View(Cars);
        }

        public IActionResult Detail(int id)
        {
            var car = Cars.FirstOrDefault(c => c.Id == id);
            return View(car);
        }

    }
}
