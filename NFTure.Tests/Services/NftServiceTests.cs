using Moq;
using NFTure.Application.Services;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces;
using NFTure.Core.Interfaces.Repositories;
using NFTure.Core.Interfaces.Repositories.Base;
using System;

namespace NFTure.Application.Tests.Services
{
    internal class NftServiceTests
    {
        private Mock<INftRepository> _mockNftRepository;
        private Mock<IRepository<Nft, Guid>> _mockRepository;
        private Mock<IAppLogger<NftService>> _mockAppLogger;
        private Mock<IClientActivityService> _mockClientActivityService;

        public NftServiceTests()
        {
            _mockNftRepository = new Mock<INftRepository>();
            _mockRepository = new Mock<IRepository<Nft, Guid>>();
            _mockAppLogger = new Mock<IAppLogger<NftService>>();
            _mockClientActivityService = new Mock<IClientActivityService>();
        }

        private static class TestData
        {
            public static IEnumerable<object[]> ObjectDataExample =>
              new List<object[]>
              {
                  new object[]
                  {
                     new Nft { },
                  },
                  new object[]
                  {
                     new Nft { },
                  }
                  // e.g.: Method(Nft nft)
              };

            public static IEnumerable<object[]> MultiObjectsDataExample =>
                new List<object[]>
                {
                    new object[]
                    {
                        new Nft(),
                        new ClientActivity()
                        // e.g.: Method(Nft nft, ClientActivity activity)
                    }
                };
        }
    }
}
