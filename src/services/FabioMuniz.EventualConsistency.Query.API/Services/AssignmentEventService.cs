using FabioMuniz.EventualConsistency.Core.Extensions;
using FabioMuniz.EventualConsistency.Core.Messages.Events;
using FabioMuniz.EventualConsistency.MessageBus;
using FabioMuniz.EventualConsistency.Query.API.Data;
using FabioMuniz.EventualConsistency.Query.API.Models;

namespace FabioMuniz.EventualConsistency.Query.API.Services;

public class AssignmentEventService(IMessabeBus messageBus, IServiceProvider serviceProvider) : BackgroundService
{
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		await messageBus.SubscribeAsync<CreateAssignmentEvent>(nameof(CreateAssignmentEvent).ToKebab(), async (message) => await CreateAssignmentHandler(message));
		await messageBus.SubscribeAsync<CompleteAssignmentEvent>(nameof(CompleteAssignmentEvent).ToKebab(), async (message) => await CompleteAssignmentHandler(message));
		await messageBus.SubscribeAsync<DeleteAssignmentEvent>(nameof(DeleteAssignmentEvent).ToKebab(), async (message) => await DeleteAssignmentHandler(message));
	}

	async Task CreateAssignmentHandler(CreateAssignmentEvent message)
	{
		using var scope = serviceProvider.CreateScope();

		var assignmentRepository = scope.ServiceProvider.GetRequiredService<IAssignmentRepository>();

		var assignment = new Assignment(message.Id, message.Description, message.Completed, message.CreatedAt);

		await assignmentRepository.CreateAsync(assignment);

	}

	async Task CompleteAssignmentHandler(CompleteAssignmentEvent message)
	{
		using var scope = serviceProvider.CreateScope();

		var assignmentRepository = scope.ServiceProvider.GetService<IAssignmentRepository>();

		await assignmentRepository.UpdateAsync(message.Id, message.Completed);

		Console.WriteLine(message.Id);
	}

	async Task DeleteAssignmentHandler(DeleteAssignmentEvent message)
	{
		using var scope = serviceProvider.CreateScope();

		var assignmentRepository = scope.ServiceProvider.GetService<IAssignmentRepository>();

		await assignmentRepository.DeleteAsync(message.Id);

		Console.WriteLine(message.Id);
	}
}
