using PizzaDetailsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaDetailsAPI.Services
{
    public class PizzaService
    {
        private readonly CompanyContext _context;

        public PizzaService(CompanyContext context)
        {
            _context = context;
        }
        public List<Pizza> AllPizzas()
        {
            List<Pizza> pizzas;
            pizzas = _context.Pizzas.ToList();
            return pizzas;
        }
        public Pizza GetPizza(int id)
        {
            Pizza pizza = null;
            pizza = _context.Pizzas.FirstOrDefault(p => p.PizzaID == id);
            return pizza;
        }
    }
}
