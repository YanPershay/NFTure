using NFTure.Core.Entities;
using NFTure.Core.Interfaces;
using NFTure.Core.Interfaces.Repositories;

namespace NFTure.Application.Services
{
    public class ClientActivityService : IClientActivityService
    {
        private readonly IClientActivityRepository _repository;
        private readonly IAppLogger<ClientActivityService> _logger;

        public ClientActivityService(IClientActivityRepository repository, IAppLogger<ClientActivityService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<ClientActivity>> GetUserClientActivitiesAsync(Guid userId) =>
            await _repository.GetActivitiesByUserIdAsync(userId);
    }
}
