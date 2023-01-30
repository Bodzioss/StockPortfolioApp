global using StockPortfolioApp.Models;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using StockPortfolioApp.Data;
using StockPortfolioApp.Services.PortfolioComponentService;
using StockPortfolioApp.Services.PortfolioService;
using StockPortfolioApp.Services.StockDataService;
using StockPortfolioApp.Services.StockService;
using StockPortfolioApp.Services.TransactionService;
using StockPortfolioApp.Services.UserService;
using StockPortfolioApp.Services.StockExchangeService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

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
builder.Services.AddScoped<IAuthRepository, AuthRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuerSigningKey = true,
//        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value!)),
//        ValidateIssuer = false,
//        ValidateAudience = false
//    };
//});

//builder.Services.AddSwaggerGen(c =>
//{
//    c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
//    {
//        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\" ",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Type = SecuritySchemeType.ApiKey
//    });
//    c.OperationFilter<SecurityRequirementsOperationFilter>();
//});
builder.Services.AddHttpContextAccessor();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.WithOrigins("http://localhost:3000");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
