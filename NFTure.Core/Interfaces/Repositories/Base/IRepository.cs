using Hexagonal.Core.Entities.Base;

namespace NFTure.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T, U> where T : Entity<U>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        // Task<T> GetByIdAsync(U id);
    }
}
