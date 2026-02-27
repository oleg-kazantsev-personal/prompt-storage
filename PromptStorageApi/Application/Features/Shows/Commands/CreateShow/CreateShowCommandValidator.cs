using FluentValidation;

namespace PromptStorageApi.Application.Features.Shows.Commands.CreateShow;

public sealed class CreateShowCommandValidator : AbstractValidator<CreateShowCommand>
{
    public CreateShowCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(120)
            .Must(name => name.Trim().Length > 0)
            .WithMessage("Name must not be whitespace.");

        RuleFor(x => x.Description)
            .MaximumLength(1000)
            .Must(description => description == null || description.Trim().Length > 0)
            .WithMessage("Description must not be whitespace.");
    }
}