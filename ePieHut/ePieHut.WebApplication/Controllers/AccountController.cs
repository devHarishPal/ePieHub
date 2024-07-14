using ePieHut.Services.Interfaces;
using ePieHut.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

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
                    if (user.Roles.Contains("Admin"))
                    {
                        return RedirectToAction("Index", "Home", new {area = "Admin"});
                    }

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }


            }




            return View();
        }
    }
}
