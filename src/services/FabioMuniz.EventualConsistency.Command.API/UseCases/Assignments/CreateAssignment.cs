using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Command.API.Models;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class CreateAssignment(ILogger<CreateAssignment> logger, IAssignmentRepository assignmentRepository, IMessabeBus messabeBus)
{
	public async Task<Guid> Handler(CreateAssignmentRequest request)
	{
		Assignment assignment = new(request.Description);

		try
		{
			logger.LogInformation("request create assignment", request);
			var id = await assignmentRepository.CreateAsync(assignment);

			if (id != Guid.Empty)
			{
				logger.LogInformation($"assignment created: {request}", request);

				var @event = new CreateAssignmentEvent(id, assignment.Description!, assignment.Completed, assignment.CreatedAt);

				logger.LogInformation($"send event to bus {id}", @event);
				await messabeBus.PublishAsync(@event);
			}
			else
				logger.LogWarning($"assignment not created: {request}");

			return id;
		}
		catch (Exception ex)
		{
			logger.LogError($"error creating assignment: {request}", ex, ex.Message);

			throw ex;
		}

	}
}
