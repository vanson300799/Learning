using Microsoft.AspNetCore.SignalR;

namespace SignalRTest.Models
{
    public class ChatHub : Hub
    {
        private static string _connectionId = "j3FnvR236IZ2Llvcea0EYg";
        protected IHubContext<ChatHub> _context;

        public ChatHub(IHubContext<ChatHub> context)
        {
            _context = context;
        }
        public override Task OnConnectedAsync()
        {
            var test = Context;
            return base.OnConnectedAsync();
        }

        public async Task SendMessage(string user, string message)
        {
            await _context.Clients.All.SendAsync("ReceiveMessage", user, "done 1");
        }
    }
}
