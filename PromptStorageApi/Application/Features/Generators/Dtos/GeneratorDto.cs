namespace PromptStorageApi.Application.Features.Generators.Dtos;

public class GeneratorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? WebsiteUrl { get; set; }
}