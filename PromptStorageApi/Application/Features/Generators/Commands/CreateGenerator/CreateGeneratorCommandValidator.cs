using FluentValidation;

namespace PromptStorageApi.Application.Features.Generators.Commands.CreateGenerator;

public sealed class CreateGeneratorCommandValidator : AbstractValidator<CreateGeneratorCommand>
{
    public CreateGeneratorCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200)
            .Must(name => name.Trim().Length > 0)
            .WithMessage("Name must not be whitespace.");

        RuleFor(x => x.WebsiteUrl)
            .MaximumLength(2048)
            .Must(BeValidUrl)
            .When(x => !string.IsNullOrWhiteSpace(x.WebsiteUrl))
            .WithMessage("WebsiteUrl must be a valid absolute URL (http/https).");
    }

    private static bool BeValidUrl(string? url)
        => Uri.TryCreate(url, UriKind.Absolute, out var uri)
           && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
}