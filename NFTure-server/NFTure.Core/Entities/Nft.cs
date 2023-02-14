using NFTure.Core.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Core.Entities
{
    public class Nft : Entity<Guid>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        [MaxLength(1024)]
        public string? Description { get; set; }

        [Required]
        [Range(0, double.PositiveInfinity)]
        public double Price { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Guid CreatorId { get; set; }

        [Required]
        public DateTimeOffset? CreatedDateUtc { get; set; }
        public DateTimeOffset? LastUpdatedDateUtc { get; set; }

        public virtual User Creator { get; set; }

        public virtual User Owner { get; set; }
    }
}
