using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheBoardOfShame.Model;
using TheBoardOfShame.Models;
using TheBoardOfShame.ViewModels;

namespace TheBoardOfShame.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private Database _database;
        private UserContext _context;
        private static WeatherViewModel _weatherViewModel;

        // Database Init
        public HomeController(Database database, UserContext context)
        {
            _database = database;
            _context = context;
            _weatherViewModel = new WeatherViewModel();
        }

        public IActionResult Index()
        {
            return RedirectToAction("Login", "Account");
        }


        // This is to test Weather API calls
        public IActionResult DisplayWeather()
        {
            return View("DisplayWeather",_weatherViewModel);
        }

        // Validate user is called in Login
        public IActionResult ValidateUser(User user)
        {
            return View("MainPage");
        }

        // Get for Add View
        [HttpGet]
        [Route("Home/Add")]
        public IActionResult AddChores()
        {

            return View();
        }

        // Post action for Add view with adding to DB
        [HttpPost]
        [Route("Home/Add")]
        public IActionResult AddChores(Chore chore)
        {
            var newChore = chore;
            _database.Chore.Add(newChore);
            _database.SaveChanges();

            return RedirectToAction("MainPage");
        }


        // Navigation to Main Page
        public IActionResult MainPage()
        {
            ChoreViewModel choreviewmodel = new ChoreViewModel();
            choreviewmodel.Chores = _database.Chore;
            var users = _context.Users;
            foreach (var user in users)
            {
                user.Scores = _database.Scores.Where(s => s.User.Id == user.Id).ToList();
            }

            choreviewmodel.Users = _context.Users;
            choreviewmodel.WeatherViewModel = _weatherViewModel;

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

            return RedirectToAction("MainPage");
        }

        [Route("Home/GiveDetails/{id}")]
        public IActionResult GiveDetails(int id)
        {
            var chore = _database.Chore.Find(id);

            return View(chore);
        }
        [HttpGet]
        [Route("Home/GiveUsers/{id}")]
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

            return RedirectToAction("MainPage");
        }
    }
}
