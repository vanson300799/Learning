using Microsoft.AspNetCore.SignalR;

namespace ApplicationTest.Models
{
    public class ChatHub : Hub
    {
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
            if(_context.Clients != null)
            {
                await _context.Clients.All.SendAsync("ReceiveMessage", user, "done");
            }
        }
    }
}
