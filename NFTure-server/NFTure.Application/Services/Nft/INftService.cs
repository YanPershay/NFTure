using NFTure.Core.Entities;

namespace NFTure.Application.Services
{
    public interface INftService
    {
        // TEST method
        Task<Nft> GetNftByIdAsync(Guid id);
        Task<IEnumerable<Nft>> GetNftsByOwnerIdAsync(Guid ownerId);
        Task<Nft> AddNewNftAsync(Nft nftModel);
        Task UpdateNftAsync(Nft newNft);
        Task<int> GetUserNftCountAsync(Guid userId);
    }
}
