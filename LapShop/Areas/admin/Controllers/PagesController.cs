using LapShop.Bl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Areas.admin.Controllers
{
    public class PagesController : Controller
    {
        IPages oClsPages;
        public PagesController(IPages pages)
        {
            oClsPages= pages;   
        }
        // GET: PagesController
        public ActionResult Pages()
        {
           var page= oClsPages.GetAll();
            return View(page);
        }


    }
}
