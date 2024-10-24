using FabioMuniz.EventualConsistency.MessageBus;
using FabioMuniz.EventualConsistency.Query.API.Data;
using FabioMuniz.EventualConsistency.Query.API.Services;
using MongoDB.Driver;

namespace FabioMuniz.EventualConsistency.Query.API.Configurations;

public static class DIConfiguration
{
	public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSingleton<IMessabeBus>(provider => { return new RabbitMQService(configuration.GetConnectionString("RabbitMQ") ?? string.Empty); })
			.AddHostedService<AssignmentEventService>();

		services.AddSingleton<MongoDBContext>(new MongoDBContext(configuration.GetConnectionString("MongoDB") ?? string.Empty));

		services.AddScoped<IAssignmentRepository, AssignmentRepository>();

		return services;
	}
}
