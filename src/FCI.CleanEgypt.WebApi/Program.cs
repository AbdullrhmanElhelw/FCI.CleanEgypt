using FCI.CleanEgypt.Application;
using FCI.CleanEgypt.Infrastructure;
using FCI.CleanEgypt.Persistence;
using FCI.CleanEgypt.WebApi.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddPersistence(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddAuthenticationSchema(builder.Configuration)
    .AddApplication()
    .AddIdentityUsers()
    .AddAuthorizationPolices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();