using NFTure.Application.Mapper;
using NFTure.Application.Models;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;

namespace NFTure.Application.Services
{
    public class NftService : INftService
    {
        private readonly INftRepository _nftRepository;
        // TODO: create logging system
        //private readonly IAppLogger _logger;

        public NftService(INftRepository nftRepository)
        {
            _nftRepository = nftRepository;
        }

        public async Task<IEnumerable<NftModel>> GetNftsByOwnerIdAsync(Guid ownerId)
        {
            var nfts = await _nftRepository.GetAllUserNftsAsync(ownerId);

            return ObjectMapper.Mapper.Map<IEnumerable<NftModel>>(nfts);
        }

        public async Task<NftModel> AddNewNftAsync(NftModel nftModel)
        {
            // TODO: add validation

            nftModel.Id = Guid.NewGuid();
            nftModel.CreatedDateUtc = DateTimeOffset.UtcNow;

            var mappedEntity = ObjectMapper.Mapper.Map<Nft>(nftModel);

            if (mappedEntity is null)
            {
                // TODO: create custom exception
                throw new ApplicationException("Entity couldn't be mapped.");
            }

            var newEntity = await _nftRepository.AddAsync(mappedEntity);
            // TODO: log this

            var newMappedEntity = ObjectMapper.Mapper.Map<NftModel>(newEntity);

            return newMappedEntity;
        }

        // TODO: add validation method
    }
}
