using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheBoardOfShame.Model
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter your Age")]
        public int Age { get; set; }

        public List<Chore> Chores { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }

        public User()
        {
            Chores = new List<Chore>();
        }
    }


}
