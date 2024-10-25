using FabioMuniz.EventualConsistency.Blazor.Models;

namespace FabioMuniz.EventualConsistency.Blazor.Services;

public interface IAssignmentService
{
	Task<bool> CreateAssignmentAsync(AssignmentModel assignment);
	Task<bool> UpdateAssignmentAsync(Guid id, bool completed);
	Task<bool> DeleteAssignmentAsync(Guid id);
	Task<AssignmentModel> GetAssignmentByIdAsync(Guid id);
	Task<IEnumerable<AssignmentModel>> GetAllAssignmentsAsync();
}
