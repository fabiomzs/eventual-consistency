using FabioMuniz.EventualConsistency.Command.API.Data;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class CompleteAssignment(IAssignmentRepository assignmentRepository)
{
	public async Task<bool> Handler(CompleteAssignmentRequest request)
	{
		var result = await assignmentRepository.UpdateAsync(request.Id, request.Completed);

		return result;
	}
}
