namespace FabioMuniz.EventualConsistency.Core.Messages.Events;

public class DeleteAssignmentEvent : Event
{
    public Guid Id { get; set; }

    public DeleteAssignmentEvent(Guid id)
    {
        Id = id;
    }
}
