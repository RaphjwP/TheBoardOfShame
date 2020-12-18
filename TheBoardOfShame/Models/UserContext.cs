using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TheBoardOfShame.Model;

namespace TheBoardOfShame.Models
{
    public class UserContext : IdentityDbContext<User>
    {

        // This class is needed to conform to IdentityDbContext. Trying to use one main DBContext only causes problems. Because in technicality Database : DBContext does not import from IdentityDbContext<User>, which is needed by the Identity.
        public UserContext(DbContextOptions options) : base()
        {

        }

        public DbSet<User> Users { get; set; }

        // Configuration of DB to another DB due to multiple Context Conflicts
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=UserBoardOfShameDB;MultipleActiveResultSets=true;");

        }

        // This Method is needed to ignore the connection from User Model to other Models such as Chore/Score
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Ignore(t => t.Chores);
            builder.Entity<User>().Ignore(t => t.Scores);
            base.OnModelCreating(builder);
        }
    }
}