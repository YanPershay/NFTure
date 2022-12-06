using NFTure.Core.Entities;
using NFTure.Core.Specifications.Base;

namespace NFTure.Core.Specifications.NFT
{
    public class NftByOwnerIdSpecification : Specification<Nft>
    {
        public NftByOwnerIdSpecification() : base(null)
        {
            ApplyOrderByDescending(n => n.CreatedDateUtc);
        }

        public NftByOwnerIdSpecification(Guid ownerId) : base(n => n.OwnerId.Equals(ownerId))
        {
            // AddInclude(n => n.ImageUrl);
            // AddInclude(n => n.User);
        }
    }
}
