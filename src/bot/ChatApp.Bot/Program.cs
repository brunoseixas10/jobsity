using ChatApp.Bot;
using Microsoft.AspNetCore.SignalR.Client;

Connect();

static async void Connect()
{
    Connection.Start();

    Connection.Conn.On<string, string, DateTime>("newMessage", async (username, message, datetime) =>
    {
        if (username != "BOT" && message.Contains("/stock="))
        {
            var stock_code = message.Split("/stock=").Last();
            if (!string.IsNullOrWhiteSpace(stock_code))
            {
                Console.WriteLine("Process...");

                var result = await Stock.Process(stock_code);
                if (!string.IsNullOrWhiteSpace(result))
                    await Connection.Conn.SendAsync("newMessage", "BOT", result, DateTime.Now);

                Console.WriteLine("Done! Message has been sent.");
            }
        }
    });

    await Connection.Conn.StartAsync();
}

Console.WriteLine("Ready... waiting for stock messages.");
Console.ReadKey();
