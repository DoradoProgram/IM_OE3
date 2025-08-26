module AccountController
using Microsotft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using LoginApp.Web.Models;

namespace LoginApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpClientFactory _factory;
        public AccountController(IHttpClientFactory factory) => _factory = factory;
        [HttpGet]
        public IActionResult Login() => View();


        [HttpPost]
        public async Task<IactionResult> Login(LoginViewModel model)
        {
            var client = _factory.CreateClient("BackendApi");
            var json = JsonSerializer.Serialize(new { username = model.Username, password = model.Password });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth/login", content);
            if (!response.IsSuccessStatusCode)
            {
                model.Error = "Invalid Login";
                return View(model);
            }

            var claims = new[] { new Claim(ClaimTypes.Name, model.Username ) };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}   
