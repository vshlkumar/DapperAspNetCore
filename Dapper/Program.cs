using Dapper.Data;
using Dapper.Data.Interface;
using Dapper.Data.Repository;
using Dapper.Services.Interface;
using Dapper.Services.Service;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddSingleton<DapperContext>();

//services
builder.Services.AddTransient<ICompanyService, CompanyService>();

//Repository
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test app v1");
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
