using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using BpkbMvc.Services;

var builder = WebApplication.CreateBuilder(args);

// Tambahkan konfigurasi untuk services
builder.Services.AddControllersWithViews();

// Konfigurasi Dependency Injection
builder.Services.AddHttpClient<AuthService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5044/"); // Ganti dengan base address API backend
});

builder.Services.AddHttpClient<TrBpkbService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5044/"); // Ganti dengan base address API backend
});

// Konfigurasi Session
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Konfigurasi penggunaan session
app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TrBpkb}/{action=Index}/{id?}");

app.Run();


