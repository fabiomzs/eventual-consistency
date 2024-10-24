namespace FabioMuniz.EventualConsistency.Blazor.Extensions
{
	public static class AppSettings
	{
		public static ToDoGatewayQueryAPI QueryAPI { get; set; } = new();
		public static ToDoGatewayCommandAPI CommandAPI { get; set; } = new();

		public class ToDoGatewayQueryAPI
		{
            public string Url { get; set; } = string.Empty;
			public string ClientName { get; set; } = string.Empty;
        }

		public class ToDoGatewayCommandAPI
		{
			public string Url { get; set; } = string.Empty;
			public string ClientName { get; set; } = string.Empty;
		}
	}
}
