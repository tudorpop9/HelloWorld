using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWeb.Controllers
{
    /// <summary>
    /// Fetches data from openweather API.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude;
        private readonly string longitude;
        private readonly string apiKey;
        private readonly IWeatherControllerSettings settings;

        public WeatherController(IWeatherControllerSettings settings)
        {
            this.settings = settings;
            latitude = settings.Latitude;
            longitude = settings.Longitude;
            apiKey = settings.ApiKey;
        }

        // GET: api/<WeatherController>
        [HttpGet]
        public IEnumerable<DailyWeatherRecord> Get()
        {
            // https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}
            // https://api.openweathermap.org/data/2.5/onecall?lat=46.7700&lon=23.5800&exclude=hourly,minutely&appid=537221f38b987a406521718bec389b6c
            // $ = string interpolation
            var client = new RestClient($"https://api.openweathermap.org/data/2.5/onecall?lat={latitude}&lon={longitude}&exclude=hourly,minutely&appid={apiKey}");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            return ConvertResponseToWeatherRecordList(response.Content);

           
        }

        public IEnumerable<DailyWeatherRecord> ConvertResponseToWeatherRecordList(string content)
        {
            var json = JObject.Parse(content);

            if (json["daily"] == null)
            {
                throw new Exception($"Api key is not valid: {json["daily"]}.");
            }
            var jsonArray = json["daily"].Take(7);

            return jsonArray.Select(CreateDailyWeatherRecordFromJToken);
        }

        private DailyWeatherRecord CreateDailyWeatherRecordFromJToken(JToken item)
        {
            // DateTime.Date to dismiss hour,minutes and seconds
            long unixDateTime = item.Value<long>("dt");
            DateTime forecastDay = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;

            var tempField = item.SelectToken("temp");
            float forecastTemperature = DailyWeatherRecord.KelvinToCelsius(tempField.Value<float>("day"));

            var weatherTypeString = item.SelectToken("weather")[0].Value<string>("description");
            WeatherType forecastType = ConvertToWeatherType(weatherTypeString);

            return new DailyWeatherRecord(forecastDay, forecastTemperature, forecastType);
        }

        private WeatherType ConvertToWeatherType(string weatherTypeString)
        {
            WeatherType weather;

            switch (weatherTypeString)
            {

                case "thunderstorm with light rain":
                    weather = WeatherType.ThunderstormWithLightRain;
                    break;

                case "thunderstorm with rain":
                    weather = WeatherType.ThunderstormWithRain;
                    break;

                case "thunderstorm with heavy rain":
                    weather = WeatherType.ThunderstormWithHeavyRain;
                    break;

                case "light thunderstorm":
                    weather = WeatherType.LighThunderstorm;
                    break;

                case "thunderstorm":
                    weather = WeatherType.Thunderstorm;
                    break;

                case "heavy thunderstorm":
                    weather = WeatherType.HeavyThunderstorm;
                    break;

                case "ragged thunderstorm":
                    weather = WeatherType.RaggedThunderstorm;
                    break;

                case "thunderstorm with light drizzle":
                    weather = WeatherType.ThunderstormWithLightDrizzle;
                    break;

                case "thunderstorm with drizzle":
                    weather = WeatherType.ThunderstormWithDrizzle;
                    break;

                case "thunderstorm with heavy drizzle":
                    weather = WeatherType.ThunderstormWithHeavyDrizzle;
                    break;

                case "light intensity drizzle":
                    weather = WeatherType.LightIntensityDrizzle;
                    break;

                case "drizzle":
                    weather = WeatherType.Drizzle;
                    break;

                case "heavy intensity drizzle":
                    weather = WeatherType.HeavyIntensityDrizzle;
                    break;

                case "light intensity drizzle rain":
                    weather = WeatherType.LightIntensityDrizzleRain;
                    break;

                case "drizzle rain":
                    weather = WeatherType.DrizzleRain;
                    break;

                case "heavy intensity drizzle rain":
                    weather = WeatherType.HeavyIntensityDrizzleRain;
                    break;


                case "shower rain and drizzle":
                    weather = WeatherType.ShowerRainAndDrizzle;
                    break;


                case "heavy shower rain and drizzle":
                    weather = WeatherType.HeavyShowerRainAndDrizzle;
                    break;


                case "shower drizzle":
                    weather = WeatherType.ShowerDrizzle;
                    break;


                case "light rain":
                    weather = WeatherType.LightRain;
                    break;


                case "moderate rain":
                    weather = WeatherType.ModerateRain;
                    break;


                case "heavy intensity rain":
                    weather = WeatherType.HeavyIntensityRain;
                    break;


                case "very heavy rain":
                    weather = WeatherType.VeryHeavyRain;
                    break;


                case "extreme rain":
                    weather = WeatherType.ExtremeRain;
                    break;


                case "freezing rain":
                    weather = WeatherType.FreezingRain;
                    break;


                case "light intensity shower rain":
                    weather = WeatherType.LightIntensityShowerRain;
                    break;


                case "shower rain":
                    weather = WeatherType.ShowerRain;
                    break;


                case "heavy intensity shower rain":
                    weather = WeatherType.HeavyIntensityShowerRain;
                    break;


                case "ragged shower rain":
                    weather = WeatherType.RaggedShowerRain;
                    break;


                case "light snow":
                    weather = WeatherType.LightSnow;
                    break;


                case "Heavy snow":
                    weather = WeatherType.HeavySnow;
                    break;


                case "Sleet":
                    weather = WeatherType.Sleet;
                    break;


                case "Light shower sleet":
                    weather = WeatherType.LightShowerSleet;
                    break;


                case "Shower sleet":
                    weather = WeatherType.ShowerSleet;
                    break;


                case "Light rain and snow":
                    weather = WeatherType.LightRainAndSnow;
                    break;


                case "Rain and snow":
                    weather = WeatherType.RainAndSnow;
                    break;


                case "Light shower snow":
                    weather = WeatherType.LightShowerSnow;
                    break;


                case "Shower snow":
                    weather = WeatherType.ShowerSnow;
                    break;


                case "Heavy shower snow":
                    weather = WeatherType.HeavyShowerSnow;
                    break;


                case "mist":
                    weather = WeatherType.Mist;
                    break;


                case "Haze":
                    weather = WeatherType.Haze;
                    break;


                case "sand/ dust whirls":
                    weather = WeatherType.SandDustWhirls;
                    break;


                case "fog":
                    weather = WeatherType.Fog;
                    break;


                case "sand":
                    weather = WeatherType.Sand;
                    break;


                case "dust":
                    weather = WeatherType.Dust;
                    break;


                case "volcanic ash":
                    weather = WeatherType.VolcanicAsh;
                    break;


                case "squalls":
                    weather = WeatherType.Squalls;
                    break;


                case "tornado":
                    weather = WeatherType.Tornado;
                    break;


                case "clear sky":
                    weather = WeatherType.ClearSky;
                    break;


                case "few clouds":
                    weather = WeatherType.FewClouds;
                    break;


                case "scattered clouds":
                    weather = WeatherType.ScatteredClouds;
                    break;


                case "broken clouds":
                    weather = WeatherType.BrokenClouds;
                    break;


                case "overcast clouds":
                    weather = WeatherType.OvercastClouds;
                    break;

                default:
                    throw new Exception($"Unkown weather type {weatherTypeString}.");
            }

            return weather;
        }

        // GET api/<WeatherController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        
    }
}
