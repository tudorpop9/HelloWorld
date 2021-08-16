// <copyright file="WeatherControllerTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HelloWorldWeb.Controllers;
using HelloWorldWeb.Models;
using Moq;
using Xunit;

namespace HelloWorldWeb.Tests
{
    public class WeatherControllerTest
    {
        private WeatherController weatherControllerMock;
        private Mock<IWeatherControllerSettings> weatherSettingsMock;

        [Fact]
        public void CheckConversionTest()
        {
            // Assume
            InitializeWeatherControllerMock();
            string content = LoadJsonFromResource();

            // Act
            var result = weatherControllerMock.ConvertResponseToWeatherRecordList(content);

            // Assert
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

        private void InitializeWeatherControllerMock()
        {
            weatherSettingsMock = new Mock<IWeatherControllerSettings>();
            /*weatherSettingsMock.Setup(_ => _.ApiKey).Returns("asd");*/
            weatherControllerMock = new WeatherController(weatherSettingsMock.Object);
        }
    }
}
