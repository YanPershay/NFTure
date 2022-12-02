using NFTure.Web.DTOs.Base;

namespace NFTure.Web.DTOs
{
    public class NftDto : Dto<Guid>
    {
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid OwnerId { get; set; }
    }
}
