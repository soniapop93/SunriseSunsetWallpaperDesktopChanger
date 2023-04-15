using RestSharp;

namespace SunriseSunsetWallpaperDesktopChanger.Utilities
{
    public class RequestManager
    {
        public static string getRequest(string apiEndpoint)
        {
            Console.WriteLine("Will request response from endpoint: {0}", apiEndpoint);
            string responseContent = "";
            RestClient client = new RestClient(apiEndpoint);

            RestRequest request = new RestRequest()
            {
                Method = Method.Get
            };
            RestResponse<string> response = client.Execute<string>(request);

            if (response.Content != null)
            {
                responseContent = response.Content;
            }
            return responseContent;
        }
    }
}
