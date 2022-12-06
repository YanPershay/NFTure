using AutoMapper;
using NFTure.Application.Models;
using NFTure.Web.DTOs.NFT;

namespace NFTure.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NftModel, NftResponse>().ReverseMap();
            CreateMap<CreateNftRequest, NftModel>().ReverseMap();
        }
    }
}
