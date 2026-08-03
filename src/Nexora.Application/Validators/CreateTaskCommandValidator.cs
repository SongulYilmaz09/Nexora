using FluentValidation;
using Nexora.Application.Features.Tasks.Create;

namespace Nexora.Application.Validators;

public class CreateTaskCommandValidator
    : AbstractValidator<CreateTaskCommand>
{
    public CreateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(500);

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Due date must be in the future.");

        RuleFor(x => x.ProjectId)
            .NotEmpty();
    }
}