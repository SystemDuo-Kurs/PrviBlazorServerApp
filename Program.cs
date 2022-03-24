using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PrviBlazorServerApp.Data;
using MudBlazor.Services;
using PrviBlazorServerApp;
using Microsoft.EntityFrameworkCore;
using PrviBlazorServerApp.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddMudServices();

builder.Services.AddDbContext<Db>(opcije =>
    opcije.UseSqlServer(builder.Configuration.GetConnectionString("Baza")));

builder.Services.AddTransient<WeatherForecastService>();
builder.Services.AddTransient<ProbniServis>();
builder.Services.AddTransient<Person>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();