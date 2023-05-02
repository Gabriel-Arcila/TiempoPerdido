using System.Text.Json;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Components.Authorization;

using BlazorStrap;
using Blazored.SessionStorage;
using Blazored.LocalStorage;
using Radzen;

using TiempoPerdido.Data;
using TiempoPerdido.Service;
using TiempoPerdido.Models;
using TiempoPerdido.DTOs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorStrap();


builder.Services.AddHttpClient();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddControllersWithViews();
builder.Services.AddOptions();  
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<NotificationService>();

builder.Services.AddBlazoredSessionStorage(config =>
{
    config.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.IgnoreNullValues = true;
    config.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
    config.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    config.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    config.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
    config.JsonSerializerOptions.WriteIndented = false;
});

builder.Services.AddBlazoredSessionStorage();

builder.Services.AddSingleton<Turno>();

builder.Services.AddDbContext<DbNeoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionDbNeo")),ServiceLifetime.Transient
);

builder.Services.AddScoped<global::Microsoft.AspNetCore.Components.Authorization.AuthenticationStateProvider,global:: TiempoPerdido.Service.Autenticacion.CustomAuthStateProvider>();

builder.Services.AddScoped<global::TiempoPerdido.Data.API.IDataAPI, global::TiempoPerdido.Data.API.DataAPI>();

builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataPais, global::TiempoPerdido.Data.Global.DataPais>();
builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataEmpresa, global::TiempoPerdido.Data.Global.DataEmpresa>();
builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataCentro, global::TiempoPerdido.Data.Global.DataCentro>();
builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataDivision, global::TiempoPerdido.Data.Global.DataDivision>();
builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataLinea, global::TiempoPerdido.Data.Global.DataLinea>();
builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataArea, global::TiempoPerdido.Data.Global.DataArea>();
builder.Services.AddScoped<global::TiempoPerdido.Data.Global.IDataEquipoEAM, global::TiempoPerdido.Data.Global.DataEquipoEAM>();

builder.Services.AddScoped<global::TiempoPerdido.Data.IDataOperador, global::TiempoPerdido.Data.DataOperador>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataTieEjeTp, global::TiempoPerdido.Data.DataTieEjeTp>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataTurnoTp, global::TiempoPerdido.Data.DataTurnoTp>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataTieParTp, global::TiempoPerdido.Data.DataTieParTp>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataAreAfect, global::TiempoPerdido.Data.DataAreAfect>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataParaTp, global::TiempoPerdido.Data.DataParaTp>();
builder.Services.AddScoped<global::TiempoPerdido.Data.IDataTiParTP, global::TiempoPerdido.Data.DataTiParTP>();



// builder.Service.AddSingleton.


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
