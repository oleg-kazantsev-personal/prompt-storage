namespace PromptStorageApi.Application.Features.Shows.Dtos;

public class PerformanceDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public DateTime? DateUtc { get; set; }  
    public List<SceneDto> Scenes { get; set; } = new();
}