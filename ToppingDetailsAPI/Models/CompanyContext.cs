using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToppingDetailsAPI.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        public DbSet<Topping> Toppings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Topping>().HasData(new Topping()
            {
               ToppingID = 1,
               ToppingName = "Olives",
               ToppingPrice = 2
            });
            modelBuilder.Entity<Topping>().HasData(new Topping()
            {
                ToppingID = 2,
                ToppingName = "Tomato",
                ToppingPrice = 5
            });
            modelBuilder.Entity<Topping>().HasData(new Topping()
            {
                ToppingID = 3,
                ToppingName = "Onion",
                ToppingPrice = 4
            });
            modelBuilder.Entity<Topping>().HasData(new Topping()
            {
                ToppingID = 4,
                ToppingName = "Cheese",
                ToppingPrice = 6
            });

        }
    }
}
