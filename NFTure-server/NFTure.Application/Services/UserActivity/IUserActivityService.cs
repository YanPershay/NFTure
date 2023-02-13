using NFTure.Core;
using NFTure.Core.Entities;

namespace NFTure.Application.Services
{
    public interface IUserActivityService
    {
        Task<IEnumerable<UserActivity>> GetUserActivitiesAsync(Guid userId);
        Task CreateUserActivityAsync(UserActivityAction action, UserActivityType type, Guid userId, Type entityType);
    }
}
