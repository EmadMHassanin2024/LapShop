using Microsoft.AspNetCore.Mvc;
using LapShop.Models;
using LapShop.BL;
using LapShop.Bl;

namespace LapShop.Controllers
{
    public class HomeController : Controller
    {
        IClsItems oClsItems;
        ISliders oSliders;
        IClsCategories oClscategories;
             
        public HomeController(IClsItems items, ISliders oSliders, IClsCategories oClscategories)
        {
            oClsItems = items;
            this.oSliders = oSliders;
            this.oClscategories = oClscategories;   

        }
      
        public IActionResult Index()
        {
            VmHomePages vm = new VmHomePages();

            vm.lstAllItems = oClsItems.GetAllItemData(null).Take(5).ToList();
      

            vm.lstRecommendedItems = oClsItems.GetAllItemData(null).Skip(20).Take(3).ToList();
            vm.lstNewItems = oClsItems.GetAllItemData(null).Skip(30).Take(7).ToList();
            vm.lstFreeDelivry = oClsItems.GetAllItemData(null).Skip(20).Take(10).ToList();
            vm.lstSlider = oSliders.GetAll();
            vm.lstCategories = oClscategories.GetAll().Take(4).ToList(); 

            return View(vm);
        }
    }
}
