namespace FabioMuniz.EventualConsistency.Blazor.Models;

public class AssignmentModel
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }

    public AssignmentModel(Guid id, string? description, bool completed, DateTime createdAt)
    {
        Id = id;
        Description = description;
        Completed = completed;
        CreatedAt = createdAt;
    }

    public AssignmentModel() { }
}