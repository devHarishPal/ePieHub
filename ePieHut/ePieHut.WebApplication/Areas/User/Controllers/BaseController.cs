using ePieHut.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ePieHut.WebApplication.Areas.User.Controllers
{
    [CustomAuthorize(Roles = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
       
    }
}
