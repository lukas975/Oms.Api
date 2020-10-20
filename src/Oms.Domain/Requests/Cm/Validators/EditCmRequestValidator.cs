using FluentValidation;

namespace Oms.Domain.Requests.Cm.Validators
{
    public class EditCmRequestValidator : AbstractValidator<EditCmRequest>
    {
        public EditCmRequestValidator()
        {
            RuleFor(x => x.CmsId).NotEmpty();
            RuleFor(x => x.Products).NotEmpty();
        }
    }
}
