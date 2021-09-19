using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Paraph_Food.Api.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : BaseController
    {
        [HttpGet("Admin/Home/StartApi")]
        public IActionResult StartApi()
        {
            return Ok("Admin Api Started");
        }
    }
}
