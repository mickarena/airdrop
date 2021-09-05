using FluentValidation;
using Renewal.Application.Models.ProcessingData;

namespace Renewal.Application.Validator.ProcessingData
{
    public class UpdatePaymentTransactionRequestModelValidator : AbstractValidator<UpdatePaymentTransactionRequestModel>, IModelValidator
    {
        public UpdatePaymentTransactionRequestModelValidator()
        {
            RuleFor(m => m.PolicyReference)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdatePaymentTransactionRequestModel.PolicyReference)));

            RuleFor(m => m.RenewalProcessStatus)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdatePaymentTransactionRequestModel.RenewalProcessStatus)));

            RuleFor(m => m.RenewalProcessStatusDate)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdatePaymentTransactionRequestModel.RenewalProcessStatusDate)));
        }
    }
}
