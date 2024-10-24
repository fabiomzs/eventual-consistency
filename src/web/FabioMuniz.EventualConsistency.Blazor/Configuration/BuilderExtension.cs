using FabioMuniz.EventualConsistency.Blazor.Extensions;

namespace FabioMuniz.EventualConsistency.Blazor.Configuration
{
	public static class BuilderExtension
	{
		public static void AddAppSettings(this WebApplicationBuilder builder)
		{
			AppSettings.QueryAPI.Url = builder.Configuration.GetSection("AppSettings:ToDoGatewayQueryAPI").GetValue<string>("Url") ?? string.Empty;
			AppSettings.QueryAPI.ClientName = builder.Configuration.GetSection("AppSettings:ToDoGatewayQueryAPI").GetValue<string>("ClientName") ?? string.Empty;

			AppSettings.CommandAPI.Url = builder.Configuration.GetSection("AppSettings:ToDoGatewayCommandAPI").GetValue<string>("Url") ?? string.Empty;
			AppSettings.CommandAPI.ClientName = builder.Configuration.GetSection("AppSettings:ToDoGatewayCommandAPI").GetValue<string>("ClientName") ?? string.Empty;
		}
	}
}
