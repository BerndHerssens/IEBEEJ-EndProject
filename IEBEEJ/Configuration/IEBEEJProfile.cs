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
                
                
            //    .ForMember(x => x.Id, y => y.MapFrom(z => z.ID))
            //    .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
            //    .ForMember(x => x.Seller, y => y.MapFrom(z => z.Seller.Name));
            //CreateMap<Item, ItemDTO>()
            //CreateMap<User, SmallSellerDTO>()
            CreateMap<AddItemDTO, Item>();
            CreateMap<AddOrderDTO, Order>();
            CreateMap<AddUserDTO, User>();
            CreateMap<Bid, SmallBidDTO>();
            CreateMap<BidEntity, Bid>().ReverseMap();
            CreateMap<CategoryEntity, Category>().ReverseMap();
            CreateMap<Item, ItemDTO>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.SellerId))
                .ForPath(x => x.SellerName, y => y.MapFrom(z => z.Seller.Name))
                .ForPath(x => x.CategoryName, y => y.MapFrom(z => z.Category.Name)) ;
            CreateMap<Item, ItemForBidDTO>();
            CreateMap<Item, SmallUserDTO>();
            CreateMap<User, ItemForOrderDTO>();
            CreateMap<ItemEntity, Item>().ReverseMap();
            CreateMap<Order, OrderDTO>();
            CreateMap<Order, SmallOrderDTO>();
            CreateMap<OrderEntity, Order>().ReverseMap();
            CreateMap<StatusEntity,StatusType>();
            CreateMap<UpdateBidDTO, Bid>();
            CreateMap<UpdateItemDTO, Item>();
            CreateMap<UpdateOrderStatusDTO, Order>();            
            CreateMap<UpdateUserDTO, User>();
            CreateMap<User, SmallUserDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserForOrderDTO>();
            CreateMap<UserEntity, User>().ReverseMap();
        }
    }
}
