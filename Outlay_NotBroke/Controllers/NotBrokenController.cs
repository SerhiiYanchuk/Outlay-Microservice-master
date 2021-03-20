using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Outlay_NotBroke.Controllers
{
    [ApiController]
    [Route("api/")]
    public class NotBrokenController : ControllerBase
    {
        
        private readonly ILogger<NotBrokenController> _logger;

        public NotBrokenController(ILogger<NotBrokenController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("break")]
        public string GetBreak([FromServices] IGood goodService)
        {
            goodService.isGood = false;
            return "Service is broken";
        }

        [HttpGet]
        [Route("service")]
        public string GetService([FromServices] IGood goodService)
        {
            if (goodService.isGood)
                return "Service works really fast!!! Hi from normal service";
            else 
            {
                Thread.Sleep(20000);
                return "Hi from broke service, I'm very slow";
            }
        }
    }
}
