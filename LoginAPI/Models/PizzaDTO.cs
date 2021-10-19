using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class PizzaDTO
    {
        public int PizzaID { get; set; }
        public string PizzaName { get; set; }

        public string PizzaType { get; set; }
        public int PizzaPrice { get; set; }
    }
}
