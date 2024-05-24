using AutoMapper;
using IEBEEJ.Business;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.DTOs.ItemDTOs;


namespace IEBEEJ.Configuration
{
    public class IEBEEJProfile : Profile
    {
        public IEBEEJProfile()
        {
            CreateMap<BidEntity, Bid>().ReverseMap();
            CreateMap<ItemEntity, Item>().ReverseMap();

            CreateMap<Item, ItemDTO>();
            CreateMap<AddItemDTO, Item>();
            CreateMap<UpdateItemDTO, Item>();
        }
    }
}
