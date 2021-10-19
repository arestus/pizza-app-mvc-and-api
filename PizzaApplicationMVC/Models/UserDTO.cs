using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaApplicationMVC.Models
{
    public class UserDTO
    {
        [DataType(DataType.EmailAddress)]
        public string id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[DataType(DataType.EmailAddress)]
        //public string Emailid { get; set; }

        //public string Name { get; set; }

        //[DataType(DataType.Password)]
        //public string Password { get; set; }
        //[DataType(DataType.Password)]
        //[Compare("Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public string Address { get; set; }
        public string jwtToken { get; set; }
    }
}
