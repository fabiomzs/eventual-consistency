using FabioMuniz.EventualConsistency.Command.API.Data;

namespace FabioMuniz.EventualConsistency.Command.API.UseCases.Assignments;

public class DeleteAssignment(IAssignmentRepository assignmentRepository)
{
	public async Task<bool> Handler(Guid id)
	{
		var result = await assignmentRepository.DeleteAsync(id);

		return result;
	}
}
