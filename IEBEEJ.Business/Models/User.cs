using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEBEEJ.Business.Models
{
    public class User
    {
        public User() { }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Adress { get; set; }

        public List<Bid> Bids { get; set; }

        public List<Item> ItemsForSale { get; set; }

        public List<Order> BoughtItems { get; set; }

        public List<User> LikedUsers { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsActive { get; set; }

        public DateTime Created { get; set; } = DateTime.Now;

        private Enum Role { get; set; }
    }
}
