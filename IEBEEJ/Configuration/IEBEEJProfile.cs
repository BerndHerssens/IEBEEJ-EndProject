using AutoMapper;
using IEBEEJ.Business;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;
using IEBEEJ.DTO;


namespace IEBEEJ.Configuration
{
    public class IEBEEJProfile : Profile
    {
        public IEBEEJProfile()
        {
            CreateMap<BidEntity, Bid>().ReverseMap();
            CreateMap<ItemEntity, Item>().ReverseMap();

            CreateMap<ItemDTO, Item>();

            CreateMap<CategoryEntity, CategoryType>().ReverseMap();
        }
    }
}
