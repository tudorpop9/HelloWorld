// <copyright file="IWeatherControllerSettings.cs" company="Principal33 Solutions">
// Copyright (c) Principal33 Solutions. All rights reserved.
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