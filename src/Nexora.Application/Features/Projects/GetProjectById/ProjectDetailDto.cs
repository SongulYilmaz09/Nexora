namespace Nexora.Application.Features.Projects.GetProjectById;

public class ProjectDetailDto
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public bool IsCompleted { get; set; }

    public Guid OwnerId { get; set; }

    public DateTime CreatedAt { get; set; }
}