// <copyright file="DailyWeatherRecord.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
    /// <summary>
    /// Daily record object.
    /// </summary>
    public class DailyWeatherRecord
    {
        public const float KELVIN_CELSIUS_DIFFERENCE = 273.15f;

        public DailyWeatherRecord(DateTime day, float temperature, WeatherType type)
        {
            Day = day;
            Temperature = temperature;
            Type = type;
        }

        public float Temperature { get; set; }

        public WeatherType Type { get; set; }

        public DateTime Day { get; set; }

        public static float KelvinToCelsius(float kelvinVal)
        {
            return kelvinVal - KELVIN_CELSIUS_DIFFERENCE;
        }
    }
}
