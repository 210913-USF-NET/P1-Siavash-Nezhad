using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DL
{
    public class DBContext : DbContext
    {
        public DBContext() : base() {}
        public DBContext(DbContextOptions options) : base(options) {}

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<StoreFront> StoreFronts { get; set; }

    }
}
