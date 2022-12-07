using NFTure.Core.Entities.Base;
using NFTure.Core.Specifications.Base;
using System.Linq.Expressions;

namespace NFTure.Core.Interfaces.Repositories.Base
{
    public interface IRepository<T, U> where T : Entity<U>
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T newEntity);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
