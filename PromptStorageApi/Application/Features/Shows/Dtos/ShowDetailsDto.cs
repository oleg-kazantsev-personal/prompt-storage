namespace PromptStorageApi.Application.Features.Shows.Dtos;

public class ShowDetailsDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public List<PerformanceDto> Performances { get; set; } = new();
}
