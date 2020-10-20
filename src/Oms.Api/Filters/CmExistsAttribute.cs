using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Services;
using System.Threading.Tasks;

namespace Oms.Api.Filters
{
    public class CmExistsAttribute : TypeFilterAttribute
    {
        public CmExistsAttribute() : base(typeof(CmExistsFilterImpl))
        {
        }

        public class CmExistsFilterImpl : IAsyncActionFilter
        {
            private readonly ICmService _cmService;

            public CmExistsFilterImpl(ICmService cmService)
            {
                _cmService = cmService;
            }

            public async Task OnActionExecutionAsync(ActionExecutingContext context,  ActionExecutionDelegate next)
            {
                if (!(context.ActionArguments["id"] is string id))
                {
                    context.Result = new BadRequestResult();
                    return;
                }

                var result = await _cmService.GetCmAsync(new GetCmRequest{ CmsId = id });
                if (result == null)
                {
                    context.Result = new NotFoundObjectResult($"Item with id { id } not exist.");

                    return;
                }
                await next();
            }
        }
    }
}
