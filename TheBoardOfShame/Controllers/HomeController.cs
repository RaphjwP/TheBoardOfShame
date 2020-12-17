using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBoardOfShame.Model;
using TheBoardOfShame.ViewModels;

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

        [Route("Home/Edit/{id}")]
        public IActionResult EditChores(int id)
        {
            var chore = _database.Chore.Find(id);

            return View(chore);
        }

        [HttpPost]
        public IActionResult EditChores(Chore chore)
        {
            var choreToChange = _database.Chore.Find(chore.Id);
            a
            choreToChange.ChoreDescription = chore.ChoreDescription;
            choreToChange.ChoreType = chore.ChoreType;
            choreToChange.ChoreWeight = chore.ChoreWeight;

            _database.Chore.Update(choreToChange);
            _database.SaveChanges();

            return View("MainPage");
        }
    }
}
