﻿using Microsoft.EntityFrameworkCore;
using NFTure.Core.Entities.Base;
using NFTure.Core.Interfaces.Repositories.Base;
using NFTure.Core.Specifications;
using NFTure.Core.Specifications.Base;
using NFTure.Infrastructure.Data;
using System.Linq.Expressions;

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

        public async Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> specification) => 
            SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}
