using Fihrist.Models;
using Microsoft.AspNetCore.Mvc;
using System.Xml;

namespace Fihrist.Controllers
{
    public class PersonController : Controller
    {
        public Fihrist2Context Context { get; set; }

        public PersonController()
        {
            Context = new Fihrist2Context();
        }


        public IActionResult Index()
        {
            var liste = Context.People.ToList();
            return View(liste);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromForm] Person p)
        {

            if (ModelState.IsValid)
            {
                Context.People.Add(p);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(p);
        }


        public IActionResult Edit(int id)
        {
            var p = Context.People.FirstOrDefault(x => x.Id == id);
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] Person p)
        {
            if (ModelState.IsValid)
            {
                Context.People.Update(p);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(p);
        }

        public IActionResult Delete(int id)
        {
            var person = Context.People.FirstOrDefault(p => p.Id == id);
            return View(person);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed([FromForm] int id)
        {
            try
            {
                var person = Context.People.FirstOrDefault(p => p.Id == id);
                Context.People.Remove(person);
                Context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch 
            {
                return RedirectToAction("Delete", new { id = id });
            }
        }

    }
}
