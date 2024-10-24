using FabioMuniz.EventualConsistency.Core.Messages;

namespace FabioMuniz.EventualConsistency.MessageBus;

public interface IMessabeBus
{
	Task PublishAsync<T>(T message) where T : Event;
	Task SubscribeAsync<T>(T message, Func<T, Task> onMessage) where T : Event;
}
