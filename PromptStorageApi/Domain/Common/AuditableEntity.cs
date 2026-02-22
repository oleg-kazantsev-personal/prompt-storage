namespace PromptStorageApi.Domain.Common;

public abstract class AuditableEntity : EntityBase
{
    public required string CreatedBy { get; set; }
    public required string UpdatedBy { get; set; }
    public byte[] RowVersion { get; set; } = default!;
    internal AuditableEntity(Guid id) : base(id) { }
}