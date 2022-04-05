using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using PrviBlazorServerApp.Data;
using MudBlazor.Services;
using PrviBlazorServerApp;
using Microsoft.EntityFrameworkCore;
using PrviBlazorServerApp.Data.Services;
using PrviBlazorServerApp.Data.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddMudServices();

builder.Services.AddDbContext<Db>(opcije =>
    opcije.UseSqlServer(builder.Configuration.GetConnectionString("Baza")));

builder.Services.AddTransient<WeatherForecastService>();
builder.Services.AddTransient<ProbniServis>();
builder.Services.AddTransient<Person>();
builder.Services.AddTransient<PersonList>();
builder.Services.AddTransient<PersonEdit>();
builder.Services.AddSingleton<SignalR>();

var app = builder.Build();

//Spinup
app.Services.GetService<SignalR>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapHub<CrudHub>("CRUDhub");
app.MapFallbackToPage("/_Host");

app.Run();