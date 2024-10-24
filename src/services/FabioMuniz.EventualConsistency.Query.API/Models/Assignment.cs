using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace FabioMuniz.EventualConsistency.Query.API.Models;

public class Assignment
{
	[BsonId]
	[BsonElement("_id"), BsonRepresentation(BsonType.String)]
	public Guid Id { get; set; }

	[BsonElement("description"), BsonRepresentation(BsonType.String)]
	public string? Description { get; set; }

	[BsonElement("completed"), BsonRepresentation(BsonType.Boolean)]
	public bool Completed { get; set; }

	[BsonElement("createdAt"), BsonRepresentation(BsonType.DateTime)]
	public DateTime CreatedAt { get; set; }

    public Assignment(Guid id, string? description, bool completed, DateTime createdAt)
	{
        Id = id;
		Description = description;
		Completed = completed;
		CreatedAt = createdAt;
    }
}
