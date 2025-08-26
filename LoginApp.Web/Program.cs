module Program
using Microsoft.AspNetCore.Authentication.Cookies;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient("BackendApi", client =>
{
    client.BaseAddress = new Uri(Builder.Configuration["Api:BaseUrl"]);
});
builder.Services.AddAuthentication(CookieAuthentiationDefaults.AuthenticationScheme)
    Add.Cookie(options =>
    {
        options.LoginPath = "/Account/Login";
    });

