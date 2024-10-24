using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class DeleteAssignment(IAssignmentRepository assignmentRepository, IMessabeBus messabeBus)
{
	public async Task<bool> Handler(Guid id)
	{
		var result = await assignmentRepository.DeleteAsync(id);

		var @event = new DeleteAssignmentEvent(id);

		await messabeBus.PublishAsync(@event);

		return result;
	}
}
