using SunriseSunsetWallpaperDesktopChanger.IP;
using SunriseSunsetWallpaperDesktopChanger.SunriseSunset;
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
            Console.WriteLine(String.Format("Current wallpaper path: {0}", currentWallpaper));

            DateTime lastTimeRequest = DateTime.UtcNow.Date.AddDays(-1);

            SunriseSunsetInformation sunriseSunsetInformation = new SunriseSunsetInformation();

            int timesleepDefaultValue = 5000;
            int minutesDefaultValue = 1;

            while (true)
            {
                try
                {
                    /* Check if the last time it made the request to get the 
                    * information from the API, is the day before the current day
                    */
                    if (lastTimeRequest < DateTime.UtcNow.Date)
                    {
                        string responseSunriseSunsetAPI = GetInfoFromRequest.getInfoFromAPI(endpoint);
                        sunriseSunsetInformation = GetInfoFromRequest.parseInfoFromAPI(responseSunriseSunsetAPI);
                        lastTimeRequest = DateTime.UtcNow.Date;
                    }

                    if ((DateTime.UtcNow >= DateTime.Parse(sunriseSunsetInformation.dawn)) &&
                        (DateTime.UtcNow < DateTime.Parse(sunriseSunsetInformation.sunrise)))
                    {
                        string wallpaperPath = WallpaperHandler.getPhoto("Dawn");
                        WallpaperHandler.changeWallpaper(wallpaperPath);
                        Console.WriteLine(String.Format("Dawn wallpaper path changed: {0}", wallpaperPath));

                        // Sunrise value - Dawn value
                        int timesleepValue = (int)(DateTime.Parse(sunriseSunsetInformation.sunrise) - DateTime.Parse(sunriseSunsetInformation.dawn)).TotalMilliseconds;

                        // Time sleep - default value until changing the wallpaper
                        Thread.Sleep(timesleepValue - timesleepDefaultValue);

                    }
                    else if ((DateTime.UtcNow >= DateTime.Parse(sunriseSunsetInformation.sunrise)) &&
                        (DateTime.UtcNow < DateTime.Parse(sunriseSunsetInformation.sunrise).AddMinutes(minutesDefaultValue)))
                    {
                        string wallpaperPath = WallpaperHandler.getPhoto("Sunrise");
                        WallpaperHandler.changeWallpaper(wallpaperPath);
                        Console.WriteLine(String.Format("Sunrise wallpaper path changed: {0}", wallpaperPath));

                        // Sunrise value - minutesDefaultValue mins
                        int timesleepValue = (int)(DateTime.Parse(sunriseSunsetInformation.sunrise).AddMinutes(minutesDefaultValue) - DateTime.Parse(sunriseSunsetInformation.sunrise)).TotalMilliseconds;

                        // Time sleep - default value until changing back the wallpaper
                        Thread.Sleep(timesleepValue - timesleepDefaultValue);
                        WallpaperHandler.changeWallpaper(currentWallpaper);
                        Console.WriteLine(String.Format("Default wallpaper path changed: {0}", currentWallpaper));
                    }

                    else if ((DateTime.UtcNow >= DateTime.Parse(sunriseSunsetInformation.sunset)) &&
                        (DateTime.UtcNow < DateTime.Parse(sunriseSunsetInformation.dusk)))
                    {
                        string wallpaperPath = WallpaperHandler.getPhoto("Sunset");
                        WallpaperHandler.changeWallpaper(wallpaperPath);
                        Console.WriteLine(String.Format("Sunset wallpaper path changed: {0}", wallpaperPath));

                        // Sunset value - dusk value
                        int timesleepValue = (int)(DateTime.Parse(sunriseSunsetInformation.dusk) - DateTime.Parse(sunriseSunsetInformation.sunset)).TotalMilliseconds;

                        // Time sleep - default value until changing back the wallpaper
                        Thread.Sleep(timesleepValue - timesleepDefaultValue);
                    }

                    else if ((DateTime.UtcNow >= DateTime.Parse(sunriseSunsetInformation.dusk)) &&
                        (DateTime.UtcNow < DateTime.Parse(sunriseSunsetInformation.dusk).AddMinutes(minutesDefaultValue)))
                    {
                        string wallpaperPath = WallpaperHandler.getPhoto("Dusk");
                        WallpaperHandler.changeWallpaper(wallpaperPath);
                        Console.WriteLine(String.Format("Dusk wallpaper path changed: {0}", wallpaperPath));

                        // Sunset value - dusk value
                        int timesleepValue = (int)(DateTime.Parse(sunriseSunsetInformation.sunset).AddMinutes(minutesDefaultValue) - DateTime.Parse(sunriseSunsetInformation.sunset)).TotalMilliseconds;

                        // Time sleep - default value until changing the wallpaper
                        Thread.Sleep(timesleepValue - timesleepDefaultValue);
                        WallpaperHandler.changeWallpaper(currentWallpaper);
                        Console.WriteLine(String.Format("Default wallpaper path changed: {0}", currentWallpaper));
                    }
                    Thread.Sleep(timesleepDefaultValue);
                }
                catch (Exception e)
                {
                    Console.WriteLine("There was an exception in the while: {0} {1} {2} {3}", e.Message, "\n", e.Source, "\n", e.StackTrace);
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