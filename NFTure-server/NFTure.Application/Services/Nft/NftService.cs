using NFTure.Application.Mapper;
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
        private readonly IUserActivityService _userActivityService;

        public NftService(INftRepository nftRepository,
            IAppLogger<NftService> logger,
            IUserActivityService userActivityService)
        {
            _nftRepository = nftRepository;
            _logger = logger;
            _userActivityService = userActivityService;
        }

        public async Task<Nft> GetNftByIdAsync(Guid id)
        {
            return await _nftRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Nft>> GetNftsByOwnerIdAsync(Guid ownerId)
        {
            return await _nftRepository.GetAllUserNftsAsync(ownerId);
        }

        public async Task<Nft> AddNewNftAsync(Nft nft)
        {
            if (nft is null)
            {
                throw new ArgumentNullException(nameof(nft), "New NFT can't be null.");
            }

            // More serious check for NFT unique
            nft.Id = Guid.NewGuid();
            nft.CreatedDateUtc = DateTimeOffset.UtcNow;

            //TODO: add check for nullability for required fields
            var mappedNftEntity = ObjectMapper.Mapper.Map<Nft>(nft);

            if (mappedNftEntity is null)
            {
                // TODO: create custom exception
                throw new ApplicationException("Entity couldn't be mapped.");
            }

            var newNft = await _nftRepository.AddAsync(mappedNftEntity);
            _logger.LogInformation(GetType(), "NFT was successfully added.");

            await _userActivityService.CreateUserActivityAsync(
                UserActivityAction.AddedNewNft,
                UserActivityType.Added,
                newNft.OwnerId,
                typeof(Nft));

            return newNft;
        }

        public async Task UpdateNftAsync(Nft newNft)
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
