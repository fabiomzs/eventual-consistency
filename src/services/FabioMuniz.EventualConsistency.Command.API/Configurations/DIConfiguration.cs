using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

namespace FabioMuniz.EventualConsistency.Command.API.Configurations;

public static class DIConfiguration
{
	public static IServiceCollection AddDependencyInjections(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddScoped<IAssignmentRepository>(provider => { return new AssignmentRepository(configuration.GetConnectionString("ToDoDB") ?? string.Empty); });

		services.AddScoped<CreateAssignment>();
		services.AddScoped<CompleteAssignment>();
		services.AddScoped<DeleteAssignment>();

		return services;
	}
}
