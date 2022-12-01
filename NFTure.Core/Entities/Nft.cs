﻿using Hexagonal.Core.Entities.Base;

namespace NFTure.Core.Entities
{
    public class Nft : Entity<Guid>
    {
        //public Nft() { }

        public string ImageUrl { get; set; }
        public string? Description { get; set; }
        public double Price { get; set; }
        public Guid OwnerId { get; set; }

        // public virtual User User { get; set; }

    }
}
