using FluentValidation;

namespace Oms.Domain.Requests.Cm.Validators
{
    public class AddCmRequestValidator : AbstractValidator<AddCmRequest>
    {
        public AddCmRequestValidator()
        {
            RuleFor(x => x.CmsId).NotEmpty();
            RuleFor(x => x.Products).NotEmpty();
        }
    }
}
