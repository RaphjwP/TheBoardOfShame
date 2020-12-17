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
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ValidateUser(User user)
        {
            return View("MainPage");
        }

        public IActionResult MainPage()
        {
            ChoreViewModel choreviewmodel = new ChoreViewModel();
            choreviewmodel.Chore = _database;
            return View(choreviewmodel);
        }
    }
}
