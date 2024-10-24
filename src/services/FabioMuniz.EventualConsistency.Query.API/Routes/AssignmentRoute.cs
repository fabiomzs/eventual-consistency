namespace FabioMuniz.EventualConsistency.Query.API.Routes;

public static class AssignmentRoute
{
	public static void MapToDoRoutes(this WebApplication application)
	{
		var todoGroup = application.MapGroup("api/v1/assignments").WithTags("Assignments").WithOpenApi();

		todoGroup.MapGet("", () =>
		{
			return Results.Ok();
		});
	}
}
