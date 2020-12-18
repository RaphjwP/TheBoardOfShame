using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBoardOfShame.Model;
using TheBoardOfShame.Models;
using TheBoardOfShame.ViewModels;

namespace TheBoardOfShame.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private Database _database;
        private WeatherViewModel _weatherViewModel;

        public HomeController(Database database)
        {
            _database = database;
            _weatherViewModel = new WeatherViewModel();
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


        public IActionResult MainPage()
        {
            ChoreViewModel choreviewmodel = new ChoreViewModel();
            choreviewmodel.Chores = _database.Chore;
            choreviewmodel.Users = _database.Users;

            return View(choreviewmodel);
        }

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

        [Route("Home/GiveDetails/{id}")]
        public IActionResult GiveDetails(int id)
        {
            var chore = _database.Chore.Find(id);

            return View(chore);
        }
        [HttpGet]
        [Route("Home/Details/{id}")]
        public IActionResult GiveUsers(int id)
        {
            var user = _database.Users.Find(id);

            return View(user);
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
