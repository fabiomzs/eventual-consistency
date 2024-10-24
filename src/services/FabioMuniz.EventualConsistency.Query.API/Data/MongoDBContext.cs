using MongoDB.Driver;

namespace FabioMuniz.EventualConsistency.Query.API.Data;

public class MongoDBContext
{	
	private readonly IMongoDatabase _database;

    public MongoDBContext(string connectionString)
    {
        var mongoUrl = MongoUrl.Create(connectionString);
        var mongoClient = new MongoClient(mongoUrl);
        _database = mongoClient.GetDatabase(mongoUrl.DatabaseName);
    }

    public IMongoDatabase? Database => _database;
}
