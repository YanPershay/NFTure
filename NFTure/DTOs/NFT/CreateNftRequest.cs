namespace NFTure.Web.DTOs.NFT
{
    public class CreateNftRequest
    {
        public string ImageUrl { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid OwnerId { get; set; }
    }
}
