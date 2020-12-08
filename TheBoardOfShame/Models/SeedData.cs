using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TheBoardOfShame.Model
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            Database context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<Database>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Users.Any())
            {
                context.Users.AddRange(new User
                    {
                        FirstName = "Jae", LastName = "Park", Email = "parjaewo@sheridancollege.ca",
                        Password = "abcd1234", Age = 24
                    },
                    new User
                    {
                        FirstName = "Mike", LastName = "Komor", Email = "komormi@sheridancollege.ca",
                        Password = "aabbcc12", Age = 27
                    }, new User
                    {
                        FirstName = "Scott", LastName = "McGhie", Email = "mcghiesc@sheridancollege.ca",
                        Password = "1234abcd"
                    });
                context.SaveChanges();
            }

        }
    }
}
