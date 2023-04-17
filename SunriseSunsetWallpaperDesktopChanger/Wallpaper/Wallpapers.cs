namespace SunriseSunsetWallpaperDesktopChanger.Wallpaper
{
    public class Wallpapers
    {
        public string currentWallpaper { get; set; }
        public string newWallpaper { get; set; }

        public DateTime timeWallpaperChanged { get; set; }

        public Wallpapers(string currentWallpaper, string newWallpaper, DateTime timeWallpaperChanged)
        {
            this.currentWallpaper = currentWallpaper;
            this.newWallpaper = newWallpaper;
            this.timeWallpaperChanged = timeWallpaperChanged;
        }
    }
}
