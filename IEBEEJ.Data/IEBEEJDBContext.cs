using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IEBEEJ.Data
{
    public class IEBEEJDBContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        //public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BidEntity> Bids { get; set; }
        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<CategoryEntity> Category { get; set; }

        public IEBEEJDBContext(DbContextOptions<IEBEEJDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) //seeding: dummy data 
        {
            base.OnModelCreating(modelBuilder);

        }

    }
}
