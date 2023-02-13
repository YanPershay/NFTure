using NFTure.Core;
using NFTure.Core.Entities;
using NFTure.Core.Interfaces.Repositories;

namespace NFTure.Application.Services
{
    public class UserActivityService : IUserActivityService
    {
        private readonly IUserActivityRepository _repository;

        public UserActivityService(IUserActivityRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<UserActivity>> GetUserActivitiesAsync(Guid userId) =>
            await _repository.GetByUserIdAsync(userId);

        public async Task CreateUserActivityAsync(
            UserActivityAction action,
            UserActivityType type,
            Guid userId,
            Type entityType)
        {
            var activity = new UserActivity
            {
                Action = action.GetDescription(),
                ActivityTypeId = type,
                UserId = userId,
                EntityType = entityType.Name,
                CreatedDateUtc = DateTime.UtcNow,
            };

            await _repository.AddAsync(activity);
        }
    }
}
