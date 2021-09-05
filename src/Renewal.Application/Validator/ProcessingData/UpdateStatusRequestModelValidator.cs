using FluentValidation;
using Renewal.Application.Models.ProcessingData;

namespace Renewal.Application.Validator.ProcessingData
{
    public class UpdateStatusRequestModelValidator : AbstractValidator<UpdateStatusRequestModel>, IModelValidator
    {
        public UpdateStatusRequestModelValidator()
        {
            RuleFor(m => m.PolicyReference)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdateStatusRequestModel.PolicyReference)));

            RuleFor(m => m.RenewalProcessStatus)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdateStatusRequestModel.RenewalProcessStatus)));

            RuleFor(m => m.RenewalProcessStatusDate)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdateStatusRequestModel.RenewalProcessStatusDate)));
        }
    }
}
