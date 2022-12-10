using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Authorization;
using TiempoPerdido.Data;
using TiempoPerdido.Service;
using BlazorStrap;
using Blazored.LocalStorage;

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