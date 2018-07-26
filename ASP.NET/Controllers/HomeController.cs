using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using ASP.NET.Models;
using ASP.NET.DAL;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET.Controllers
{
    public class HomeController : Controller
    {

        PersonContext db = new PersonContext();

        public IActionResult Index()
        {
            return View();
        }

        public String page1(string name, int num = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, numer to: {num}");
        }

        public IActionResult Hello()
        {
            return View();
        }

        public IActionResult Movie()
        {
            return View();
        }

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;


            return View();
        }

        public IActionResult Routing()
        {
            foreach (string routekey in RouteData.Values.Keys)
            {
                ViewData["wynik"] = "Klucz: " + routekey + " Wartosc: " + RouteData.Values[routekey] + "<br />";
            }
            return View();
        }

        public IActionResult Params(int p1, int p2)
        {
            ViewData["param1"] = "Param1: " + p1;
            ViewData["param2"] = "Param2: " + p2;
            return View();
        }

        public IActionResult GetJson()
        {
            var movie = new Movies() {
                Title = "Tytul",
                Author = "Autor",
                Price = 355
            };
            return Json(movie);
        }


        public IActionResult Plik()
        {
            var path = "~\\content\\plik.txt";
            return File(path, "Home/Movie", "plik.txt");
        }

        [HttpGet]
        public IActionResult Person()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Person(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View("Person", person);
            }
            else
            {
             
                db.Person.Add(person);
                db.SaveChanges();
                return RedirectToAction("PersonList");
            }
        }

        public IActionResult PersonList()
        {
            
            var persons = from m in db.Person
                          select m;

            return View(persons.ToList());

        }

        public IActionResult Delete(int id)
        {
            
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("PersonList");

        }

        public IActionResult PersonEdit(int id)
        {
            
            Person person = db.Person.Find(id);
            return View(person);

        }

        [HttpPost]
        public IActionResult PersonEdit(Person person)
        {
            if (ModelState.IsValid)
            {
                
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PersonList");
            }

            return View(person);
        }
    }
}