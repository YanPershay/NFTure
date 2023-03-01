﻿using NFTure.Web.DTOs.Base;
using System.ComponentModel.DataAnnotations;

namespace NFTure.Web.DTOs.NFT
{
    public class NftResponse : Dto<Guid>
    {
        public string ImageUrl { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CreatorId { get; set; }
        public DateTimeOffset? CreatedDateUtc { get; set; }
    }
}
