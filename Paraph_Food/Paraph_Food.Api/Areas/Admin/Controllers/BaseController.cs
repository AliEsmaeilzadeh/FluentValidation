using Microsoft.AspNetCore.Mvc;
using Paraph_Food.Api.Configurations.Culture;
using Paraph_Food.Api.Models;
using Paraph_Food.Application.Services.Common.Exceptions;
using System;
using System.Threading;

namespace Paraph_Food.Api.Areas.Admin.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
            Thread.CurrentThread.CurrentUICulture =
            Thread.CurrentThread.CurrentUICulture = Culture.GetDefaultCulture;
        }


        internal IActionResult HandleError(MyException ex)
        {
            return BadRequest(new ErrorViewModel(ex));
        }
        internal IActionResult HandleError(Exception ex)
        {
            return BadRequest(new ErrorViewModel(ex));
        }

    }
}