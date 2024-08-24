using LapShop.Bl;
using LapShop.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LapShop.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        ISettings oClsSettings;
        public SettingController(ISettings oClsSettings)
        {
           this.oClsSettings = oClsSettings;        
        }
        // GET: api/<SettingController>
        [HttpGet]
        public TbSetting Get()
        {
            return oClsSettings.GetAll();
        }

        // GET api/<SettingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SettingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SettingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SettingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
