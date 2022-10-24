using ADPTest.WebAPI.Configurations;
using ADPTest.Infrastructure;
using ADPTest.SharedKernel.Models;
using static CSharpFunctionalExtensions.Result;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig(builder.Configuration);
builder.Services.AddDependencies(builder.Configuration);

builder.Services.Configure<AppConfig>(builder.Configuration.GetSection(nameof(AppConfig)));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
