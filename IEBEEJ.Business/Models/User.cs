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
        public string Adress { get; set; }
        public List<Bid> Bids { get; set; }
        public DateTime Birthday { get; set; }
        public List<Order> BoughtItems { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public string Email { get; set; }
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public List<Item> ItemsForSale { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        private Enum Role { get; set; }
    }
}
