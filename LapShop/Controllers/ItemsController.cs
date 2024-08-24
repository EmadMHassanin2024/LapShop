using Microsoft.AspNetCore.Mvc;
using LapShop.BL;
using LapShop.Models;


namespace LapShop.Controllers
{
    public class ItemsController : Controller
    {
        IClsItems oItems;
        IItemImages oImages;
        public ItemsController(IClsItems Items, IItemImages Images)
        {
            oItems=Items;
             oImages=Images; 
       
        }
        public IActionResult ItemDetails(int id)
        {

            var item = oItems.GetItemById(id);
            VmItemmDetails vm = new VmItemmDetails();
            vm.Item = item;

            vm.lstRecommendedItems = oItems.GetRecommendedItems(id).Take(10).ToList(); 
           
            vm.lstItemImages = oImages.GetByItemId(id);

            return View(vm);
        }


        public IActionResult ItemList()
        {

   
            return View();
        }

    }
}




