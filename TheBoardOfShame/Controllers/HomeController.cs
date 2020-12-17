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

        public HomeController(Database database)
        {
            _database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidateUser(User user)
        {
            return View("MainPage");
        }

        [HttpGet]
        [Route("Home/Add")]
        public IActionResult AddChores()
        {

            return View();
        }

        [HttpPost]
        [Route("Home/Add")]
        public IActionResult AddChores(Chore chore)
        {
            var newChore = chore;
            _database.Chore.Add(newChore);
            _database.SaveChanges();

            return View("MainPage");
        }
    }
}
