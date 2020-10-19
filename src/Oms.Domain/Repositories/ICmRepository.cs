using Oms.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oms.Domain.Repositories
{
    public interface ICmRepository : IRepository
    {
        Task<IEnumerable<Cm>> GetAsync();
        Task<Cm> GetAsync(Guid id);
        Cm Add(Cm cm);
        Cm Update(Cm cm);
        Cm Delete(Cm cm);
    }
}
