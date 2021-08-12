using HelloWorldWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloWorldWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly string latitude = "46.7700";
        private readonly string longitude = "23.5800";
        private readonly string apiKey = "537221f38b987a406521718bec389b6c";

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

            List<DailyWeatherRecord> result = new List<DailyWeatherRecord>();
            var jsonArray = json["daily"];

            foreach (var item in jsonArray.Take(7))
            {
                //TODO: convert item to a DailyWeatherRecord
                
                
                

                DailyWeatherRecord dailyWeatherRecord = new DailyWeatherRecord(new DateTime(2021, 08, 12), 22.0f, WeatherType.Mild);

                // DateTime.Date to dismiss hour,minutes and seconds
                long unixDateTime = item.Value<long>("dt");
                dailyWeatherRecord.Day = DateTimeOffset.FromUnixTimeSeconds(unixDateTime).DateTime.Date;

                var tempField = item.SelectToken("temp");
                dailyWeatherRecord.Temperature = tempField.Value<float>("day");

                var weatherTypeString = item.SelectToken("weather")[0].Value<string>("description");
                dailyWeatherRecord.Type = Convert(weatherTypeString);

                result.Add(dailyWeatherRecord);
            }

            return result;
        }

        private WeatherType Convert(string weatherTypeString)
        {
            WeatherType weather;

            switch (weatherTypeString)
            {
                case "few clouds":
                    weather = WeatherType.FewClouds;
                    break;

                case "light rain":
                    weather = WeatherType.LighRain;
                    break;

                case "broken clouds":
                    weather = WeatherType.BrokenClouds;
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
