using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToppingDetailsAPI.Models;

namespace ToppingDetailsAPI.Services
{
    public class ToppingService
    {
        private readonly CompanyContext _context;

        public ToppingService(CompanyContext context)
        {
            _context = context;
        }
        public List<Topping> AllToppings()
        {
            List<Topping> pizzas;
            pizzas = _context.Toppings.ToList();
            return pizzas;
        }
        public Topping GetTopping(int id)
        {
            Topping pizza = null;
            pizza = _context.Toppings.FirstOrDefault(p => p.ToppingID == id);
            return pizza;
        }
    }
}
