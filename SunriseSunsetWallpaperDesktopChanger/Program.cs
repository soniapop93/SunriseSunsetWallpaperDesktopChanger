using SunriseSunsetWallpaperDesktopChanger.IP;
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
            string response = GetCoordinatesFromIP.getInfoFromIPRequest("https://api.techniknews.net/ipgeo/" + ipAddress.ip);
            CoordinatesFromIP informationFromIP = GetCoordinatesFromIP.parseInfoFromIPRequest(response);

        }
        catch (Exception e)
        {
            Console.WriteLine("There was an exception: {0} {1} {2} {3}", e.Message, "\n", e.Source, "\n", e.StackTrace);
        }

        Console.WriteLine("------------------------ SCRIPT FINISHED ------------------------");
    }
}