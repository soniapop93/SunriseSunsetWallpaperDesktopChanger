using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunriseSunsetWallpaperDesktopChanger.SunriseSunset
{
    public class SunriseSunsetInformation
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
        public string dawn { get; set; }
        public string dusk { get; set; }

        public SunriseSunsetInformation(string sunrise, string sunset, string dawn, string dusk)
        {
            this.sunrise = sunrise;
            this.sunset = sunset;
            this.dawn = dawn;
            this.dusk = dusk;
        }
    }
}
