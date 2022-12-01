using Microsoft.EntityFrameworkCore;
using NFTure.Core.Specifications.Base;

namespace NFTure.Core.Specifications
{
    public static class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria is not null)
            {
                _ = query.Where(spec.Criteria);
            }

            if (spec.OrderBy is not null)
            {
                // query = query.OrderBy(spec.OrderBy);
                _ = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending is not null)
            {
                _ = query.OrderByDescending(spec.OrderByDescending);
            }

            _ = spec.Includes.Aggregate(query, (current, include) => current.Include(include));

            return query;

        }
    }
}
