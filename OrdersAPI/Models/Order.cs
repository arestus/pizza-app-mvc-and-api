using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersAPI.Models
{
    public class Order
    {

        [Key]
        public int OrderID { get; set; }
        public string Username { get; set; }
        public int OrderTotal { get; set; }

        public int DeliveryCharge { get; set; }

        public string Status { get; set; }
    }
}
