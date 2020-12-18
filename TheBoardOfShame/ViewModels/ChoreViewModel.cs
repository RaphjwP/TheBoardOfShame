//created by Scott. This view model combines the Chore and User classes to be accessible in a single model
//in the MainPage view

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TheBoardOfShame.Model;
using TheBoardOfShame.Models;

namespace TheBoardOfShame.ViewModels
{
    public class ChoreViewModel
    {
        //type IEnumberable allows iteration over all of the following objects
        public IEnumerable<Chore> Chores { get; set; }
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Score> Scores { get; set; }

        public WeatherViewModel WeatherViewModel { get; set; }
    }
}