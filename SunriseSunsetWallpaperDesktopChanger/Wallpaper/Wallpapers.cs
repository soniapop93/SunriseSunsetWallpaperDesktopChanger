namespace SunriseSunsetWallpaperDesktopChanger.Wallpaper
{
    public class Wallpapers
    {
        public string currentWallpaper { get; set; }
        public string newWallpaper { get; set; }

        public Wallpapers(string currentWallpaper, string newWallpaper)
        {
            this.currentWallpaper = currentWallpaper;
            this.newWallpaper = newWallpaper;
        }
    }
}
