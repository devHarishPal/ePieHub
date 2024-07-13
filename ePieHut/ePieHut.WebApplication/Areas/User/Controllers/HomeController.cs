using Microsoft.AspNetCore.Mvc;

namespace ePieHut.WebApplication.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
