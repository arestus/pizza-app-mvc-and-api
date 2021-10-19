using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAPI.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        public string Name { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Address { get; set; }
    }
}
