using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TheBoardOfShame.Model
{
    public class Chore
    {
        public int Id { get; set; }

        public List<User> Users { get; set; }
    }
}
