using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using UserService.API.Middleware;
using UserService.Application;
using UserService.Infrastructure.Caching;
using UserService.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddApplication();
builder.Services.AddUserIdentity(builder.Configuration);
builder.Services.AddCaching(builder.Configuration);
builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["IdentityServer:Address"];
        options.Audience = builder.Configuration["IdentityServer:Audience"];
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", 
        policy => policy.RequireRole("admin"));
});

var app = builder.Build();

app.InitializeDb();

app.UseJsonResponseExceptionHandler();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

app.MapControllers();
app.Run();