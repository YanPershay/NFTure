using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NFTure.Core.Entities;

namespace NFTure.Infrastructure.Data
{
    public class NftureContextSeed
    {
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
                OwnerId = Guid.NewGuid(),
                CreatedDateUtc = DateTime.UtcNow,
            },
            new Nft
            {
                Id = Guid.NewGuid(),
                ImageUrl = "https://cloud2.image2.nft2.com/new/nft",
                Description = "2nd base NFT data",
                OwnerId = Guid.NewGuid(),
                CreatedDateUtc = DateTime.UtcNow,
            }
        };
    }


}
