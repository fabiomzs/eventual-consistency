using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Command.API.Models;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class CreateAssignment(IAssignmentRepository assignmentRepository, IMessabeBus messabeBus)
{
	public async Task<Guid> Handler(CreateAssignmentRequest request)
	{
		Assignment assignment = new(request.Description);

		var id = await assignmentRepository.CreateAsync(assignment);

		var @event = new CreateAssignmentEvent(id, assignment.Description!, assignment.Completed, assignment.CreatedAt);

		await messabeBus.PublishAsync(@event);

		return id;
	}
}
