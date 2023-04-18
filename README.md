
# SunriseSunsetWallpaperDesktopChanger

Based on your IP, it checks when the dusk/sunrise/sunset/dawn is, and changes the desktop background wallpaper at a specific time (returned on the API response).


## API Reference

#### Get IP

```http
  GET https://ipinfo.io/ip
```

#### Get Coordinates

```http
  GET https://api.techniknews.net/ipgeo/{$ipAddress}
```

#### Get Info for Sunrise/Sunset/Dusk/Dawn

```http
  GET https://api.sunrisesunset.io/json?lat={$latitude}&lng={$longetitude}&timezone=UTC&date=today
```



## What the script does:

- HTTP Request to get your IP -> .nuget package used: RestSharp
- HTTP Request to get Coordinates (latitude & longitude) based on the IP -> .nuget package used: RestSharp
- Filters the response
- HTTP Request to get the Sunrise/Sunset/Dusk/Dawn information-> .nuget package used: RestSharp
- checks the time of the Sunrise/Sunset/Dusk/Dawn and changes the wallpapers -> .nuget package Microsoft.Win32
## Authors

- [@soniapop93](https://github.com/soniapop93)


## 🚀 About Me
This is a personal project that I worked on in my free time to improve my skills in C#. As someone who is passionate about programming, I'm always looking for opportunities to learn and refine my abilities, and this project was a perfect opportunity to do just that.

Throughout this project, I challenged myself to take on new programming concepts and techniques, building on my existing knowledge and perfecting my skills in C#. By working on this project in my spare time, I was able to take my learning to the next level and gain valuable experience that will aid me in my future programming pursuits.

Overall, this project represents my dedication to mastering C# and my commitment to continual learning and growth as a programmer.

