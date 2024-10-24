using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class CompleteAssignment(IAssignmentRepository assignmentRepository, IMessabeBus messabeBus)
{
	public async Task<bool> Handler(CompleteAssignmentRequest request)
	{
		var result = await assignmentRepository.UpdateAsync(request.Id, request.Completed);

		var @event = new CompleteAssignmentEvent(request.Id, request.Completed);

		await messabeBus.PublishAsync(@event);

		return result;
	}
}
