using FluentValidation;
using Renewal.Application.Models.ProcessingData;

namespace Renewal.Application.Validator.ProcessingData
{
    public class UpdatePaymentMethodRequestModelValidator : AbstractValidator<UpdatePaymentMethodRequestModel>, IModelValidator
    {
        public UpdatePaymentMethodRequestModelValidator()
        {
            RuleFor(m => m.PolicyReference)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdatePaymentMethodRequestModel.PolicyReference)));

            RuleFor(m => m.PaymentMethod)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdatePaymentMethodRequestModel.PaymentMethod)));
        }
    }
}
