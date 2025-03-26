using IdentityService.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServerLayer();

var app = builder.Build();
app.Run();