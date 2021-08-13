// <copyright file="Startup.cs" company="Principal33">
// Copyright (c) Principal33. All rights reserved.
// </copyright>

using HelloWorldWeb.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWeb
{
    public class WeatherControllerSettings : IWeatherControllerSettings
    {
        public WeatherControllerSettings(IConfiguration config)
        {
            ApiKey = config["WeatherForecast:ApiKey"];
            Latitude = config["WeatherForecast:Latitude"];
            Longitude = config["WeatherForecast:Longitude"];
        }

        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ApiKey { get; set; }
    }
}