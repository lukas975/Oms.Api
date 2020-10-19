using Oms.Domain.Mappers;
using Oms.Domain.Repositories;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oms.Domain.Services
{
    public class CmService : ICmService
    {
        private readonly ICmRepository _cmRepository;
        private readonly ICmMapper _cmMapper;

        public CmService(ICmRepository cmRepository, ICmMapper cmMapper)
        {
            _cmRepository = cmRepository;
            _cmMapper = cmMapper;
        }

        public async Task<IEnumerable<CmResponse>> GetCmsAsync()
        {
            var result = await _cmRepository.GetAsync();

            return result.Select(x => _cmMapper.Map(x));
        }

        public async Task<CmResponse> GetCmAsync(GetCmRequest request)
        {
            if (request?.CmsId == null) 
                throw new ArgumentNullException();

            var entity = await _cmRepository.GetAsync(request.CmsId);

            return _cmMapper.Map(entity);
        }

        public async Task<CmResponse> AddCmAsync(AddCmRequest request)
        {
            var cm = _cmMapper.Map(request);

            var result = _cmRepository.Add(cm);

            await _cmRepository.UnitOfWork.SaveChangesAsync();

            return _cmMapper.Map(result);

        }

        public async Task<CmResponse> EditCmAsync(EditCmRequest request)
        {
            var existingRecord = await _cmRepository.GetAsync(request.CmsId);

            if (existingRecord == null)
            {
                throw new ArgumentException($"Entity with {request.CmsId} is not present");
            }

            var entity = _cmMapper.Map(request);

            var result = _cmRepository.Update(entity);

            await _cmRepository.UnitOfWork.SaveChangesAsync();

            return _cmMapper.Map(result);
        }

        

        
    }
}
