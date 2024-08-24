using LapShop.Models;
using Microsoft.AspNetCore.Mvc;
using LapShop.BL;
using LapShop.Bl;
using LapShop.Utlities;
using Microsoft.AspNetCore.Authorization;

namespace LapShop.Areas.admin.Controllers
{
    [Area("admin")]

    [Authorize(Roles = "Admin,data entry")]
    public class ItemsController : Controller
    {

        public ItemsController(IClsItems Items,IClsCategories category,
            IClsItemTypes itemType, IClsOs Os)
        {
            oClsItems = Items; 
            oClsCategories = category;
            oClsItemType = itemType;
            oClsOs= Os; 
        }
        //لكي نسطيع ان نغيره من مكان واحد عن طريق engine mvc
       IClsItems oClsItems ;

        IClsCategories oClsCategories;
        IClsItemTypes oClsItemType ;   
        IClsOs oClsOs ;

        [AllowAnonymous]
        public IActionResult List()
        {
            ViewBag.lstCategories=oClsCategories.GetAll();   
          var items=   oClsItems.GetAllItemData(null); 
            return View(items);
        }

        [Authorize(Roles = "Admin")]        
        public IActionResult Edit(int? itemId)
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            ViewBag.lstItemTypes = oClsItemType.GetAll();
             ViewBag.lstOs= oClsOs.GetAll();    

             var item = new Models.TbItem();
            if (itemId != null)
            {
               item = oClsItems.GetById(Convert.ToInt32(itemId));

            }

            return View(item);
        }
        public IActionResult Search(int id )
        {
            ViewBag.lstCategories = oClsCategories.GetAll();
            var items = oClsItems.GetAllItemData(id);
            return View("List",items);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(TbItem item, List<IFormFile> Files)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", item);

            }
            item.ImageName = await Helper.UploadImage(Files, "Items");
            oClsItems.Save(item);

            return RedirectToAction("List");
        }

        public IActionResult Delete(int itemId)
        {


           oClsItems.Delete(itemId);

            return RedirectToAction("List");
        }
    }
}

