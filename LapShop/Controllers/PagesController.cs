using LapShop.Bl;
using Microsoft.AspNetCore.Mvc;

namespace LapShop.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class PagesController : Controller
    {
        IPages oClsPage;

        public PagesController(IPages oClsPage)
        {
           this.oClsPage = oClsPage;
        }
        // GET: PagesController
        public ActionResult Pages(int pageId)
            {
                var page = oClsPage.GetById(pageId);
                return View(page);
            }

     

     

    }
    }

