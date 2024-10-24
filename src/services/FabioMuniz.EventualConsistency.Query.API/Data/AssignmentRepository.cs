using FabioMuniz.EventualConsistency.Query.API.Models;
using MongoDB.Driver;

namespace FabioMuniz.EventualConsistency.Query.API.Data;

public class AssignmentRepository : IAssignmentRepository
{
	private readonly IMongoCollection<Assignment> _collection;

	public AssignmentRepository(MongoDBContext context)
	{
		_collection = context.Database?.GetCollection<Assignment>("assignments");
	}

	public async Task CreateAsync(Assignment assignment)
	{
		await _collection.InsertOneAsync(assignment);
	}

	public async Task DeleteAsync(Guid id)
	{		
		var filter = Builders<Assignment>.Filter.Eq("_id", id.ToString());
		await _collection.DeleteOneAsync(filter);		
	}

	public async Task<IEnumerable<Assignment>> GetAllAsync()
	{
		return await _collection.Find(_ => true).ToListAsync();
	}

	public async Task<Assignment> GetByIdAsync(Guid id)
	{
		return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
	}

	public async Task UpdateAsync(Guid id, bool completed)
	{
		var filter = Builders<Assignment>.Filter.Eq("_id", id.ToString());
		var update = Builders<Assignment>.Update.Set(x => x.Completed, completed);
		await _collection.UpdateOneAsync(filter, update);
	}
}
