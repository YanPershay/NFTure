using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NFTure.Application;
using NFTure.Core;
using NFTure.Core.Entities;

namespace NFTure.Infrastructure.Data
{
    public class NftureContextSeed
    {
        private static Guid clientId1 = Guid.NewGuid();
        private static Guid clientId2 = Guid.NewGuid();

        public static async Task SeedAsync(NftureContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Nfts.Any())
                {
                    context.Nfts.AddRange(GetPreconfiguredNfts());
                    await context.SaveChangesAsync();
                }

                if (!context.ClientActivities.Any())
                {
                    context.ClientActivities.AddRange(GetPreconfiguredClientActivities());
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<NftureContextSeed>();
                    log.LogError(ex.Message);
                    await SeedAsync(context, loggerFactory, retry);
                }
                throw;
            }
        }

        private static IEnumerable<Nft> GetPreconfiguredNfts() =>
        new List<Nft>
        {
            new Nft
            {
                Id = Guid.NewGuid(),
                ImageUrl = "https://cloud.image.nft.com",
                Description = "1st base NFT data",
                OwnerId = clientId1,
                CreatedDateUtc = DateTime.UtcNow,
            },
            new Nft
            {
                Id = Guid.NewGuid(),
                ImageUrl = "https://cloud2.image2.nft2.com/new/nft",
                Description = "2nd base NFT data",
                OwnerId = clientId2,
                CreatedDateUtc = DateTime.UtcNow,
            }
        };

        private static IEnumerable<ClientActivity> GetPreconfiguredClientActivities() =>
        new List<ClientActivity>
        {
            new ClientActivity
            {
                Action = ClientActivityAction.AddedNewNft.GetDescription(),
                ActivityType = ClientActivityType.Added,
                UserId = clientId1,
                CreatedDateUtc = DateTimeOffset.UtcNow,
                EntityType = typeof(Nft).Name
            },
            new ClientActivity
            {
                Action = ClientActivityAction.NftUpdated.GetDescription(),
                ActivityType = ClientActivityType.Updated,
                UserId = clientId2,
                CreatedDateUtc = DateTimeOffset.UtcNow,
                EntityType = typeof(Nft).Name
            }
        };
    }


}
