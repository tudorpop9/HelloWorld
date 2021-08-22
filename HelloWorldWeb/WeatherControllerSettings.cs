// <copyright file="WeatherControllerSettings.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using HelloWorldWeb.Controllers;
using Microsoft.Extensions.Configuration;

namespace HelloWorldWeb
{
    /// <summary>
    /// Class that extracts date from config file.
    /// </summary>
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