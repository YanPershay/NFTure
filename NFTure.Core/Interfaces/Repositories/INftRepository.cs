using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories.Base;

namespace NFTure.Core.Interfaces.Repositories
{
    public interface INftRepository : IRepository<Nft, Guid>
    {
        Task<IReadOnlyList<Nft>> GetAllUserNfts(Guid userId);
    }
}
