using Microsoft.AspNetCore.SignalR;

namespace WebAPI.Hubs
{
    public class TestHub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
