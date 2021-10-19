using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderDetailsAPI.Models
{
    public class CompanyContext: DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options)
           : base(options)
        {
        }

        public  DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
