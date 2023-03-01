using System.ComponentModel.DataAnnotations;

namespace NFTure.Web.DTOs.NFT
{
    public class CreateNftRequest
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        [Range(0, double.PositiveInfinity)]
        public double Price { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public Guid CreatorId { get; set; }
    }
}
