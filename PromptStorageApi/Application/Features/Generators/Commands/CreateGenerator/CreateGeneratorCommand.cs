using MediatR;

namespace PromptStorageApi.Application.Features.Generators.Commands.CreateGenerator;

public class CreateGeneratorCommand : IRequest<int>
{
    public string Name { get; set; }
    public string? WebsiteUrl { get; set; }

    public CreateGeneratorCommand(string name, string? websiteUrl = null)
    {
        Name = name;
        WebsiteUrl = websiteUrl;
    }
}
