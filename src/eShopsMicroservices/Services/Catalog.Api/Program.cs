using Carter;
using Marten;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(assembly);
});

builder.Services.AddCarter();
builder.Services.AddMarten(option =>
{
    option.Connection(builder.Configuration.GetConnectionString("CatalogConnection")!);
}).UseLightweightSessions();

//builder.Services.AddHealthChecks()
//    .AddNpgSql(builder.Configuration.GetConnectionString("CatalogConnection")!);

var app = builder.Build();

app.MapCarter();

app.UseHttpsRedirection();


app.Run();
