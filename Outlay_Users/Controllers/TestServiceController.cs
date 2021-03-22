using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Outlay_Users.Controllers
{
    [ApiController]
    [Route("api/")]
    public class TestServiceController : ControllerBase
    {
        private readonly ILogger<TestServiceController> _logger;

        public TestServiceController(ILogger<TestServiceController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        [Route("test")]
        public string GetService()
        {
            string responseString = "";
            string url = "http://outlay-notbroken-service:8080/api/service";
            double totalTime = 0;
            DateTime CurDate = DateTime.Now;

            WebRequest request;

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    request = WebRequest.Create(url);
                    WebResponse response = request.GetResponse();
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseString += reader.ReadToEnd();
                        }
                    }
                    response.Close();                    
                }
            }
            catch (System.Exception)
            {
                responseString += "Error occured!";
            }

            TimeSpan span = DateTime.Now - CurDate;
            totalTime = span.TotalSeconds;
            responseString += " \nTotal time: " + totalTime + " seconds";

            return responseString;
        }
    }
}
