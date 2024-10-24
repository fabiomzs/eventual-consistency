namespace FabioMuniz.EventualConsistency.Core.Messages.Events;

public class CompleteAssignmentEvent : Event
{
    public Guid Id { get; set; }
    public bool Completed { get; set; }

    public CompleteAssignmentEvent(Guid id, bool completed)
    {
        Id = id;
        Completed = completed;
    }
}
