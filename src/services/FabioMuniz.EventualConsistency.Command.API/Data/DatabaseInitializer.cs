using Microsoft.Data.SqlClient;

namespace FabioMuniz.EventualConsistency.Command.API.Data;

public class DatabaseInitializer
{
	private readonly string? _connectionString;

	public DatabaseInitializer(string connectionString)
	{
		_connectionString = connectionString;
	}

	public void Start()
	{
		var builder = new SqlConnectionStringBuilder(_connectionString);
		builder.InitialCatalog = "master";

		using var connection = new SqlConnection(builder.ConnectionString);

		connection.Open();

		if (!DatabaseExists(connection))
			DatabaseCreate(connection);

		if (!TableExists(connection))
			TableCreate(connection);
	}

	bool DatabaseExists(SqlConnection connection)
	{
		var command = connection.CreateCommand();
		command.CommandText = "IF DB_ID('ToDoDB') IS NULL SELECT 0 ELSE SELECT 1";

		return (int)command.ExecuteScalar() == 1;
	}

	void DatabaseCreate(SqlConnection connection)
	{
		var command = connection.CreateCommand();
		command.CommandText = "CREATE DATABASE ToDoDB";

		command.ExecuteNonQuery();
	}

	bool TableExists(SqlConnection connection)
	{
		var command = connection.CreateCommand();
		command.CommandText = "SELECT CASE WHEN OBJECT_ID('TodoDB.dbo.Assignments', 'U') IS NOT NULL THEN 1 ELSE 0 END";

		return (int)command.ExecuteScalar() == 1;
	}

	void TableCreate(SqlConnection connection)
	{
		var command = connection.CreateCommand();
		command.CommandText = @"CREATE TABLE [ToDoDB].[dbo].[Assignments](
	                            [Id] [uniqueidentifier] PRIMARY KEY NOT NULL,
	                            [Description] [varchar](50) NOT NULL,
	                            [Completed] [bit] NOT NULL,
	                            [CreatedAt] [datetime] NOT NULL)";

		command.ExecuteNonQuery();
	}
}
