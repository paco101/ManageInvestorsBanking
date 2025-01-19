using Blazored.Modal;
using BlazorUI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

services.AddHttpContextAccessor();

var investorApiBaseUrl = configuration.GetValue<string>("InvestorApi:BaseUrl")
    ?? throw new InvalidOperationException("Investor API base URL not found in config.");

services.AddHttpClient("InvestorApi", client =>
{
    client.BaseAddress = new Uri(investorApiBaseUrl);
});

// Repositories
services.AddScoped<InvestorApiService>();
builder.Services.AddScoped<FundApiService>();
builder.Services.AddScoped<InvestmentApiService>();

// Add services to the container.
services.AddRazorPages();
services.AddServerSideBlazor();
services.AddBlazoredModal();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
