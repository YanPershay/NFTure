using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NFTure.Application;
using NFTure.Core;
using NFTure.Core.Entities;

namespace NFTure.Infrastructure.Data
{
    public class NftureContextSeed
    {
        private static Guid clientId1 = Guid.Parse("4BE4DDC6-4200-411E-AB54-76975A915CC8");
        private static Guid clientId2 = Guid.Parse("8A6D711F-E502-4399-B66E-B3E6FAE266AD");

        public static async Task SeedAsync(NftureContext context, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {
                context.Database.Migrate();
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    context.Users.AddRange(GetPreconfiguredUsers());
                    await context.SaveChangesAsync();
                }

                if (!context.UsersInfo.Any())
                {
                    context.UsersInfo.AddRange(GetPreconfiguredUsersInfo());
                    await context.SaveChangesAsync();
                }

                if (!context.Nfts.Any())
                {
                    context.Nfts.AddRange(GetPreconfiguredNfts());
                    await context.SaveChangesAsync();
                }

                if (!context.UserActivities.Any())
                {
                    context.UserActivities.AddRange(GetPreconfiguredUserActivities());
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
                Name = "First NFT",
                Description = "1st base NFT data",
                OwnerId = clientId1,
                CreatorId = clientId1,
                CreatedDateUtc = DateTime.UtcNow,
                Price = 300
            },
            new Nft
            {
                Id = Guid.NewGuid(),
                ImageUrl = "https://cloud2.image2.nft2.com/new/nft",
                Name = "Second NFT",
                Description = "2nd base NFT data",
                OwnerId = clientId2,
                CreatorId = clientId1,
                CreatedDateUtc = DateTime.UtcNow,
                Price = 400
            }
        };

        private static IEnumerable<UserActivity> GetPreconfiguredUserActivities() =>
        new List<UserActivity>
        {
            new UserActivity
            {
                Action = UserActivityAction.AddedNewNft.GetDescription(),
                ActivityTypeId = UserActivityType.Added,
                UserId = clientId1,
                CreatedDateUtc = DateTimeOffset.UtcNow,
                EntityType = typeof(Nft).Name
            },
            new UserActivity
            {
                Action = UserActivityAction.NftUpdated.GetDescription(),
                ActivityTypeId = UserActivityType.Updated,
                UserId = clientId2,
                CreatedDateUtc = DateTimeOffset.UtcNow,
                EntityType = typeof(Nft).Name
            }
        };

        private static IEnumerable<UserInfo> GetPreconfiguredUsersInfo() =>
        new List<UserInfo>
        {
            new UserInfo
            {
                UserId = clientId1,
                FirstName = "Patrick",
                LastName = "Bateman",
                AvatarUrl = "http://",
                IsVerified = false
            },
            new UserInfo
            {
                UserId = clientId2,
                FirstName = "Tyler",
                LastName = "Derden",
                AvatarUrl = "https://",
                IsVerified = false
            },
        };

        private static IEnumerable<User> GetPreconfiguredUsers() =>
        new List<User>
        {
            new User
            {
                Id = clientId1,
                Username = "pat_bateman",
                Email = "@p.bateman@gmail.com",
                Password = "1234567"
            },
            new User
            {
                Id = clientId2,
                Username = "derden",
                Email = "@t.derden@gmail.com",
                Password = "7654321"
            },
        };
    }


}
