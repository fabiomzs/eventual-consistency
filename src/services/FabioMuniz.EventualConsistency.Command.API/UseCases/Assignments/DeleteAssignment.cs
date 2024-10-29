using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class DeleteAssignment(ILogger<DeleteAssignment> logger, IAssignmentRepository assignmentRepository, IMessabeBus messabeBus)
{
	public async Task<bool> Handler(Guid id)
	{
		try
		{
			logger.LogInformation($"request delete assignment: {id}", id);
			var result = await assignmentRepository.DeleteAsync(id);

			if (result)
			{
				logger.LogInformation($"assignment deleted: {id}");

				var @event = new DeleteAssignmentEvent(id);

				logger.LogInformation($"send event to bus {id}", @event);
				await messabeBus.PublishAsync(@event);
			}
			else
				logger.LogWarning($"assignment not deleted: {id}");

			return result;
		}
		catch (Exception ex)
		{
			logger.LogError($"error deleting assignment: {id}", ex, ex.Message);

			throw ex;
		}
	}
}
