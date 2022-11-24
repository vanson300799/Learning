using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRTest.Models;
using System.Diagnostics;
using System.Text;

namespace SignalRTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHubContext<ChatHub> _context;

        public HomeController(ILogger<HomeController> logger, IHubContext<ChatHub> context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Post()
        {
            var chatHub = new ChatHub(_context);
            chatHub.SendMessage("sonw", "test");
            return Json(new { Success = true });
        }
    }
}