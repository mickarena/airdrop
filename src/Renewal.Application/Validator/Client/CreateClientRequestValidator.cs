using FluentValidation;
using Renewal.Application.Models.Client;

namespace Renewal.Application.Validator
{
    public class CreateClientRequestValidator : AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(v => v.Name)
                .MaximumLength(250)
                .NotEmpty();
        }
    }
}
