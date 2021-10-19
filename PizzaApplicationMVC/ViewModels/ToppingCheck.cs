using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.ViewModels
{
    public class ToppingCheck
    {
        public int ToppingID { get; set; }
        public string ToppingName { get; set; }
        public int? ToppingPrice { get; set; }

        public bool IsChecked { get; set; }
    }
    public class ToppingList
    {
        //use CheckBoxModel class as list 
        public List<ToppingCheck> Toppings { get; set; }
    }
}
