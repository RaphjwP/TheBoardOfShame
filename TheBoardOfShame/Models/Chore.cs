//created by Scott. This class creates the chore object

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBoardOfShame.Model
{
    public class Chore
    {
        public int Id { get; set; }

        public string ChoreType { get; set; }

        public string ChoreDescription { get; set; }

        public int ChoreWeight { get; set; }

        public List<User> Users { get; set; }
    }
}
