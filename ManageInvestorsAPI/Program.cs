using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System;
using ManageInvestors.DataLayer;
using ManageInvestors.Code;
using ManageInvestors.Services;
using ManageInvestors.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Text.Json.Serialization;
using AutoMapper;
using ManageInvestorsAPI.Maps;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    // Customize further based on your needs
});

services.AddHttpContextAccessor();

// Repositories
builder.Services.AddScoped<IInvestorRepository, InvestorRepository>();
builder.Services.AddScoped<IFundRepository, FundRepository>();
builder.Services.AddScoped<IInvestmentRepository, InvestmentRepository>();

var connectionString = configuration.GetConnectionString("DbContextConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

services.AddDbContextFactory<ApplicationDbContext>(options =>
options.UseSqlServer( // Ensure you have the Microsoft.EntityFrameworkCore.SqlServer package installed
               connectionString,
               sqlOptions => sqlOptions.MigrationsHistoryTable("__EFMigrationsHistory", Globals.DefaultSchema))

);

// Services
builder.Services.AddScoped<IInvestorService, InvestorService>();
builder.Services.AddScoped<IFundService, FundService>();
builder.Services.AddScoped<IInvestmentService, InvestmentService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
services.AddOpenApi();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile<AutoMapperProfile>();
});
config.AssertConfigurationIsValid();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
