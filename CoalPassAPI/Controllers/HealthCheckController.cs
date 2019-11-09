using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoalPassAPI.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class HealthCheckController : Controller
    {
        public IActionResult Get() => Ok();
    }
}
