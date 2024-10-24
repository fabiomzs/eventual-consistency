using FabioMuniz.EventualConsistency.Blazor.Components;
using FabioMuniz.EventualConsistency.Blazor.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.AddAppSettings();
builder.Services.AddAppConfiguration();

var app = builder.Build();

app.UseAppConfiguration(app.Environment);

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
