using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class OrderDetailsDTO
    {
        public int ItemNumber { get; set; }

        public int OrderId { get; set; }
        public int PizzaNumber { get; set; }
        public string jwtToken { get; set; }
    }
}
