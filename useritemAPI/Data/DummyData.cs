using System.Collections.Generic;
using System.Linq;
using HealthAPI.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HealthAPI.Data
{
    public class DummyData
    {
        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<HealthContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any Patients
                if (context.users != null && context.users.Any())
                    return;   // DB has already been seeded

                var items = DummyData.Getitems().ToArray();
                context.items.AddRange(items);
                context.SaveChanges();

                var users = DummyData.Getusers(context).ToArray();
                context.users.AddRange(users);
                context.SaveChanges();
            }
        }

        public static List<item> Getitems()
        {
            List<item> items = new List<item>() {
            new item {name="Tylenol", game = "2"},
            };
            return items;
        }

        public static List<user> Getusers(HealthContext db)
        {
            List<user> users = new List<user>() {
            new user {
                username = "dummy",
                items = new List<item>(db.items.Take(2))
            },
            };
            return users;
        }
    }

}