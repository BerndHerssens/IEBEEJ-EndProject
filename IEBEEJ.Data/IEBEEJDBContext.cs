using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Data
{
    internal class IEBEEJDBContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BidEntity> Bids { get; set; }

        public IEBEEJDBContext(DbContextOptions<IEBEEJDBContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //seeding: dummy data 
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
