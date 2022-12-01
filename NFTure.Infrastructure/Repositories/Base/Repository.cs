using Hexagonal.Core.Entities.Base;
using Microsoft.EntityFrameworkCore;
using NFTure.Core.Interfaces.Repositories.Base;
using NFTure.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFTure.Infrastructure.Repositories.Base
{
    public class Repository<T, U> : IRepository<T, U> where T : Entity<U>
    {
        protected readonly NftureContext _context;

        public Repository(NftureContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
    }
}
