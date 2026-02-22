// Scene.cs

using PromptStorageApi.Domain.Common;

namespace PromptStorageApi.Domain.Entities;

public class Scene : AuditableEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public int Order { get; set; }
    public Guid PerformanceId { get; set; }
    public Performance Performance { get; set; } = null!;
    public ICollection<Prompt> Prompts { get; set; } = new List<Prompt>();
    internal Scene(Guid id) : base(id) { }
}