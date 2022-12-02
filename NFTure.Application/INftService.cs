using NFTure.Application.Models;

namespace NFTure.Application
{
    public interface INftService
    {
        Task<IEnumerable<NftModel>> GetNftsByOwnerIdAsync(Guid ownerId);
    }
}
