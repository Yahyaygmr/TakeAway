using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TakeAway.Order.Domain.Entities;

namespace TakeAway.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost,1440;database=TakeAwayOrderDb;integrated security=true;TrustServerCertificate=true;");
        }
        public DbSet<Adress> Adreses { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
        public DbSet<OrderedDetail> OrderedDetails { get; set; }
    }
}
