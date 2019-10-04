using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommerceBank.Models;

namespace CommerceBank.Models
{
    public class CommerceBankContext : DbContext
    {
        public CommerceBankContext (DbContextOptions<CommerceBankContext> options)
            : base(options)
        {
        }

        public DbSet<CommerceBank.Models.Customer> Customer { get; set; }

        public DbSet<CommerceBank.Models.Account> Account { get; set; }

        public DbSet<CommerceBank.Models.Transaction> Transaction { get; set; }
    }
}
