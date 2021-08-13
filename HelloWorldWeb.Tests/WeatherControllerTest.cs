﻿using HelloWorldWeb.Controllers;
using HelloWorldWeb.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
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
            string content = "{\"lat\":46.77,\"lon\":23.58,\"timezone\":\"Europe / Bucharest\",\"timezone_offset\":10800,\"current\":{\"dt\":1628756246,\"sunrise\":1628738379,\"sunset\":1628790117,\"temp\":296.93,\"feels_like\":296.93,\"pressure\":1020,\"humidity\":60,\"dew_point\":288.71,\"uvi\":4.57,\"clouds\":20,\"visibility\":10000,\"wind_speed\":4.12,\"wind_deg\":300,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}]},\"daily\":[{\"dt\":1628762400,\"sunrise\":1628738379,\"sunset\":1628790117,\"moonrise\":1628753220,\"moonset\":1628797740,\"moon_phase\":0.13,\"temp\":{\"day\":297.88,\"min\":290.15,\"max\":300.58,\"night\":290.78,\"eve\":298.34,\"morn\":291.55},\"feels_like\":{\"day\":297.74,\"night\":289.93,\"eve\":297.96,\"morn\":291.22},\"pressure\":1020,\"humidity\":51,\"dew_point\":287.07,\"wind_speed\":4.82,\"wind_deg\":318,\"wind_gust\":6.71,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":19,\"pop\":0,\"uvi\":6.81},{\"dt\":1628848800,\"sunrise\":1628824856,\"sunset\":1628876420,\"moonrise\":1628844180,\"moonset\":1628885400,\"moon_phase\":0.17,\"temp\":{\"day\":299.73,\"min\":287.45,\"max\":302.08,\"night\":292.34,\"eve\":300.43,\"morn\":287.91},\"feels_like\":{\"day\":299.73,\"night\":291.57,\"eve\":300.22,\"morn\":287.06},\"pressure\":1023,\"humidity\":37,\"dew_point\":283.16,\"wind_speed\":2.68,\"wind_deg\":268,\"wind_gust\":3.78,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":23,\"pop\":0,\"uvi\":6.82},{\"dt\":1628935200,\"sunrise\":1628911334,\"sunset\":1628962722,\"moonrise\":1628935140,\"moonset\":1628973240,\"moon_phase\":0.2,\"temp\":{\"day\":301.8,\"min\":288.91,\"max\":303.99,\"night\":294.36,\"eve\":302.9,\"morn\":289.24},\"feels_like\":{\"day\":300.97,\"night\":293.84,\"eve\":302.45,\"morn\":288.42},\"pressure\":1022,\"humidity\":34,\"dew_point\":283.83,\"wind_speed\":2.03,\"wind_deg\":331,\"wind_gust\":3.53,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":15,\"pop\":0,\"uvi\":7.09},{\"dt\":1629021600,\"sunrise\":1628997812,\"sunset\":1629049023,\"moonrise\":1629026280,\"moonset\":0,\"moon_phase\":0.25,\"temp\":{\"day\":302.99,\"min\":291.66,\"max\":306.04,\"night\":299.67,\"eve\":305.83,\"morn\":291.66},\"feels_like\":{\"day\":302.25,\"night\":299.67,\"eve\":305.35,\"morn\":290.98},\"pressure\":1017,\"humidity\":36,\"dew_point\":285.74,\"wind_speed\":2,\"wind_deg\":281,\"wind_gust\":4.54,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":11,\"pop\":0.07,\"uvi\":6.99},{\"dt\":1629108000,\"sunrise\":1629084289,\"sunset\":1629135322,\"moonrise\":1629117480,\"moonset\":1629061260,\"moon_phase\":0.28,\"temp\":{\"day\":300.3,\"min\":293.35,\"max\":306.9,\"night\":299.03,\"eve\":306.9,\"morn\":293.35},\"feels_like\":{\"day\":300.71,\"night\":298.74,\"eve\":306.27,\"morn\":293.33},\"pressure\":1015,\"humidity\":50,\"dew_point\":288.27,\"wind_speed\":3.45,\"wind_deg\":136,\"wind_gust\":4.69,\"weather\":[{\"id\":500,\"main\":\"Rain\",\"description\":\"light rain\",\"icon\":\"10d\"}],\"clouds\":87,\"pop\":0.7,\"rain\":0.89,\"uvi\":6.24},{\"dt\":1629194400,\"sunrise\":1629170767,\"sunset\":1629221620,\"moonrise\":1629208500,\"moonset\":1629149760,\"moon_phase\":0.31,\"temp\":{\"day\":306.14,\"min\":295.27,\"max\":309.39,\"night\":298.13,\"eve\":306.9,\"morn\":295.27},\"feels_like\":{\"day\":304.74,\"night\":297.81,\"eve\":305.64,\"morn\":294.82},\"pressure\":1010,\"humidity\":27,\"dew_point\":284.07,\"wind_speed\":8.02,\"wind_deg\":224,\"wind_gust\":7.87,\"weather\":[{\"id\":803,\"main\":\"Clouds\",\"description\":\"broken clouds\",\"icon\":\"04d\"}],\"clouds\":69,\"pop\":0.07,\"uvi\":7},{\"dt\":1629280800,\"sunrise\":1629257245,\"sunset\":1629307917,\"moonrise\":1629299100,\"moonset\":1629238800,\"moon_phase\":0.35,\"temp\":{\"day\":302.27,\"min\":292.41,\"max\":304.25,\"night\":296.27,\"eve\":304.11,\"morn\":292.41},\"feels_like\":{\"day\":302.27,\"night\":296.18,\"eve\":303.74,\"morn\":292.27},\"pressure\":1010,\"humidity\":44,\"dew_point\":288.26,\"wind_speed\":4.51,\"wind_deg\":337,\"wind_gust\":4.76,\"weather\":[{\"id\":801,\"main\":\"Clouds\",\"description\":\"few clouds\",\"icon\":\"02d\"}],\"clouds\":15,\"pop\":0.04,\"uvi\":7},{\"dt\":1629367200,\"sunrise\":1629343723,\"sunset\":1629394213,\"moonrise\":1629389040,\"moonset\":1629328560,\"moon_phase\":0.39,\"temp\":{\"day\":300.05,\"min\":291.18,\"max\":302.02,\"night\":292.46,\"eve\":293.84,\"morn\":291.18},\"feels_like\":{\"day\":300.04,\"night\":292.69,\"eve\":294.18,\"morn\":290.94},\"pressure\":1007,\"humidity\":42,\"dew_point\":285.29,\"wind_speed\":3.88,\"wind_deg\":311,\"wind_gust\":4.7,\"weather\":[{\"id\":501,\"main\":\"Rain\",\"description\":\"moderate rain\",\"icon\":\"10d\"}],\"clouds\":66,\"pop\":0.99,\"rain\":9.72,\"uvi\":7}]}";

            //Act
            var result = weatherControllerMock.ConvertResponseToWeatherRecordList(content);

            //Assert
            Assert.Equal(7, result.Count());
            
            var firstDay = result.First();
            Assert.Equal(new DateTime(2021, 08, 12), firstDay.Day);
            Assert.Equal(DailyWeatherRecord.KelvinToCelsius(297.88f), firstDay.Temperature);
            Assert.Equal(WeatherType.FewClouds, firstDay.Type);
        }
    }
}
