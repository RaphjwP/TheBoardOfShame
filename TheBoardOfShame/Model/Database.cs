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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\ProjectsV13;Initial Catalog=BoardOfShameDB;Integrated Security=True;");
            //Data Source=(localdb)\ProjectsV13;Initial Catalog=master;Integrated Security=True;
            //Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
            //optionsBuilder.UseS
            //optionsBuilder.UseSqlServer("");
        }
    }
}
