using SunriseSunsetWallpaperDesktopChanger.Utilities;
using System.Text.Json;

namespace SunriseSunsetWallpaperDesktopChanger.IP
{
    public class GetCoordinatesFromIP
    {
        public static string getInfoFromIPRequest(string endpoint)
        {
            return RequestManager.getRequest(endpoint);
        }

        public static CoordinatesFromIP parseInfoFromIPRequest(string response)
        {
            CoordinatesFromIP coordinatesFromIP = JsonSerializer.Deserialize<CoordinatesFromIP>(response);

            return coordinatesFromIP;
        }
    }
}
