using ePieHut.WebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ePieHut.WebApplication.Areas.Admin.Controllers
{

    [CustomAuthorize(Roles ="Admin")]
    [Area("Admin")]
    public class BaseController : Controller
    {
       
    }
}
