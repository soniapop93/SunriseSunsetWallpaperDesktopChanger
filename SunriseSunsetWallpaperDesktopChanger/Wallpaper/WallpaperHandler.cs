using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Globalization;

namespace SunriseSunsetWallpaperDesktopChanger.Wallpaper
{
    public class WallpaperHandler
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SystemParametersInfo(
            UInt32 action, 
            UInt32 uParam, 
            String vParam, 
            UInt32 winIni);

        private static readonly UInt32 SPI_SETDESKWALLPAPER = 0x14;
        private static readonly UInt32 SPIF_UPDATEINIFILE = 0x01;
        private static readonly UInt32 SPIF_SENDWININICHANGE = 0x02;

        

        public static string getCurrentWallpaper()
        {
            string pathCurrentWallpaper = "";
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", false);

            if (regKey != null)
            {
                pathCurrentWallpaper = regKey.GetValue("WallPaper").ToString();
                regKey.Close();
            }
            return pathCurrentWallpaper;
        }

        public static void changeWallpaper(string pathOfWallpaper)
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

            regKey.SetValue(@"WallpaperStyle", "2"); // set it as Stretched
            regKey.SetValue(@"TileWallpaer", "0");

            SystemParametersInfo(
                SPI_SETDESKWALLPAPER,
                0,
                pathOfWallpaper,
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static string getPhoto(string actionType)
        {
            string path = @"C:\Users\" + System.Environment.UserName + @"\Documents\SunriseSunsetWallpaperDesktopChanger\SunriseSunsetWallpaperDesktopChanger\Wallpapers";

            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            actionType = textInfo.ToTitleCase(actionType);

            List<string> filesList = Directory.GetFiles(path + "\\" + actionType, "*.jpg", SearchOption.AllDirectories).ToList();

            Random rnd = new Random();
            string filePath = filesList[rnd.Next(filesList.Count)];

            return filePath;
        }
    }
}
