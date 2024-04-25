using Microsoft.AspNetCore.Mvc;
using Web1.Models;

namespace Web1.Controllers
{
    public class BookController : Controller
    {

        public List<Book> Books { get; set; }

        public BookController()
        {
            Books = new List<Book>() {
                new Book{Id=1,Title="Marslı",Author="Muammer Şahin" },
                new Book{Id=2,Title="Yüzüncü Ad",Author="Amin Maalouf"},
                new Book{Id=3,Title="İnsanlar ve Fareler",Author="John Steinback"},
                new Book{Id=4,Title="Kırmızı Piramit",Author="Mehmet Güülmez"},
                new Book{Id=5,Title="İnsan Ne İle Yaşar",Author="Lev Tolstoy"}
            };
        }


        public IActionResult Index()
        {
            return View(Books);
        }


        public IActionResult Detail(int id)
        {
            var b = Books.FirstOrDefault(x => x.Id == id);
            return View(b);
        }
    }
}
