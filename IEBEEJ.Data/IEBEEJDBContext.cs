using IEBEEJ.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace IEBEEJ.Data
{
    public class IEBEEJDBContext : DbContext
    {
        public DbSet<ItemEntity> Items { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
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

            List<CategoryEntity> categories = GenerateDummyCategories();
            modelBuilder.Entity<CategoryEntity>().HasData(categories);

            List<ItemEntity> items = GenerateDummyItems();
            modelBuilder.Entity<ItemEntity>().HasData(items);

            List<BidEntity> bids = GenerateDummyBids();
            modelBuilder.Entity<BidEntity>().HasData(bids);

            List<StatusEntity> statuses = GenerateDummyStatuses();
            modelBuilder.Entity<StatusEntity>().HasData(statuses);

            List<OrderEntity> orders = GenerateDummyOrders();
            modelBuilder.Entity<OrderEntity>().HasData(orders);
        }

        private List<BidEntity> GenerateDummyBids()
        {
            return new List<BidEntity>()
            {
                new BidEntity
                {
                    Id = 1,
                    BidValue = 500,
                    ItemID = 1,
                    BidderId = 2,
                },
                 new BidEntity
                {
                    Id = 2,
                    BidValue = 600,
                    ItemID = 1,
                    BidderId = 1,
                },
                  new BidEntity
                {
                    Id = 3,
                    BidValue = 700,
                    ItemID = 1,
                    BidderId = 2,
                },
            };
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
                    Adress = "Thuis-Straat",
                    PhoneNumber = "1234567890",
                    Birthday = new DateTime(1980, 10,10),
                },
                new UserEntity
                {
                    Id = 2,
                    Name = "Jacky Jackouis",
                    Email = "JaJa2015@hotmail.com",
                    Password = "EnglishFrench",
                    Adress = "Parque De Triumph",
                    PhoneNumber = "9876543210",
                    Birthday = new DateTime(1995, 1,10)
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
                   SellerId=1,
                   SendingAdress = "dok",
                   StartingPrice = 1,
               },
               new ItemEntity
               {
                   Id=2,
                   CategoryId = 2,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 200,
                   EstimatedValueMin = 50,
                   ItemDescription="Tight Shorts that make you pretty",
                   ItemName="A TS",
                   SellerId=1,
                   SendingAdress = "dok",
                   StartingPrice = 50,
               },
               new ItemEntity
               {
                   Id=3,
                   CategoryId = 3,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 99,
                   EstimatedValueMin = 15,
                   ItemDescription="A book about the wonders of Belgium",
                   ItemName="Tiny Treasure Box",
                   SellerId=2,
                   SendingAdress = "Ghent",
                   StartingPrice = 15,
               },
               new ItemEntity
               {
                   Id=4,
                   CategoryId = 4,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 400,
                   EstimatedValueMin = 99,
                   ItemDescription="An used old couch",
                   ItemName="Hang Bank",
                   SellerId=1,
                   SendingAdress = "My home",
                   StartingPrice = 80,
               },
                new ItemEntity
               {
                   Id=5,
                   CategoryId = 5,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 400,
                   EstimatedValueMin = 299,
                   ItemDescription="A grownups toy",
                   ItemName="The Big Sheep Anatomy S-Doll",
                   SellerId=1,
                   SendingAdress = "My home",
                   StartingPrice = 250,
               },
               new ItemEntity
               {
                   Id=6,
                   CategoryId = 6,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 20000,
                   EstimatedValueMin = 959,
                   ItemDescription="A painting from the Holy Roman Empire Time Period, for reals",
                   ItemName="Holy Pope punching the heretic",
                   SellerId=2,
                   SendingAdress = "Centrum Brussel",
                   StartingPrice = 850,
               },
               new ItemEntity
               {
                   Id=7,
                   CategoryId = 3,
                   Created = DateTime.Now,
                   EndDate = DateTime.Now.AddDays(7),
                   EstimatedValueMax = 20000,
                   EstimatedValueMin = 959,
                   ItemDescription="A book about how to read books",
                   ItemName="Reading Book for dummies",
                   SellerId=1,
                   SendingAdress = "Centrum Brussel",
                   StartingPrice = 200,
               },
           };
        }

        private List<CategoryEntity> GenerateDummyCategories()
        {
            return new List<CategoryEntity>
           {
               new CategoryEntity
               {
                  Id = 1,
                   Name = "Other"
               },
                new CategoryEntity
               {
                   Id = 2,
                   Name = "Fashion"
               },
                 new CategoryEntity
               {
                   Id = 3,
                   Name = "Readables"
               },
                  new CategoryEntity
               {
                   Id = 4,
                   Name = "Furniture"
               },
                   new CategoryEntity
               {
                   Id = 5,
                   Name = "Toys"
               },
                    new CategoryEntity
               {
                   Id = 6,
                   Name = "Decoration"
               },
           };
        }

        private List<StatusEntity> GenerateDummyStatuses()
        {
            return new List<StatusEntity>()
            {
                new StatusEntity
                {
                    Id = 1,
                    Status = "Open"
                },
                new StatusEntity
                {
                    Id = 2,
                    Status = "Closed"
                },
                new StatusEntity
                {
                    Id = 3,
                    Status = "Sold"
                },
                new StatusEntity
                {
                    Id = 4,
                    Status = "Cancelled"
                },
            };
        }

        private List<OrderEntity> GenerateDummyOrders()
        {
            return new List<OrderEntity>()
            {
                new OrderEntity
            {
                    Id = 1,
                    WonItemId = 1,
                    TotalCost = 700,
                    StatusId = 1,
                    PaymentMethod = "Paypal",
                    WonBiddingId = 3
                },
                new OrderEntity
                {
                    Id = 2,
                    WonItemId = 2,
                    TotalCost = 600,
                    StatusId = 2,
                    PaymentMethod = "Credit Card" ,
                    WonBiddingId = 2
                },
                new OrderEntity
                {
                    Id = 3,
                    WonItemId = 3,
                    TotalCost = 700,
                    StatusId = 3,
                    PaymentMethod = "Paypal",
                    WonBiddingId = 1
                }
            };
        }
    }
}