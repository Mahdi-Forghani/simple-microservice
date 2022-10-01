using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemory"));
builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPlatformRepo, PlatformRepo>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// build application
var app = builder.Build();

// prepare database
app.DbPrepPopulation();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// run application
app.Run();
