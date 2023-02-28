using NFTure.Application.Models.Base;

namespace NFTure.Application.Models
{
    public class NftModel : Model<Guid>
    {
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CreatorId { get; set; }
        public DateTimeOffset? CreatedDateUtc { get; set; }
        public DateTimeOffset? LastUpdatedDateUtc { get; set; }
    }
}
