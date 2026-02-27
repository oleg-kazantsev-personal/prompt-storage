namespace Application.Features.Shows.Dtos;

public class SceneDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public int Order { get; set; }
}