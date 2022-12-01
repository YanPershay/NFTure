using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Infrastructure.Data;
using NFTure.Infrastructure.Repositories.Base;

namespace NFTure.Infrastructure.Repositories
{
    public class NftRepository : Repository<Nft, Guid>, INftRepository
    {
        public NftRepository(NftureContext context) : base(context)
        {
        }

        public Task<IReadOnlyList<Nft>> GetAllUserNfts(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
