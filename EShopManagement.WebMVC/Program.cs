using EShopManagement.Shared;
using EShopManagement.Application;
using EShopManagement.Infrastructure;
using EShopManagement.WebMVC.Consts;
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddShared();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(configuration);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    option.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(option =>
{
    option.LoginPath = "/Login";
    option.LogoutPath = "/Logout";
    option.AccessDeniedPath = "/AccessDenied";
});
builder.Services.AddControllersWithViews();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseShared();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
 app.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.Run();
