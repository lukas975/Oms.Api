using Microsoft.EntityFrameworkCore;
using Oms.Domain.Entities;
using Oms.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oms.Infrastructure.Repositories
{
    public class CmRepository : ICmRepository
    {
        private readonly OmsContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public CmRepository(OmsContext context)
        {
            _context = context ?? throw new
            ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Cm>> GetAsync()
        {
            return await _context
            .Cms
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<Cm> GetAsync(Guid id)
        {
            var cm = await _context.Cms
            .AsNoTracking()
            .Where(x => x.CmsId == id)
            .Include(x => x.Products)
            .Include(x => x.OrderDetails).FirstOrDefaultAsync();
            return cm;
        }
        public Cm Add(Cm cm)
        {
            return _context.Cms
            .Add(cm).Entity;
        }

        public Cm Update(Cm cm)
        {
            _context.Entry(cm).State = EntityState.Modified;
            return cm;
        }
        public Cm Delete(Cm cm) 
        {
            return _context.Cms.Remove(cm).Entity; 
        }

    }
}
