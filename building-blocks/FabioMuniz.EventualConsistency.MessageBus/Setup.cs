using Microsoft.Extensions.DependencyInjection;

namespace FabioMuniz.EventualConsistency.MessageBus;

public static class Setup
{
	public static IServiceCollection AddMessageBus(this IServiceCollection services, string connection)
	{
		ArgumentNullException.ThrowIfNull(connection);

		services.AddSingleton<IMessabeBus>(new RabbitMQService(connection));

		return services;
	}
}
