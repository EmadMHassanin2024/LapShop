using LapShop.BL;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IClsItems oItems;
        public ItemsController(IClsItems items)
        {
            oItems = items;
        }
        // GET: api/<ItemsController>

        /// <summary>
        /// Get all items from database 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ApiResponse Get()
        {
            ApiResponse oApiResponse = new ApiResponse();
            oApiResponse.Data = oItems.GetAll();
            oApiResponse.Errors = null;
            oApiResponse.StatusCode = "200";

            return oApiResponse;
        }

        // GET api/<ItemsController>/5
        /// <summary>
        /// Get item by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ApiResponse Get(int id)
        {

            ApiResponse oApiResponse = new ApiResponse();
            oApiResponse.Data = oItems.GetById(id);
            oApiResponse.Errors = null;
            oApiResponse.StatusCode = "200";

            return oApiResponse;

        }

        // GET: api/<ItemsController>/5

        [HttpGet("GetByCategoryById/{categoryId}")]

        public ApiResponse GetByCategoryById(int categoryId)
        {
            ApiResponse oApiResponse = new ApiResponse();
            oApiResponse.Data = oItems.GetAllItemData(categoryId);
            oApiResponse.Errors = null;
            oApiResponse.StatusCode = "200";

            return oApiResponse;

        }
        // POST api/<ItemsController>
        [HttpPost]
        public ApiResponse Post([FromBody] TbItem item)
        {
            try
            {
                oItems.Save(item);
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = "Done";
                oApiResponse.Errors = null;
                oApiResponse.StatusCode = "200";
                return oApiResponse;
            }
            catch (Exception ex)
            {
                ApiResponse oApiResponse = new ApiResponse();
                oApiResponse.Data = null;
                oApiResponse.Errors = ex.Message;
                oApiResponse.StatusCode = "502";
                return oApiResponse;
            }

        }


        //[HttpPost]
       // [Route("Delete")]
        //public void Delete([FromBody] int id)
        //{
        //    try
        //    {
        //        oItems.Delete(id);

        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}


    }
}
