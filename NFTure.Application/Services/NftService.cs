using NFTure.Application.Models;
using NFTure.Core.Interfaces;
using NFTure.Core.Interfaces.Repositories;

namespace NFTure.Application.Services
{
    public class NftService : INftService
    {
        private readonly INftRepository _nftRepository;
        private readonly IAppLogger _logger;

        public NftService(INftRepository nftRepository, IAppLogger logger)
        {
            _nftRepository = nftRepository;
            _logger = logger;
        }

        public Task<List<NftModel>> GetNftsByOwnerIdAsync(Guid ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
