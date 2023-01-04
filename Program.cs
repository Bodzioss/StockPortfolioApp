global using StockPortfolioApp.Models;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
using StockPortfolioApp.Services.PortfolioComponentService;
using StockPortfolioApp.Services.PortfolioService;
using StockPortfolioApp.Services.StockDataService;
using StockPortfolioApp.Services.StockService;
using StockPortfolioApp.Services.TransactionService;
using StockPortfolioApp.Services.UserService;
using StockPortfolioApp.Services.StockExchangeService;
global using StockPortfolioApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPortfolioComponentService, PortfolioComponentService>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IStockDataService, StockDataService>();
builder.Services.AddScoped<IStockExchangeService, StockExchangeService>();
builder.Services.AddScoped<IStockService, StockService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

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
