using FabioMuniz.EventualConsistency.Command.API.Models;


namespace FabioMuniz.EventualConsistency.Command.API.Data;

public interface IAssignmentRepository
{
    Task<Guid> CreateAsync(Assignment assignment);
    Task<bool> UpdateAsync(Guid id, bool completed);
    Task<bool> DeleteAsync(Guid id);
}