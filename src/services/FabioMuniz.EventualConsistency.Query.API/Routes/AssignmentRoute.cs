using FabioMuniz.EventualConsistency.Query.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace FabioMuniz.EventualConsistency.Query.API.Routes;

public static class AssignmentRoute
{
	public static void MapToDoRoutes(this WebApplication application)
	{
		var todoGroup = application.MapGroup("api/v1/assignments").WithTags("Assignments").WithOpenApi();

		todoGroup.MapGet("", async ([FromServices] IAssignmentRepository assignmentRepository) =>
		{
			var result = await assignmentRepository.GetAllAsync();

			if (result.Any())
				return Results.Ok(result);
			else
				return Results.NotFound();
		});

		todoGroup.MapGet("{id}", async ([FromRoute] Guid id, [FromServices] IAssignmentRepository assignmentRepository) =>
		{
			var result = await assignmentRepository.GetByIdAsync(id);

			if (result != null)
				return Results.Ok(result);
			else
				return Results.NotFound();
		});
	}
}
