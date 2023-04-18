using SunriseSunsetWallpaperDesktopChanger.IP;
using SunriseSunsetWallpaperDesktopChanger.SunriseSunset;
using SunriseSunsetWallpaperDesktopChanger.Utilities;
using SunriseSunsetWallpaperDesktopChanger.Wallpaper;

public class Program
{
    public static void Main(string[] args)
    {
        /*
           =============================================================
           =============================================================
              The API endoints used in this script are free to use.
              https://api.techniknews.net/ipgeo/{$ipAddress}
              https://ipinfo.io/ip
              https://api.sunrisesunset.io/json?lat={$latitude}&lng={$longetitude}&timezone=UTC&date=today

           =============================================================
           =============================================================
        */

        Console.WriteLine("------------------------ SCRIPT STARTED ------------------------");
        try
        {
            // Get your IP Address
            IPAddress ipAddress = GetIPAddress.getIPAddress("https://ipinfo.io/ip");
            Console.WriteLine(String.Format("Your IP Address is: {0}", ipAddress.ip));

            // Get the coordinates (latitude & longitude) based on your IP Address
            string responseIP = GetCoordinatesFromIP.getInfoFromIPRequest("https://api.techniknews.net/ipgeo/" + ipAddress.ip);
            CoordinatesFromIP informationFromIP = GetCoordinatesFromIP.parseInfoFromIPRequest(responseIP);

            string endpoint = String.Format("https://api.sunrisesunset.io/json?lat={0}&lng={1}&timezone=UTC&date=today", informationFromIP.lat, informationFromIP.lat);

            string currentWallpaper = WallpaperHandler.getCurrentWallpaper();

            while (true) 
            {
                DateTime lastTimeRequest = new DateTime();

                SunriseSunsetInformation sunriseSunsetInformation = new SunriseSunsetInformation();

                /* Check if the last time it made the request to get the 
                 * information from the API, is the day before the current day
                 */
                if (lastTimeRequest < DateTime.Now.Date)
                {
                    string responseSunriseSunsetAPI = GetInfoFromRequest.getInfoFromAPI(endpoint);
                    sunriseSunsetInformation = GetInfoFromRequest.parseInfoFromAPI(responseSunriseSunsetAPI);
                    lastTimeRequest = DateTime.Now.Date;
                }
                
                if ((DateTime.Now >= DateTime.Parse(sunriseSunsetInformation.dawn)) && 
                    (DateTime.Now < DateTime.Parse(sunriseSunsetInformation.sunrise)))
                {
                    // TODO: implement to change the time and change the wallpaper with dusk
                    string wallpaperPath = WallpaperHandler.getPhoto("Dawn");
                    

                }
                else if ((DateTime.Now >= DateTime.Parse(sunriseSunsetInformation.sunrise)) &&
                    (DateTime.Now < DateTime.Parse(sunriseSunsetInformation.sunrise).AddMinutes(15)))
                {
                    string wallpaperPath = WallpaperHandler.getPhoto("Sunrise");
                }

                else if ((DateTime.Now >= DateTime.Parse(sunriseSunsetInformation.dusk)) &&
                    (DateTime.Now < DateTime.Parse(sunriseSunsetInformation.sunset)))
                {
                    string wallpaperPath = WallpaperHandler.getPhoto("Dusk");
                }
                else if ((DateTime.Now >= DateTime.Parse(sunriseSunsetInformation.sunset)) &&
                    (DateTime.Now < DateTime.Parse(sunriseSunsetInformation.sunset).AddMinutes(15)))
                {
                    string wallpaperPath = WallpaperHandler.getPhoto("Sunset");
                }
            }
            


        }
        catch (Exception e)
        {
            Console.WriteLine("There was an exception: {0} {1} {2} {3}", e.Message, "\n", e.Source, "\n", e.StackTrace);
        }

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}