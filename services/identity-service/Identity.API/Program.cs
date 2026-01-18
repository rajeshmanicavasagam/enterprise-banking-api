using Identity.Application.UseCases;
using Identity.Infrastructure;

builder.Services.AddInfrastructure();
builder.Services.AddScoped<LoginUserHandler>();
