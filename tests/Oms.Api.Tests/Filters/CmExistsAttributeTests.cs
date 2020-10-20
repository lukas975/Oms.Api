using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Moq;
using Oms.Api.Filters;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Responses;
using Oms.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Oms.Api.Tests.Filters
{
    public class CmExistsAttributeTests
    {
        [Fact]
        public async Task should_continue_pipeline_when_id_is_present()
        {
            var id = "1000";

            var cmService = new Mock<ICmService>();

            cmService
                .Setup(x => x.GetCmAsync(It.IsAny<GetCmRequest>()))
                .ReturnsAsync(new CmResponse { CmsId = id });

            var filter = new CmExistsAttribute.CmExistsFilterImpl(cmService.Object);

            var actionExecutedContext = new ActionExecutingContext(
                new ActionContext(new DefaultHttpContext(), new RouteData(), new ActionDescriptor()),
                new List<IFilterMetadata>(), new Dictionary<string, object>{ {"id", id} }, new object());

            var nextCallback = new Mock<ActionExecutionDelegate>();
            
            await filter.OnActionExecutionAsync(actionExecutedContext,  nextCallback.Object);

            nextCallback.Verify(executionDelegate => executionDelegate(), Times.Once);
        }
    }
}
