using FabioMuniz.EventualConsistency.Command.API.Configurations;
using FabioMuniz.EventualConsistency.Command.API.Data;
using FabioMuniz.EventualConsistency.Command.API.Routes;
using FabioMuniz.EventualConsistency.Logger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDependencyInjections(builder.Configuration);
builder.Services.AddAPIConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapToDoRoutes();

var database = app.Services.GetRequiredService<DatabaseInitializer>();
database.Start();

app.UseLogger(builder.Configuration.GetConnectionString("ElasticSearch") ?? string.Empty);

app.Run();