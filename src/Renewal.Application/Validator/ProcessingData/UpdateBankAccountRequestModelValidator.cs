using FluentValidation;
using Renewal.Application.Models.ProcessingData;

namespace Renewal.Application.Validator.ProcessingData
{
    public class UpdateBankAccountRequestModelValidator : AbstractValidator<UpdateBankAccountRequestModel>, IModelValidator
    {
        public UpdateBankAccountRequestModelValidator()
        {
            RuleFor(m => m.PolicyReference)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(UpdateBankAccountRequestModel.PolicyReference)));
        }
    }
}
