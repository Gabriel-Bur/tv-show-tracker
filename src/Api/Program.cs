using Api.Extensions.Configuration;
using Api.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextConfiguration(builder);
builder.Services.AddEndpointConfiguration(typeof(IEndpoint));
builder.Services.AddSwaggerConfiguration();
builder.Services.AddAuthenticationConfiguration(builder);
builder.Services.AddAuthorizationConfiguration(builder);

var app = builder.Build();

app.UseDbContextConfiguration();
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseEndpointConfiguration();

app.Run();
