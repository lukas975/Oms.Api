using FluentValidation.TestHelper;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Requests.Cm.Validators;
using Xunit;

namespace Oms.Domain.Tests.Requests.Cm.Validators
{
    public class AddCmRequestValidatorTests
    {
        private readonly AddCmRequestValidator _validator;

        public AddCmRequestValidatorTests()
        {
            _validator = new AddCmRequestValidator();
        }

        [Fact]
        public void should_have_error_when_CmsId_is_null()
        {
            var addCmRequest = new AddCmRequest();
            
            _validator.ShouldHaveValidationErrorFor(x => x.CmsId, addCmRequest);
        }

        [Fact]
        public void should_have_error_when_Products_is_null()
        {
            var addCmRequest = new AddCmRequest();

            _validator.ShouldHaveValidationErrorFor(x => x.Products, addCmRequest);
        }

    }
}
