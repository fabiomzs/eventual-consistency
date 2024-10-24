namespace FabioMuniz.EventualConsistency.Core.Messages.Events;

public class CreateAssignmentEvent : Event
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public bool Completed { get; set; }
    public DateTime CreatedAt { get; set; }

    public CreateAssignmentEvent(Guid id, string description, bool completed, DateTime createdAt)
    {
        Id = id;
        Description = description;
        Completed = completed;
        CreatedAt = createdAt;
    }
}
