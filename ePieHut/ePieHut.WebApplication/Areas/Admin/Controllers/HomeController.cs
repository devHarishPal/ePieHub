using Microsoft.AspNetCore.Mvc;

namespace ePieHut.WebApplication.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
