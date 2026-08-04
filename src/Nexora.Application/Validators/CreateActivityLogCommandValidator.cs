using FluentValidation;
using Nexora.Application.Features.ActivityLogs.Create;

namespace Nexora.Application.Validators;

public class CreateActivityLogCommandValidator
    : AbstractValidator<CreateActivityLogCommand>
{
    public CreateActivityLogCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.Action)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.EntityName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.EntityId)
            .NotEmpty();
    }
}