namespace HelloWorldWeb.Controllers
{
    public interface IWeatherControllerSettings
    {
        string Latitude { get; set; }
        string Longitude { get; set; }
        string ApiKey { get; set; }
    }
}