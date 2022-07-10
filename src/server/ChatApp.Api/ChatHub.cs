using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace ChatApp.Api
{
    public class ChatHub : Hub
    {
        public static ConcurrentBag<(string, string, DateTime)> Messages;

        public ChatHub()
        {
            if (Messages == null)
                Messages = new ConcurrentBag<(string, string, DateTime)>();
        }

        public async Task NewMessage(string userName, string message, DateTime dateTime)
        {
            Messages.Add((userName, message, dateTime));
            await Clients.All.SendAsync("newMessage", userName, message, dateTime);
        }
    }
}
