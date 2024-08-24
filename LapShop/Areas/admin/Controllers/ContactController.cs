using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
