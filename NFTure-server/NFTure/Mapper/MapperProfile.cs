using AutoMapper;
using NFTure.Application.Models;
using NFTure.Core.Entities.Auth;
using NFTure.Web.DTOs.NFT;
using NFTure.Web.DTOs.User;

namespace NFTure.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<NftModel, NftResponse>().ReverseMap();
            CreateMap<CreateNftRequest, NftModel>().ReverseMap();
            CreateMap<UpdateNftRequest, NftModel>().ReverseMap();
            CreateMap<UserSignUpRequest, User>().ReverseMap();
        }
    }
}
