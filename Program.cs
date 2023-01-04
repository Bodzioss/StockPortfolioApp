global using StockPortfolioApp.Models;
using StockPortfolioApp.Services.PortfolioComponentService;
using StockPortfolioApp.Services.PortfolioService;
using StockPortfolioApp.Services.StockDataService;
using StockPortfolioApp.Services.StockService;
using StockPortfolioApp.Services.TransactionService;
using StockPortfolioApp.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPortfolioComponentService, PortfolioComponentService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IStockDataService, StockDataService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserService, UserService>();

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
