using System;
using System.Runtime.InteropServices;
using System.IO;
using Microsoft.Win32;
using SunriseSunsetWallpaperDesktopChanger.SunriseSunset;
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

        private RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Control Panel\\Desktop", true);

        public string getCurrentWallpaper()
        {
            string pathCurrentWallpaper = "";

            if (regKey != null)
            {
                pathCurrentWallpaper = regKey.GetValue("WallPaper").ToString();
                regKey.Close();
            }
            return pathCurrentWallpaper;
        }

        public void changeWallpaper(string pathOfWallpaper)
        {
            regKey.SetValue(@"WallpaperStyle", 0.ToString());
            regKey.SetValue(@"TileWallpaer", 0.ToString());

            SystemParametersInfo(
                SPI_SETDESKWALLPAPER, 
                0, 
                pathOfWallpaper, 
                SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public static bool checkIfWallpaperShouldBeChanged(DateTime currentTime, DateTime actionTime)
        {
            if (currentTime >= actionTime)
            {
                return true;
            }
            return false;
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
