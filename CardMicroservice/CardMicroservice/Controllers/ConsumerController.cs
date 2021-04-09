using CardMicroservice.UoW;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;

namespace CardMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumerController : ControllerBase
    {
        private readonly string topic = "simpletalk_topic";

        public ConsumerController()
        {
        }


        [Route("/readmessage")]
        [HttpGet]
        public IActionResult Get()
        {
            var conf = new ConsumerConfig
            {
                GroupId = "st_consumer_group",
                BootstrapServers = "kafka:9092",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            using (var builder = new ConsumerBuilder<Ignore,string>(conf).Build())
            {
                builder.Subscribe(topic);

                try
                {
                     var consumer = builder.Consume();
                     return new OkObjectResult($"Message: {consumer.Message.Value} received from {consumer.TopicPartitionOffset}");

                }
                catch (Exception)
                {
                    builder.Close();
                }
            }
            return new OkObjectResult("Not found (((");
        }

    }
}
