using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Models
{
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

        public DateTime Day{ get; set; }

        public static float KelvinToCelsius(float kelvinVal)
        {
            return kelvinVal - KELVIN_CELSIUS_DIFFERENCE;
        }
    }
}
