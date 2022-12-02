using AutoMapper;
using NFTure.Application.Models;
using NFTure.Web.DTOs;

namespace NFTure.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NftModel, NftDto>().ReverseMap();
        }
    }
}
