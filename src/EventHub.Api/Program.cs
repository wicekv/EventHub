using EventHub.Application;
using EventHub.Core;
using EventHub.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCore()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);
    

var app = builder.Build();

app.UseInfrastructure();
app.Run();