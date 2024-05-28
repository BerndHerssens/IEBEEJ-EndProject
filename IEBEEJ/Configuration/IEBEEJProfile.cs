using AutoMapper;
using IEBEEJ.Business;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.DTOs.BidDTOs;
using IEBEEJ.DTOs.ItemDTOs;
using IEBEEJ.DTOs.OrderDTOs;
using IEBEEJ.DTOs.UserDTOs;


namespace IEBEEJ.Configuration
{
    public class IEBEEJProfile : Profile
    {
        public IEBEEJProfile()
        {
            CreateMap<BidEntity, Bid>().ReverseMap();
            CreateMap<ItemEntity, Item>().ReverseMap();
            CreateMap<UserEntity, User>().ReverseMap();
            CreateMap<CategoryEntity, Category>().ReverseMap();
            CreateMap<OrderEntity, Order>().ReverseMap();
            CreateMap<StatusEntity,StatusType>();

            CreateMap<Item, ItemDTO>();
            //CreateMap<User, SmallSellerDTO>()
            //    .ForMember(x => x.Id, y => y.MapFrom(z => z.ID))
            //    .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
            //CreateMap<Item, ItemDTO>()
            //    .ForMember(x => x.Seller, y => y.MapFrom(z => z.Seller.Name));
            CreateMap<AddItemDTO, Item>();
            CreateMap<UpdateItemDTO, Item>();
            CreateMap<Item, SmallItemDTO>();

            CreateMap<User, UserDTO>();
            CreateMap<User, SmallUserDTO>();
            CreateMap<AddUserDTO, User>();
            CreateMap<UpdateUserDTO, User>();


            CreateMap<Bid, SmallBidDTO>();

            CreateMap<Order, SmallOrderDTO>();
            
        }
    }
}
