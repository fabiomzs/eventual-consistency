using FabioMuniz.EventualConsistency.Blazor.Models;

namespace FabioMuniz.EventualConsistency.Blazor.Services;

public interface IAssignmentService
{
	Task<bool> CreateAssignmentAsync(Assignment assignment);
	Task<bool> UpdateAssignmentAsync(Guid id, bool completed);
	Task<bool> DeleteAssignmentAsync(Guid id);
	Task<Assignment> GetAssignmentByIdAsync(Guid id);
	Task<IEnumerable<Assignment>> GetAllAssignmentsAsync();
}
