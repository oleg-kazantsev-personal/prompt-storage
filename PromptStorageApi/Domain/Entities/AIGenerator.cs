// AIGenerator.cs

using PromptStorageApi.Domain.Common;

namespace PromptStorageApi.Domain.Entities;

public class AIGenerator : AuditableEntity
{
    public required string Name { get; set; }
    public string? WebsiteUrl { get; set; }
    public ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
    internal AIGenerator(Guid id) : base(id) { }
}