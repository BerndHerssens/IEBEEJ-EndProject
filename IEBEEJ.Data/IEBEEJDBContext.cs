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

            List<UserEntity> users = GenerateDummyUsers();
            modelBuilder.Entity<UserEntity>().HasData(users);

            List<ItemEntity> items = GenerateDummyItems();
            modelBuilder.Entity<ItemEntity>().HasData(items);

        }

        private List<UserEntity> GenerateDummyUsers()
        {
            return new List<UserEntity> 
            { 
                new UserEntity
                {
                    Id = 1,
                    Name = "Buddy",
                    Email = "Buddy@hotmail.com",
                    Password = "1230",
                    Adress = "Buddy straat",
                    PhoneNumber = "1234567890",
                    Birthday = DateTime.Now, 
                },

            };
        }

        private List<ItemEntity> GenerateDummyItems()
        {
            return new List<ItemEntity>
           {
               new ItemEntity
               {
                   Id=1,
                   CategoryId = 1,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 50000,
                   EstimatedValueMin = 10,
                   ItemDescription="Doodoo",
                   ItemName="Dada item",
                   SellerID=1,
                   SendingAdress = "dok",
                   StartingPrice = 1,
               },
           };
        }
    }
}
