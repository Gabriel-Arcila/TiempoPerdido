using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using TiempoPerdido.Data;
using TiempoPerdido.Service;
using BlazorStrap;
using Blazored.LocalStorage;
using TiempoPerdido.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.AddScoped<global::Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider,global:: TiempoPerdido.Service.Autenticacion.CustomAuthStateProvider>();
builder.Services.AddBlazorStrap();

builder.Services.AddHttpClient();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddControllersWithViews();

builder.Services.AddAuthorizationCore();

builder.Services.AddSingleton<UsuarioServices>();

builder.Services.AddDbContext<DbNeoContext>();

builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataArea, global::TiempoPerdido.Data.Global.DataArea>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataOperador, global::TiempoPerdido.Data.DataOperador>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataTieEjeTp, global::TiempoPerdido.Data.DataTieEjeTp>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataTurnoTp, global::TiempoPerdido.Data.DataTurnoTp>();


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
