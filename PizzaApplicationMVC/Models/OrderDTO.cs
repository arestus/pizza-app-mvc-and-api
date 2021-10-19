using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Models
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public string Username { get; set; }
        public int OrderTotal { get; set; }

        public int DeliveryCharge { get; set; }

        public string Status { get; set; }
    }
}
