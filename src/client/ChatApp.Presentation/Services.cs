using ChatApp.Presentation.ViewModel;
using RestSharp;

namespace ChatApp.Presentation
{
    public class Services
    {
        static RestClient client = new RestClient("http://localhost:5019/");

        public static async Task<bool> AddUser(AppUser user)
        {
            try
            {
                var request = new RestRequest("users/add", Method.Post).AddJsonBody(user);
                var response = await client.PostAsync(request);
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (HttpRequestException hex)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public static async Task<bool> Login(AppUser user)
        {
            try
            {
                var request = new RestRequest("login", Method.Post).AddJsonBody(user);
                var response = await client.PostAsync(request);
                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (HttpRequestException hex)
            {
                return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
