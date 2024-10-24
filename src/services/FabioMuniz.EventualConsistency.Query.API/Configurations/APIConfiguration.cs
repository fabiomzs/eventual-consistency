namespace FabioMuniz.EventualConsistency.Query.API.Configurations;

public static class APIConfiguration
{
	public static IServiceCollection AddAPIConfiguration(this IServiceCollection services)
	{
		services.AddEndpointsApiExplorer();
		services.AddSwaggerGen();

		return services;
	}
}
