using Microsoft.EntityFrameworkCore;
using NFTure.Core.Entities.Base;
using NFTure.Core.Interfaces.Repositories.Base;
using NFTure.Core.Specifications;
using NFTure.Core.Specifications.Base;
using NFTure.Infrastructure.Data;

namespace NFTure.Infrastructure.Repositories.Base
{
    public class Repository<T, U> : IRepository<T, U> where T : Entity<U>
    {
        protected readonly NftureContext _context;

        public Repository(NftureContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec) => await ApplySpecification(spec).ToListAsync();

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) => 
            SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}
