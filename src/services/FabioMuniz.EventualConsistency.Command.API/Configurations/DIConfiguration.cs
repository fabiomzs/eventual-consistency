using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;
using FabioMuniz.EventualConsistency.MessageBus;

namespace FabioMuniz.EventualConsistency.Command.API.Configurations;

public static class DIConfiguration
{
	public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IAssignmentRepository>(provider => { return new AssignmentRepository(configuration.GetConnectionString("ToDoDB") ?? string.Empty); });
		services.AddScoped<IMessabeBus>(provider => { return new RabbitMQService(configuration.GetConnectionString("RabbitMQ") ?? string.Empty); });
				
		services.AddSingleton<DatabaseInitializer>(provider => new DatabaseInitializer(configuration.GetConnectionString("ToDoDB") ?? string.Empty));			

		services.AddScoped<CreateAssignment>();
		services.AddScoped<CompleteAssignment>();
		services.AddScoped<DeleteAssignment>();

		return services;
	}
}
