using NFTure.Core;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;

namespace NFTure.Application.Services
{
    public class ClientActivityService : IClientActivityService
    {
        private readonly IClientActivityRepository _repository;

        public ClientActivityService(IClientActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClientActivity>> GetUserClientActivitiesAsync(Guid userId) =>
            await _repository.GetByUserIdAsync(userId);

        public async Task CreateClientActivityAsync(
            ClientActivityAction action,
            ClientActivityType type,
            Guid userId,
            Type entityType)
        {
            var activity = new ClientActivity
            {
                Action = action.GetDescription(),
                ActivityType = type,
                UserId = userId,
                EntityType = entityType.Name,
                CreatedDateUtc = DateTime.UtcNow,
            };

            await _repository.AddAsync(activity);
        }
    }
}
