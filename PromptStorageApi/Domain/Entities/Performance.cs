// Performance.cs

using PromptStorageApi.Domain.Common;

namespace PromptStorageApi.Domain.Entities;

public class Performance : AuditableEntity
{
    public required string Title { get; set; }
    public string? Description { get; set; }
    public DateTime? DateUtc { get; set; }
    public Guid ShowId { get; set; }
    public Show Show { get; set; } = null!;
    public ICollection<Scene> Scenes { get; set; } = new List<Scene>();
    internal Performance(Guid id) : base(id) { }
}