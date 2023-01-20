using AutoMapper;
using NFTure.Application.Models;
using NFTure.Core.Entities;

namespace NFTure.Application.Mapper
{
    public static class ObjectMapper
    {
        public static IMapper Mapper => Lazy.Value;

        private static Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<ModelMapperProfile>();
            });

            return config.CreateMapper();
        });
    }

    public class ModelMapperProfile : Profile
    {
        public ModelMapperProfile()
        {
            CreateMap<Nft, NftModel>().ReverseMap();
        }
    }
}
