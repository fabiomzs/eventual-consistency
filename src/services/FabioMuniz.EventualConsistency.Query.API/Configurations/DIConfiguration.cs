using FabioMuniz.EventualConsistency.MessageBus;
using FabioMuniz.EventualConsistency.Query.API.Services;

namespace FabioMuniz.EventualConsistency.Query.API.Configurations;

public static class DIConfiguration
{
	public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSingleton<IMessabeBus>(provider => { return new RabbitMQService(configuration.GetConnectionString("RabbitMQ") ?? string.Empty); })
			.AddHostedService<AssignmentEventService>();

		return services;
	}
}
