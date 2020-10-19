using Oms.Domain.Entities;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Responses;

namespace Oms.Domain.Mappers
{
    public interface ICmMapper
    {
        Cm Map(AddCmRequest request);
        Cm Map(EditCmRequest request);
        CmResponse Map(Cm cm);
    }
}
