using ePieHut.Services.Interfaces;
using ePieHut.WebApplication.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace ePieHut.WebApplication.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAuthService authService;
        public AccountController(IAuthService _authService)
        {
            


            authService = _authService;
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel request)
        {
            if (ModelState.IsValid)
            {
                var user = authService.ValidateUser(request.Email, request.Password);

                if (user != null)
                {

                    GenerateTicket(user);
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new {area = "Admin"});
                    }

                    return RedirectToAction("Index", "Home", new { area = "User" });

                }


            }




            return View();
        }

        private async void GenerateTicket(UserModel user)
        {
            string UserData = JsonSerializer.Serialize(user);


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role,string.Join(",", user.Roles)),
                new Claim(ClaimTypes.UserData,UserData)

            };
            var Identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(Identity);

            var properties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
            };



           await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,properties);
        }

        [HttpPost]
        public IActionResult SignUp()
        {
            return View();
        }



        [HttpPost]
        public IActionResult UnAuthorize()
        {
            return View();
        }



        [HttpPost]
        public IActionResult LogOut()
        {

            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
            return RedirectToAction("Login");
        }
    }
}
