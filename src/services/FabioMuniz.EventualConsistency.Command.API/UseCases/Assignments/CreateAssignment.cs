using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Command.API.Models;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class CreateAssignment(IAssignmentRepository assignmentRepository)
{
	public async Task<Guid> Handler(CreateAssignmentRequest request)
	{
		Assignment assignment = new(request.Description);

		var id = await assignmentRepository.CreateAsync(assignment);

		return id;
	}
}
