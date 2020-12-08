using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheBoardOfShame.Model
{
    public class Database : DbContext
    {
        public Database()
        {

        }

        public Database(DbContextOptions<Database> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        public DbSet<Chore> Chore { get; set; }

    }
}
