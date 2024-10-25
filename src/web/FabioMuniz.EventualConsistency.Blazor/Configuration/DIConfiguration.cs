using FabioMuniz.EventualConsistency.Blazor.Extensions;
using FabioMuniz.EventualConsistency.Blazor.Services;

namespace FabioMuniz.EventualConsistency.Blazor.Configuration;

public static class DIConfiguration
{
	public static IServiceCollection AddDependencyInjections(this IServiceCollection services)
	{
		services.AddHttpClient(AppSettings.QueryAPI.ClientName, client => client.BaseAddress = new Uri(AppSettings.QueryAPI.Url));
		services.AddHttpClient(AppSettings.CommandAPI.ClientName, client => client.BaseAddress = new Uri(AppSettings.CommandAPI.Url));

		services.AddScoped<IAssignmentService, AssignmentService>();

		return services;
	}
}
