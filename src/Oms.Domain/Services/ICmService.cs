using Oms.Domain.Requests.Cm;
using Oms.Domain.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Oms.Domain.Services
{
    public interface ICmService
    {
        Task<IEnumerable<CmResponse>> GetCmAsync();
        Task<CmResponse> GetCmAsync(GetCmRequest request);
        Task<CmResponse> AddCmAsync(AddCmRequest request);
        Task<CmResponse> EditCmAsync(EditCmRequest request);
        //Task<CmResponse> DeleteItemAsync(DeleteCmRequest request);

    }
}
