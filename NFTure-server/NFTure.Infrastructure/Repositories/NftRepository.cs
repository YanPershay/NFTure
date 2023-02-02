using Microsoft.EntityFrameworkCore;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Specifications.NFT;
using NFTure.Infrastructure.Data;
using NFTure.Infrastructure.Repositories.Base;

namespace NFTure.Infrastructure.Repositories
{
    public class NftRepository : Repository<Nft, Guid>, INftRepository
    {
        public NftRepository(NftureContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Nft>> GetAllUserNftsAsync(Guid userId)
        {
            var spec = new NftByOwnerIdSpecification(userId);
            return await GetAsync(spec);
        }
    }
}
