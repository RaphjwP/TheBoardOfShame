using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TheBoardOfShame.Model;

namespace TheBoardOfShame.ViewModels
{
    public class ChoreViewModel
    {
        public IEnumerable<Chore> Chores { get; set; }
        public IEnumerable<User> Users { get; set; }

        public WeatherViewModel WeatherViewModel { get; set; }
    }
}