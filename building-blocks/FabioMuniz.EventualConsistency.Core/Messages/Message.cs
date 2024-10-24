namespace FabioMuniz.EventualConsistency.Core.Messages;

public abstract class Message
{
	public string MessageType { get; set; }

	protected Message()
	{
		MessageType = GetType().Name;
	}
}
