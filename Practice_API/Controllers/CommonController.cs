using BussinessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Practice_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        private readonly ICommon _common;
        public CommonController(ICommon common)
        {
            _common = common;
        }

        [HttpGet("GetListCountries")]
        public IActionResult GetListOfCountry()
        {
            try
            {
                var country = _common.GetListOfCountry();
                if(country!=null)
                {
                    return Ok(country);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Failed to get ListCountries" + ex);
            }
        }
    }
}
