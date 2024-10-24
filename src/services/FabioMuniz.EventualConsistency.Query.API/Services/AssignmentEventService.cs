using FabioMuniz.EventualConsistency.Core.Extensions;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Query.API.Services;

public class AssignmentEventService(IMessabeBus messageBus) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		await messageBus.SubscribeAsync<CreateAssignmentEvent>(nameof(CreateAssignmentEvent).ToKebab(), async (message) => await CreateAssignmentHandler(message));
		await messageBus.SubscribeAsync<CompleteAssignmentEvent>(nameof(CompleteAssignmentEvent).ToKebab(), async (message) => await CompleteAssignmentHandler(message));
		await messageBus.SubscribeAsync<DeleteAssignmentEvent>(nameof(DeleteAssignmentEvent).ToKebab(), async (message) => await DeleteAssignmentHandler(message));
	}

	async Task CreateAssignmentHandler(CreateAssignmentEvent message)
	{
		Console.WriteLine(message.Id + "----" + message.Description);		
	}

	async Task CompleteAssignmentHandler(CompleteAssignmentEvent message)
	{
		Console.WriteLine(message.Id);
	}

	async Task DeleteAssignmentHandler(DeleteAssignmentEvent message)
	{
		Console.WriteLine(message.Id);
	}
}
