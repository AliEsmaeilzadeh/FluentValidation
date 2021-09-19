using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paraph_Food.Api.Areas.CustomerApp.Controllers
{
    [Area("CustomerApp")]
    public class HomeController : BaseController
    {
        [HttpGet("CustomerApp/Home/StartApi")]
        public IActionResult StartApi()
        {
            return Ok("CustomerApp Api Started");
        }
    }
}
