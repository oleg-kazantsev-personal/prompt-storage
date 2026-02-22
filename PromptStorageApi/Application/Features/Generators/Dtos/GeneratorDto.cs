namespace PromptStorageApi.Application.Features.Generators.Dtos;

public class GeneratorDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    string? WebsiteUrl { get; set; } 

    public GeneratorDto(Guid id, string name, string? websiteUrl)
    {
        Id = id;
        Name = name;
        WebsiteUrl = websiteUrl;
    }
}