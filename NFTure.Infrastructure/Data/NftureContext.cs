using Microsoft.EntityFrameworkCore;
using NFTure.Core.Entities;

namespace NFTure.Infrastructure.Data
{
    public class NftureContext : DbContext
    {
        public NftureContext(DbContextOptions options) : base(options) { }

        public DbSet<Nft> Nfts { get; set; }
        public DbSet<ClientActivity> ClientActivities { get; set; }
    }
}
