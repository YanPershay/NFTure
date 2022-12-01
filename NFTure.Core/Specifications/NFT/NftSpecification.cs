using NFTure.Core.Entities;
using NFTure.Core.Specifications.Base;

namespace NFTure.Core.Specifications.NFT
{
    public class NftByOwnerIdSpecification : Specification<Nft>
    {
        public NftByOwnerIdSpecification()
        {
            AddOrderByDescending(n => n.OwnerId);
        }

        public NftByOwnerIdSpecification(Guid ownerId) : base(n => n.OwnerId.Equals(ownerId))
        {
            AddInclude(n => n.ImageUrl);
        }
    }
}
