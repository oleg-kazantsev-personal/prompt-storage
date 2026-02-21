// Prompt.cs

using PromptStorageApi.Domain.Common;

namespace PromptStorageApi.Domain.Entities;

public class Prompt : AuditableEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public required string Body { get; set; }
    public string? Tags { get; set; }
    public Guid AIGeneratorId { get; set; }
    public AIGenerator AIGenerator { get; set; } = null!;
    public Guid SceneId { get; set; }
    public Scene Scene { get; set; } = null!;
}