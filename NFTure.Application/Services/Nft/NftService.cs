using NFTure.Application.Mapper;
using NFTure.Application.Models;
using NFTure.Core;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Specifications.NFT;

namespace NFTure.Application.Services
{
    public class NftService : INftService
    {
        private readonly INftRepository _nftRepository;
        private readonly IAppLogger<NftService> _logger;
        private readonly IClientActivityService _clientActivityService;

        public NftService(INftRepository nftRepository,
            IAppLogger<NftService> logger,
            IClientActivityService clientActivityService)
        {
            _nftRepository = nftRepository;
            _logger = logger;
            _clientActivityService = clientActivityService;
        }

        public async Task<IEnumerable<NftModel>> GetNftsByOwnerIdAsync(Guid ownerId)
        {
            var nfts = await _nftRepository.GetAllUserNftsAsync(ownerId);

            return ObjectMapper.Mapper.Map<IEnumerable<NftModel>>(nfts);
        }

        public async Task<NftModel> AddNewNftAsync(NftModel nftModel)
        {
            if (nftModel is null)
            {
                throw new ArgumentNullException(nameof(nftModel), "New NFT can't be null.");
            }

            // More serious check for NFT unique
            nftModel.Id = Guid.NewGuid();
            nftModel.CreatedDateUtc = DateTimeOffset.UtcNow;

            //TODO: add check for nullability for required fields
            var mappedNftEntity = ObjectMapper.Mapper.Map<Nft>(nftModel);

            if (mappedNftEntity is null)
            {
                // TODO: create custom exception
                throw new ApplicationException("Entity couldn't be mapped.");
            }

            var newNft = await _nftRepository.AddAsync(mappedNftEntity);
            _logger.LogInformation(GetType(), "NFT was successfully added.");

            await _clientActivityService.CreateClientActivityAsync(
                ClientActivityAction.AddedNewNft,
                ClientActivityType.Added,
                newNft.OwnerId,
                typeof(Nft));

            var newMappedEntity = ObjectMapper.Mapper.Map<NftModel>(newNft);

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

            _logger.LogInformation(GetType(), $"NFT was successfully updated.");
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
