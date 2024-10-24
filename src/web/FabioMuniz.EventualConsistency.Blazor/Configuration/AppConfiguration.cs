using System.Diagnostics;

namespace FabioMuniz.EventualConsistency.Blazor.Configuration;

public static class AppConfiguration
{
	public static void AddAppConfiguration(this IServiceCollection services)
	{
		services.AddDependencyInjections();
	}

	public static void UseAppConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
	{
		// Configure the HTTP request pipeline.
		if (!env.IsDevelopment())
		{
			app.UseExceptionHandler("/Error", createScopeForErrors: true);
			// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
			app.UseHsts();
		}

		app.UseHttpsRedirection();

		app.UseStaticFiles();
		app.UseAntiforgery();
	}
}
