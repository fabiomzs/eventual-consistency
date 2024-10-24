namespace FabioMuniz.EventualConsistency.Core.Messages;

public class Event : Message
{
	public DateTime Timestamp { get; set; }

	public Event()
	{
		Timestamp = DateTime.Now;
	}
}
