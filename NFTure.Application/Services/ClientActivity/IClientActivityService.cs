using NFTure.Core.Entities;

namespace NFTure.Application.Services
{
    public interface IClientActivityService
    {
        Task<IEnumerable<ClientActivity>> GetUserClientActivitiesAsync(Guid userId);
    }
}
