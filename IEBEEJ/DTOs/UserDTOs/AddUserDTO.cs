﻿using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.OrderDTOs;

namespace IEBEEJ.DTOs.UserDTOs
{
    public class AddUserDTO
    {
        public string Adress { get; set; }

        public DateTime Birthday { get; set; }

        public string Email { get; set; }

        //public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
