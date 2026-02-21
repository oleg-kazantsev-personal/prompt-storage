namespace PromptStorageApi.Domain.Common;

public abstract class EntityBase
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public DateTime CreatedAtUtc { get; set; }
    public DateTime UpdatedAtUtc { get; set; }
}