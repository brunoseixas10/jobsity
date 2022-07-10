using RestSharp;
using System.Globalization;

namespace ChatApp.Bot
{
    internal class Stock
    {
        public static async Task<string> Process(string stock_code)
        {
            var client = new RestClient($"https://stooq.com/q/l/?s={stock_code.Trim().ToLower()}&f=sd2t2ohlcv&h&e=csv");
            var request = new RestRequest();

            var response = await client.DownloadStreamAsync(request);
            var content = string.Empty;
            using (var reader = new StreamReader(response))
            {
                while (!reader.EndOfStream)
                {
                    content = await reader.ReadLineAsync();
                    if (!string.IsNullOrWhiteSpace(content) && content.StartsWith("Symbol")) //header
                        continue;
                    else break;
                }

                var stock_open_value = Convert.ToDecimal(content?.Split(',')[3], CultureInfo.InvariantCulture);
                return $"{stock_code.ToUpper()} quote is ${stock_open_value} per share";
            }
        }
    }
}
