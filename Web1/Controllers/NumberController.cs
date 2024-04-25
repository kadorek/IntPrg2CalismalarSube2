using Microsoft.AspNetCore.Mvc;

namespace Web1.Controllers
{
    public class NumberController : Controller
    {
        public IActionResult Genel()
        {

            var sayilar = new List<int>() {3,5,10 };
            var buyuk = sayilar.Max();
            var kucuk=sayilar.Min();

            ViewData["buyuk"]=buyuk;
            ViewBag.kucuk = kucuk;



            return View(sayilar);
        }
    }
}
