using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class UserDTO
    {
        public string id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }


     

        public string Address { get; set; }
        public string jwtToken { get; set; }

    }
}
