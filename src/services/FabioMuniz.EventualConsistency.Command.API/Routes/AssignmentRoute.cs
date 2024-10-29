using FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;
using Microsoft.AspNetCore.Mvc;

namespace FabioMuniz.EventualConsistency.Command.API.Routes;

public static class AssignmentRoute
{
	public static void MapToDoRoutes(this WebApplication application)
	{
		var todoGroup = application.MapGroup("api/v1/assignments").WithTags("Assignments").WithOpenApi();

		todoGroup.MapPost("", async ([FromBody] CreateAssignmentRequest request, [FromServices] CreateAssignment handle) =>
		{
			try
			{
				var result = await handle.Handler(request);

				if (result != Guid.Empty)
					return Results.Created($"/{result}", result);
				else
					return Results.BadRequest();
			}
			catch (Exception ex)
			{
				return Results.Problem(ex.Message, statusCode: 500);
			}
		});

		todoGroup.MapPut("/{id}", async ([FromRoute] Guid id, [FromBody] CompleteAssignmentRequest request, [FromServices] CompleteAssignment handle) =>
		{
			try
			{
				var result = await handle.Handler(request);

				if (result)
					return Results.Ok();
				else
					return Results.BadRequest();
			}
			catch (Exception ex)
			{
				return Results.Problem(ex.Message, statusCode: 500);
			}
		});

		todoGroup.MapDelete("/{id}", async ([FromRoute] Guid id, [FromServices] DeleteAssignment handle) =>
		{
			try
			{
				var result = await handle.Handler(id);

				if (result)
					return Results.Ok();
				else
					return Results.BadRequest();

			}
			catch (Exception ex)
			{
				return Results.Problem(ex.Message, statusCode: 500);
			}
		});
	}
}
