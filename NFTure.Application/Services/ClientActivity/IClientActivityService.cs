using NFTure.Core;
using NFTure.Core.Entities;

namespace NFTure.Application.Services
{
    public interface IClientActivityService
    {
        Task<IEnumerable<ClientActivity>> GetUserClientActivitiesAsync(Guid userId);
        Task CreateClientActivityAsync(ClientActivityAction action, ClientActivityType type, Guid userId, Type entityType);
    }
}
