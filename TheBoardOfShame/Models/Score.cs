﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBoardOfShame.Model;

namespace TheBoardOfShame.Models
{
    public class Score
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Chore Chore { get; set; }
        public int ChoreScore { get; set; }
    }
}
