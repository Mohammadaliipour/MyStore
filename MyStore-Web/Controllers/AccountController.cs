using Microsoft.AspNetCore.Mvc;

namespace MyStore_Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
