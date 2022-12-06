using NFTure.Core.Entities.Base;
using NFTure.Core.Specifications.Base;

namespace NFTure.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T, U> where T : Entity<U>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
    }
}
