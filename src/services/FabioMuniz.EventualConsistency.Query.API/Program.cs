using FabioMuniz.EventualConsistency.Query.API.Configurations;

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

app.Run();