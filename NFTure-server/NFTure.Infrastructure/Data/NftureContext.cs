using Microsoft.EntityFrameworkCore;
using NFTure.Core;
using NFTure.Core.Entities;

namespace NFTure.Infrastructure.Data
{
    public class NftureContext : DbContext
    {
        public NftureContext(DbContextOptions options) : base(options) { }

        public DbSet<Nft> Nfts { get; set; }
        public DbSet<UserActivity> UserActivities { get; set; }
        public DbSet<ActivityType> ActivityTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActivityType>()
                .HasData(SeedEnumExtension.GetValuesFromEnum<ActivityType, UserActivityType>());

            // TODO: Add foreign key to ActivityType
        }
    }
}
