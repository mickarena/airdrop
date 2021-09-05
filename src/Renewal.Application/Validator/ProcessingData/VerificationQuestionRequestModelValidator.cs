using FluentValidation;
using Renewal.Application.Common;
using Renewal.Application.Models.ProcessingData;

namespace Renewal.Application.Validator.ProcessingData
{
    public class VerificationQuestionRequestModelValidator : AbstractValidator<VerificationQuestionRequestModel> , IModelValidator
    {
        public VerificationQuestionRequestModelValidator()
        {
            RuleFor(m => m.FirstNames)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(VerificationQuestionRequestModel.FirstNames)));

            RuleFor(m => m.FirstNames.Length).LessThan(31).When(m => !string.IsNullOrEmpty(m.FirstNames))
                .WithMessage(ValidationMessage.MaximumLength(nameof(VerificationQuestionRequestModel.FirstNames), 30));

            RuleFor(m => m.FirstNames.Length).GreaterThan(1).When(m => !string.IsNullOrEmpty(m.FirstNames))
                .WithMessage(ValidationMessage.MinimumLength(nameof(VerificationQuestionRequestModel.FirstNames), 2));

            RuleFor(model => model.FirstNames)
                .Matches(Constants.CommonPattern.NamePersonPattern)
                .When(x => !string.IsNullOrEmpty(x.FirstNames))
                .WithMessage(ValidationMessage.Invalid(nameof(VerificationQuestionRequestModel.FirstNames)));

            RuleFor(m => m.Surname)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(VerificationQuestionRequestModel.Surname)));

            RuleFor(m => m.Surname.Length).LessThan(21).When(m => !string.IsNullOrEmpty(m.Surname))
                .WithMessage(ValidationMessage.MaximumLength(nameof(VerificationQuestionRequestModel.Surname), 20));

            RuleFor(m => m.Surname.Length).GreaterThan(1).When(m => !string.IsNullOrEmpty(m.Surname))
                .WithMessage(ValidationMessage.MinimumLength(nameof(VerificationQuestionRequestModel.Surname), 2));

            RuleFor(model => model.Surname)
                .Matches(Constants.CommonPattern.NamePersonPattern)
                .When(x => !string.IsNullOrEmpty(x.Surname))
                .WithMessage(ValidationMessage.Invalid(nameof(VerificationQuestionRequestModel.Surname)));

            RuleFor(m => m.EmailAddress)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(VerificationQuestionRequestModel.EmailAddress)));

            RuleFor(m => m.EmailAddress.Length).LessThan(61).When(m => !string.IsNullOrEmpty(m.EmailAddress))
                .WithMessage(ValidationMessage.MaximumLength(nameof(VerificationQuestionRequestModel.EmailAddress), 60));

            RuleFor(model => model.EmailAddress)
                .Matches(Constants.CommonPattern.EmailPattern)
                .When(x => !string.IsNullOrEmpty(x.EmailAddress))
                .WithMessage(ValidationMessage.Invalid(nameof(VerificationQuestionRequestModel.EmailAddress)));

            RuleFor(m => m.PolicyReference)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(VerificationQuestionRequestModel.PolicyReference)));

            RuleFor(m => m.PolicyReference.Length).LessThan(51).When(m => !string.IsNullOrEmpty(m.PolicyReference))
               .WithMessage(ValidationMessage.MaximumLength(nameof(VerificationQuestionRequestModel.PolicyReference), 50));

            RuleFor(m => m.BirthDate)
                .NotEmpty().WithMessage(ValidationMessage.Required(nameof(VerificationQuestionRequestModel.BirthDate)));
        }
    }
}
