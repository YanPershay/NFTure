using NFTure.Application.Models;

namespace NFTure.Application
{
    public interface INftService
    {
        Task<List<NftModel>> GetNftsByOwnerIdAsync(Guid ownerId);
    }
}
