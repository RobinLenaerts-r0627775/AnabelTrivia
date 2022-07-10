using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AnabelTrivia.Data;

namespace AnabelTrivia.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly DatabaseContext db;

        public HomeController(DatabaseContext context)
        {
            db = context;
        }

        // GET: Questions
        public async Task<IActionResult> IndexAsync()
        {
            var categories = db.Questions.Where(x => x.Used == "N").Select(x => x.Category).Distinct().ToList();
            ViewBag.Categories = categories;
            return View();
        }

        public IActionResult Random(string category)
        {
            var rand = new Random();

            var toSkip = rand.Next(0, db.Questions.Where(x => x.Used != "Y" && x.Category == category).Count());
            var random = db.Questions.Where(x => x.Used != "Y" && x.Category == category).Skip(toSkip).Take(1).First();
            random.Used = "Y";
            db.Questions.Update(random);
            db.SaveChanges();

            var counter = db.Questions.Where(x => x.Used == "N").Count();
            if (counter == 0)
            {
                foreach (var record in db.Questions.ToList())
                {
                    record.Used = "N";
                }
            }

            db.SaveChanges();
            var categories = db.Questions.Where(x => x.Used == "N").Select(x => x.Category).Distinct().ToList();
            ViewBag.Categories = categories;
            return View(random);
        }
    }
}