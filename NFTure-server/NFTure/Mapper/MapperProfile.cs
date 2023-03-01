using AutoMapper;
using NFTure.Core.Entities;
using NFTure.Core.Entities.Auth;
using NFTure.Web.DTOs.NFT;
using NFTure.Web.DTOs.User;

namespace NFTure.Web.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Nft, NftResponse>().ReverseMap();
            CreateMap<CreateNftRequest, Nft>().ReverseMap();
            CreateMap<UpdateNftRequest, Nft>().ReverseMap();
            CreateMap<UserSignUpRequest, User>().ReverseMap();
        }
    }
}
