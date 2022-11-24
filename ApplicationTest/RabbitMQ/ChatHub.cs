using Microsoft.AspNetCore.SignalR;

namespace RabbitMQ
{
    public class ChatHub : Hub
    {
        private static string _connectionId = "1234567";
        public async Task SendMessage(string user, string message)
        {
            await Clients.Client(_connectionId).SendAsync("ReceiveMessage", user, "done");
        }
    }
}
