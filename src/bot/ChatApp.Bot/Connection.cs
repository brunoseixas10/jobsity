using Microsoft.AspNetCore.SignalR.Client;

namespace ChatApp.Bot
{
    internal class Connection
    {
        public static HubConnection Conn { get; private set; }

        public static void Start()
        {
            Conn = new HubConnectionBuilder().WithUrl("http://localhost:5019/chat").Build();
        }
    }
}
