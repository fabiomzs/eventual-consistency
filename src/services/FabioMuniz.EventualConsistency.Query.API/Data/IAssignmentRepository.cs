using FabioMuniz.EventualConsistency.Query.API.Models;

namespace FabioMuniz.EventualConsistency.Query.API.Data;

public interface IAssignmentRepository
{
	Task CreateAsync(Assignment assignment);
	Task UpdateAsync(Guid id, bool completed);
	Task DeleteAsync(Guid id);
}
