using SunriseSunsetWallpaperDesktopChanger.IP;
using SunriseSunsetWallpaperDesktopChanger.SunriseSunset;
using SunriseSunsetWallpaperDesktopChanger.Utilities;

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
            

            while (true) 
            {
                DateTime lastTimeRequest = new DateTime();

                /* Check if the last time it made the request to get the 
                 * information from the API, is the day before the current day
                 */
                if (lastTimeRequest < DateTime.Now.Date)
                {
                    string responseSunriseSunsetAPI = GetInfoFromRequest.getInfoFromAPI(endpoint);
                    SunriseSunsetInformation sunriseSunsetInformation = GetInfoFromRequest.parseInfoFromAPI(responseSunriseSunsetAPI);
                    lastTimeRequest = DateTime.Now.Date;
                }

                // TODO: implement to change the time and change the wallpapers


            }
            


        }
        catch (Exception e)
        {
            Console.WriteLine("There was an exception: {0} {1} {2} {3}", e.Message, "\n", e.Source, "\n", e.StackTrace);
        }

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}