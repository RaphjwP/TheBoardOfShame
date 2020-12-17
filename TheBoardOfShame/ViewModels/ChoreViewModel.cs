using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBoardOfShame.ViewModels
{
    public class ChoreViewModel
    {
        public Model.Chore Chore { get; set; }
        public Model.User User { get; set; }
    }
}