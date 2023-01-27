using Microsoft.EntityFrameworkCore;
using WebMilkApp.Data;
using WebMilkApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// I Injected following service for dependency Injection(for controller)

builder.Services.AddScoped<IMilkService, MilkService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// I added dependency injection to connect with Sql Server

builder.Services.AddDbContext<MilkDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("MilkInfoApiConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// added folowing line to connect with react
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
