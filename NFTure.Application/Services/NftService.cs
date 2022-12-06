using NFTure.Application.Mapper;
using NFTure.Application.Models;
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
            var nfts = await _nftRepository.GetAllUserNfts(ownerId);

            return ObjectMapper.Mapper.Map<IEnumerable<NftModel>>(nfts);
        }
    }
}
