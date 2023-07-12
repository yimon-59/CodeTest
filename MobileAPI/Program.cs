using Microsoft.EntityFrameworkCore;
using MobileAPI.DAO;
using MobileAPI.Repository;
using MobileAPI.Repository.IRepository;
using MobileAPI.Service;
using MobileAPI.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var builders = new ConfigurationBuilder().AddJsonFile("appsettings.json");

var configuration = builders.Build();
var connectionString = configuration.GetConnectionString("Default");

// Register the data context with dependency injection
builder.Services.AddDbContext<MobileDataContext>(options =>
    options.UseSqlServer(connectionString));
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
