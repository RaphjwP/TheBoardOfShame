using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBoardOfShame.Model;

namespace TheBoardOfShame.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {

        private Database _database;
        public IActionResult Index()
        {
            return View();
        }


        public HomeController(Database database)
        {
            _database = database;
        }

        public IActionResult ValidateUser(User user)
        {
            return View("MainPage");
        }

        [HttpGet]
        [Route("Home/Edit/{id}")]
        public IActionResult EditChores(int id)
        {
            var chore = _database.Chore.Find(id);

            return View(chore);
        }

        [HttpPost]
        [Route("Home/Edit/{id}")]
        public IActionResult EditChores(Chore chore)
        {
            var choreToChange = _database.Chore.Find(chore.Id);
            
            choreToChange.ChoreDescription = chore.ChoreDescription;
            choreToChange.ChoreType = chore.ChoreType;
            choreToChange.ChoreWeight = chore.ChoreWeight;

            _database.Chore.Update(choreToChange);
            _database.SaveChanges();

            return View("MainPage");
        }

        [Route("Home/Details/{id}")]
        public IActionResult GiveDetails(int id)
        {
            var chore = _database.Chore.Find(id);

            return View(chore);
        }

        [HttpGet]
        [Route("Home/Delete/{id}")]
        public IActionResult DeleteChores(int id)
        {
            var chore = _database.Chore.Find(id);

            return View(chore);
        }

        [HttpPost]
        [Route("Home/Delete/{id}")]
        public IActionResult DeleteChores(Chore chore)
        {
            _database.Chore.Remove(chore);
            _database.SaveChanges();

            return View("MainPage");
        }
    }
}
