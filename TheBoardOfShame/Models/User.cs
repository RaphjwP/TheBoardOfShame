using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TheBoardOfShame.Models;

namespace TheBoardOfShame.Model
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int Age { get; set; }

        public List<Chore> Chores { get; set; }

        public List<Score> Scores { get; set; }

        public User()
        {
            Chores = new List<Chore>();
            Scores = new List<Score>();
        }
    }


}
