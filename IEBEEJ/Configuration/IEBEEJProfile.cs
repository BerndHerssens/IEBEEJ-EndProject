using AutoMapper;
using IEBEEJ.Business.Models;
using IEBEEJ.Data.Entities;


namespace IEBEEJ.Configuration
{
    public class IEBEEJProfile : Profile
    {
        public IEBEEJProfile()
        {
            CreateMap<BidEntity, Bid>().ReverseMap();
            CreateMap<ItemEntity, Item>().ReverseMap();
        }
    }
}
