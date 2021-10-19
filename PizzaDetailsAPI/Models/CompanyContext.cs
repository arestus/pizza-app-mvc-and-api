using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDetailsAPI.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(new Pizza()
            {
                PizzaID = 1,
                PizzaName = "Margherita",
                PizzaType = "Plain",
                PizzaPrice = 20
            });
            modelBuilder.Entity<Pizza>().HasData(new Pizza()
            {
                PizzaID = 2,
                PizzaName = "Cheeses",
                PizzaType = "Cheezy",
                PizzaPrice = 30
            });
            modelBuilder.Entity<Pizza>().HasData(new Pizza()
            {
                PizzaID = 3,
                PizzaName = "Neapolitano",
                PizzaType = "Cheezy",
                PizzaPrice = 30
            });
        }
    }
}
