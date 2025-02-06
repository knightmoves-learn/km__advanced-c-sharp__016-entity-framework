using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using HomeEnergyApi.Models;
using HomeEnergyApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<HomeRepository>();
builder.Services.AddSingleton<IReadRepository<int, Home>>(provider => provider.GetRequiredService<HomeRepository>());
builder.Services.AddSingleton<IWriteRepository<int, Home>>(provider => provider.GetRequiredService<HomeRepository>());

builder.Services.AddTransient<ZipCodeLocationService>();
builder.Services.AddHttpClient<ZipCodeLocationService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();

//Do NOT remove anything below this comment, this is required to autograde the lesson
public partial class Program { }