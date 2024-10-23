namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public record CompleteAssignmentRequest(Guid Id, bool Completed);