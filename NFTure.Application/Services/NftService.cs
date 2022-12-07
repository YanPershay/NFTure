using NFTure.Application.Mapper;
using NFTure.Application.Models;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Specifications.NFT;

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
            // Possible more serious check for NFT unique
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

        public async Task UpdateNftAsync(NftModel newNft)
        {
            await ValidateNftIfNotExists(newNft.Id);

            var editNft = await _nftRepository.GetByIdAsync(newNft.Id);

            if (editNft is null)
            {
                throw new ApplicationException("Not existing entity.");
            }

            editNft.Price = newNft.Price;
            editNft.Description = newNft.Description;
            editNft.ImageUrl = newNft.ImageUrl;
            editNft.OwnerId = newNft.OwnerId;
            editNft.LastUpdatedDateUtc = DateTimeOffset.UtcNow;

            await _nftRepository.UpdateAsync(editNft);
            // logger
        }

        public async Task<int> GetUserNftCountAsync(Guid userId)
        {
            var spec = new NftByOwnerIdSpecification(userId);

            return await _nftRepository.CountAsync(spec);
        }

        private async Task ValidateNftIfExists(Guid nftId)
        {
            var existingEntity = await _nftRepository.GetByIdAsync(nftId);
            if (existingEntity is not null)
            {
                throw new ApplicationException($"NFT entity with this id already exists");
            }
        }

        private async Task ValidateNftIfNotExists(Guid nftId)
        {
            var existingEntity = await _nftRepository.GetByIdAsync(nftId);
            if (existingEntity is null)
            {
                throw new ApplicationException($"NFT entity with this id is not exists");
            }
        }
    }
}
