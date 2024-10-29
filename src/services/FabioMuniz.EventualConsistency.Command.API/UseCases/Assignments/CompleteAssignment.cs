using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class CompleteAssignment(ILogger<CompleteAssignment> logger, IAssignmentRepository assignmentRepository, IMessabeBus messabeBus)
{
	public async Task<bool> Handler(CompleteAssignmentRequest request)
	{

		try
		{
			logger.LogInformation($"request update assignment: {request.Id}", request);
			var result = await assignmentRepository.UpdateAsync(request.Id, request.Completed);

			if (result)
			{
				logger.LogInformation($"assignment updated: {request}");

				var @event = new CompleteAssignmentEvent(request.Id, request.Completed);

				logger.LogInformation($"send event to bus {request.Id}", @event);
				await messabeBus.PublishAsync(@event);
			}
			else
				logger.LogWarning($"assignment not updated: {request}");

			return result;
		}
		catch (Exception ex)
		{
			logger.LogError($"error updating assignment: {request.Id}", ex, ex.Message);

			throw ex;
		}
	}
}
