using FluentValidation;

namespace Nexora.Application.Features.Tasks.Update;

public class UpdateTaskCommandValidator : AbstractValidator<UpdateTaskCommand>
{
    public UpdateTaskCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Description)
            .MaximumLength(1000);

        RuleFor(x => x.DueDate)
            .GreaterThan(DateTime.UtcNow);
    }
}