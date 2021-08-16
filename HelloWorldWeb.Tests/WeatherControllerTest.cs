using HelloWorldWeb.Controllers;
using HelloWorldWeb.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class WeatherControllerTest
    {

        public WeatherController weatherControllerMock;
        public Mock<IWeatherControllerSettings> weatherSettingsMock;

        private void InitializeWeatherControllerMock()
        {
            weatherSettingsMock = new Mock<IWeatherControllerSettings>();
            /*weatherSettingsMock.Setup(_ => _.ApiKey).Returns("asd");*/
            weatherControllerMock = new WeatherController(weatherSettingsMock.Object);
        }

        [Fact]
        public void CheckConversionTest()
        {
            //Assume
            InitializeWeatherControllerMock();
            string content = LoadJsonFromResource();
            //Act
            var result = weatherControllerMock.ConvertResponseToWeatherRecordList(content);

            //Assert
            Assert.Equal(7, result.Count());
            
            var firstDay = result.First();
            Assert.Equal(new DateTime(2021, 08, 12), firstDay.Day);
            Assert.Equal(DailyWeatherRecord.KelvinToCelsius(297.88f), firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }

        private string LoadJsonFromResource()
        {
            var assembly = this.GetType().Assembly;
            var assemblyName = assembly.GetName().Name;
            var resourceName = $"{assemblyName}.TestData.ContentFromWeatherAPI.json";
            var resourceStream = assembly.GetManifestResourceStream(resourceName);
            using (var tr = new StreamReader(resourceStream))
            {
                return tr.ReadToEnd();
            }
        }
    }
}
