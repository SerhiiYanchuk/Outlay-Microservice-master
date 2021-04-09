using System;
using System.Collections.Generic;
using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ProducerMicroservice.Controllers
{
    [Route("api/kafka")]
    [ApiController]
    public class KafkaProducerController : ControllerBase
    {
        private readonly ProducerConfig config = new ProducerConfig
                                { BootstrapServers = "kafka:9092"};
        private readonly string topic = "simpletalk_topic";

        [HttpGet]
        public IActionResult Get()
        {
            return Created(string.Empty, SendToKafka(topic, "omg"));
        }
        private Object SendToKafka(string topic, string message)
        {
            using (var producer =
                 new ProducerBuilder<Null, string>(config).Build())
            {
                try
                {
                    return producer.ProduceAsync(topic, new Message<Null, string> { Value = message })
                        .GetAwaiter()
                        .GetResult();
                    //producer.Produce(topic, new Message<Null, string> { Value = message });
                }
                catch (Exception e)
                {
                    return $"Oops, something went wrong: {e}";
                }
            }
            return "null";
        }
    }
}
