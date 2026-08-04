using FluentValidation;
using Nexora.Application.Features.Comments.Create;

namespace Nexora.Application.Validators;

public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
{
    public CreateCommentCommandValidator()
    {
        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.TaskId)
            .NotEmpty();
    }
}