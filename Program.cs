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
builder.Services.AddCors(x =>
{
    x.AddPolicy("mypolicy", options =>
    {
        //options.WithHeaders("from", "react");
        options.AllowAnyHeader();
        options.AllowAnyMethod();
        options.AllowAnyOrigin();
    });
});

//services
builder.Services.AddTransient<ICompanyService, CompanyService>();

//Repository
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();

builder.Services.AddTransient<IInstanceLifetimeService, InstanceLifetimeService>();

//test the lifetime scope of instance
builder.Services.AddTransient<ITransientInstanceLifetimeService, OperationClass>();
builder.Services.AddScoped<ISingletonInstanceLifetimeService, OperationClass>();
builder.Services.AddSingleton<IScopedInstanceLifetimeService, OperationClass>();

builder.Services.AddControllers();
Environment.SetEnvironmentVariable("username", "vishal");

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
    app.UseDeveloperExceptionPage();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.RoutePrefix = "";
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test app v1");
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("mypolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();
