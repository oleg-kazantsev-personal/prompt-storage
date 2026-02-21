// Show.cs

using PromptStorageApi.Domain.Common;

namespace PromptStorageApi.Domain.Entities;

public class Show : AuditableEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Performance> Performances { get; set; } = new List<Performance>();
}