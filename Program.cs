using MartinHuiLoanApplicationApi.Model;
using MartinHuiLoanApplicationApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Logging Configuration
builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders(); // Clear out any other logging providers (if needed).
    logging.AddConsole(); // Add console logging provider.
    logging.AddDebug(); // Add debug logging provider.
});
builder.Services.AddLogging();
// Connect to SQL Server
var connectionString = builder.Configuration.GetConnectionString("localhost");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<LoanProductService>();

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
