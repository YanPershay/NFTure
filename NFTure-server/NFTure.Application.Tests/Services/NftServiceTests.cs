using Moq;
using NFTure.Application.Services;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces;
using NFTure.Core.Interfaces.Repositories;

namespace NFTure.Application.Tests.Services
{
    public class NftServiceTests
    {
        private readonly Mock<INftRepository> _mockNftRepository;
        private readonly Mock<IAppLogger<NftService>> _mockAppLogger;
        private readonly Mock<IUserActivityService> _mockUserActivityService;
        private readonly NftService _nftService;

        public NftServiceTests()
        {
            _mockNftRepository = new Mock<INftRepository>();
            _mockAppLogger = new Mock<IAppLogger<NftService>>();
            _mockUserActivityService = new Mock<IUserActivityService>();
            _nftService = new NftService(
                _mockNftRepository.Object,
                _mockAppLogger.Object,
                _mockUserActivityService.Object);
        }

        // TODO: check activities creation

        [Theory]
        [MemberData(nameof(TestData.Nfts), MemberType = typeof(TestData))]
        public async Task GetNftsByOwnerIdAsync_UserIdAndNewNftEntities_ReturnsNftsWithUserId(Guid userId, List<Nft> nfts)
        {
            // Arrange
            _mockNftRepository.Setup(x => x.GetAllUserNftsAsync(It.IsAny<Guid>())).ReturnsAsync(nfts);

            // Act
            var result = await _nftService.GetNftsByOwnerIdAsync(userId);

            // Assert
            Assert.Equal(nfts.Count, result.Count());
        }

        [Theory]
        [MemberData(nameof(TestData.NewNft), MemberType = typeof(TestData))]
        public async Task AddNewNftAsync_NftModel_ReturnsCreatedEntities(Nft nft)
        {
            // Arrange
            Nft newNft = new Nft
            {
                ImageUrl = nft.ImageUrl,
                Description = nft.Description,
                Price = nft.Price,
                OwnerId = nft.OwnerId,
                CreatedDateUtc = DateTime.UtcNow,
            };

            _mockNftRepository.Setup(x => x.AddAsync(It.IsAny<Nft>())).ReturnsAsync(newNft);

            // Act

            var result = await _nftService.AddNewNftAsync(nft);

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(result.CreatedDateUtc);
            Assert.Equal(nft.ImageUrl, result.ImageUrl);
            Assert.Equal(nft.Price, result.Price);
            Assert.Equal(nft.Description, result.Description);
            Assert.Equal(nft.OwnerId, result.OwnerId);
        }

        [Fact]
        public async Task AddNewNftAsync_NullNft_ThrowsException()
        {
            // Arrange 
            Nft newNft = null;

            // Act
            var ex = await Record.ExceptionAsync(async () => await _nftService.AddNewNftAsync(newNft));

            // Assert
            Assert.NotNull(ex);
            Assert.IsType<ArgumentNullException>(ex);
        }

        private static class TestData
        {
            public static IEnumerable<object[]> NewNft =>
              new List<object[]>
              {
                  new object[]
                  {
                     new Nft
                     {
                         ImageUrl = "https://pic.nft.com",
                         Description = "Description",
                         Price = 300,
                         OwnerId = Guid.Parse("aacdae30-6f1f-4cbc-a015-a513d1ad10c0")
                     },
                  },
                  new object[]
                  {
                     new Nft
                     {
                         ImageUrl = "https://pic2.nft.com",
                         Description = "Description_2",
                         Price = 3100,
                         OwnerId = Guid.Parse("59205330-6f1f-4cbc-a015-a513d1ad10c0")
                     },
                  },
              };

            public static IEnumerable<object[]> Nfts =>
              new List<object[]>
              {
                  new object[]
                  {
                     Guid.Parse("aacdae30-6f1f-4cbc-a015-a513d1ad10c0"),
                     new List<Nft>
                     {
                         new Nft
                         {
                             Id = Guid.NewGuid(),
                             ImageUrl = "https://pic.nft.com",
                             Description = "Description",
                             Price = 300,
                             OwnerId = Guid.Parse("aacdae30-6f1f-4cbc-a015-a513d1ad10c0")
                         },
                         new Nft
                         {
                             Id = Guid.NewGuid(),
                             ImageUrl = "https://pic.nft.com",
                             Description = "Description",
                             Price = 300,
                             OwnerId = Guid.Parse("aacdae30-6f1f-4cbc-a015-a513d1ad10c0")
                         },
                     }
                  },
                  new object[]
                  {
                     Guid.Parse("47731937-9a0b-4550-b6ab-6ffb0f96d218"),
                     new List<Nft>
                     {
                         new Nft
                         {
                             Id = Guid.NewGuid(),
                             ImageUrl = "https://pic.nft.com",
                             Description = "Description",
                             Price = 300,
                             OwnerId = Guid.Parse("47731937-9a0b-4550-b6ab-6ffb0f96d218")
                         }
                     }
                  },
                  new object[]
                  {
                     Guid.Parse("8c1e3b9a-dfaf-437d-acc4-a430e37509d4"),
                     new List<Nft>{ }
                  }
              };
        }
    }
}
