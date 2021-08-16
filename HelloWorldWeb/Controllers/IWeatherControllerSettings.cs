// <copyright file="IWeatherControllerSettings.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HelloWorldWeb.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Latitude { get; set; }

        string Longitude { get; set; }

        string ApiKey { get; set; }
    }
}