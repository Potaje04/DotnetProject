 using MyprojectInC.Model;
using MyprojectInC.Model.Claims.Repository;
using MyprojectInC.Model.Owner.Repository;
using MyprojectInC.Model.Repositories;
using MySql.Data.MySqlClient;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mysqlConfig = new MySQLConfiguration(builder.Configuration.GetConnectionString("MySqlConnection"));

builder.Services.AddSingleton(mysqlConfig);

builder.Services.AddSingleton(new MySqlConnection(builder.Configuration.GetConnectionString("MySqlConnection")));

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

builder.Services.AddScoped<IOwnerRepository, OwnerRepository>();

builder.Services.AddScoped<IClaimRepository, ClaimRepository>();

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
