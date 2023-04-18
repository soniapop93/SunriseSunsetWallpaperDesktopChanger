using System.Text.Json;
using System.Text.Json.Nodes;
using SunriseSunsetWallpaperDesktopChanger.Utilities;

namespace SunriseSunsetWallpaperDesktopChanger.SunriseSunset
{
    public class GetInfoFromRequest
    {
        public static string getInfoFromAPI(string endpoint)
        {
            return RequestManager.getRequest(endpoint);
        }
        
        public static SunriseSunsetInformation parseInfoFromAPI(string response)
        {
            JsonObject jObjectResponse = (JsonObject)JsonObject.Parse(response);
            SunriseSunsetInformation sunriseSunsetInformation = JsonSerializer.Deserialize<SunriseSunsetInformation>(jObjectResponse["results"]);
            
            return sunriseSunsetInformation;
        }
    }
}
