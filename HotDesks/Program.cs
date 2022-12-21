using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using HotDesks.Context;
using HotDesks.Interfaces;
using HotDesks.Services;
using HotEmployees.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddScoped<IHotDeskService, HotDeskService>();
builder.Services.AddScoped<IEmployeeInterface, EmployeeService>();
builder.Services.AddScoped<IReservationInterface, ReservationService>();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DataBaseContext>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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