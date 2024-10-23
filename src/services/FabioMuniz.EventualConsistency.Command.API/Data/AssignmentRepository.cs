using Dapper;
using FabioMuniz.EventualConsistency.Command.API.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace FabioMuniz.EventualConsistency.Command.API.Data;

public class AssignmentRepository : IAssignmentRepository
{
	private readonly string? _connectionString;

    public AssignmentRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection Connection => new SqlConnection(_connectionString);

    public async Task<Guid> CreateAsync(Assignment assignment)
    {
        string query = "INSERT INTO Assignments (Id, Description, Completed, CreatedAt) OUTPUT INSERTED.Id VALUES (@Id, @Description, 0, GETDATE())";

        using IDbConnection connection = Connection;

        return await connection.QuerySingleAsync<Guid>(query, new { Id = assignment.Id, Description = assignment.Description });
    }

    public async Task<bool> UpdateAsync(Guid id, bool completed)
    {
		string query = "UPDATE Assignments SET Completed = @Completed WHERE Id = @Id";

		using IDbConnection connection = Connection;

		return await connection.ExecuteAsync(query, new { Completed = completed, Id = id }) > 0;
	}

    public async Task<bool> DeleteAsync(Guid id)
    {
		string query = "DELETE FROM Assignments WHERE Id = @Id";

		using IDbConnection connection = Connection;

		return await connection.ExecuteAsync(query, new { Id = id }) > 0;
	}
}
