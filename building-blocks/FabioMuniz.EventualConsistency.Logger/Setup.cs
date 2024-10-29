using Elastic.Channels;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace FabioMuniz.EventualConsistency.Logger;

public static class Setup
{
	public static IServiceCollection AddLooger(this IServiceCollection services)
	{
		services.AddSerilog();

		return services;
	}

	public static void UseLogger(this IApplicationBuilder app, string connection)
	{
		ArgumentNullException.ThrowIfNull(connection);

		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.Enrich.FromLogContext()
			.WriteTo.Elasticsearch(new[] { new Uri(connection) },
				options =>
				{
					options.DataStream = new DataStreamName("logs", "todo", "assignments");
					options.BootstrapMethod = BootstrapMethod.Failure;
					
					options.ConfigureChannel = channelOptions =>
					{
						channelOptions.BufferOptions = new BufferOptions
						{
							ExportMaxConcurrency = 10
						};
					};
				})
			.CreateLogger();		
	}
}
