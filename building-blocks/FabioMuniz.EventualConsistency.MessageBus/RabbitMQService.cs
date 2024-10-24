using FabioMuniz.EventualConsistency.Core.Extensions;
using FabioMuniz.EventualConsistency.Core.Messages;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace FabioMuniz.EventualConsistency.MessageBus;

public class RabbitMQService : IMessabeBus
{
	private readonly IConnection _connection;

	public RabbitMQService(string connectionString)
	{
		var factory = new ConnectionFactory() { Uri = new Uri(connectionString) };
		_connection = factory.CreateConnection();
	}

	public async Task PublishAsync<T>(T message) where T : Event
	{
		var queue = message.MessageType.ToKebab();
		var json = JsonSerializer.Serialize(message);
		using var channel = CreateChannel();

		channel.QueueDeclare(queue, true, false, false);
		var body = Encoding.UTF8.GetBytes(json);

		channel.BasicPublish(exchange: string.Empty, routingKey: queue, basicProperties: null, body: body);
		_connection.Close();

		await Task.CompletedTask;
	}

	private IModel CreateChannel()
	{
		return _connection.CreateModel();
	}
}
