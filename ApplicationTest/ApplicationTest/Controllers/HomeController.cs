using ApplicationTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using RabbitMQ.Client;
using System.Text;

namespace ApplicationTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            _hubContext = hubContext;
        }

        public async Task<IActionResult> Index()
        {
            var chatHub = new ChatHub(_hubContext);
            await chatHub.SendMessage("Son", "tesst");
            return View();
        }
        [HttpPost]
        public IActionResult PostRabbitMQ(string data)
        {
            var test = data;
            return Json(test);
        }
        public IActionResult Post()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

                string message = "";
                for (int i = 0; i < 10; i++)
                {
                    var body = Encoding.UTF8.GetBytes(message + i);
                    channel.BasicPublish(exchange: "",
                                 routingKey: "hello",
                                 basicProperties: null,
                                 body: body);
                }
            }
            return Json(new { Success = true });
        }

    }
}