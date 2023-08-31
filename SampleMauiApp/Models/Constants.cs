namespace SampleMauiApp.Models;

public static class Constants
{
    public static string ApplicationName = "SampleMauiApp";
    public static string EmailAddress = @"Tube Player";
    public static string ApplicationId = "Tube Player";
    public static string ApiServiceURL = @"https://www.googleapis.com/youtube/v3/";
    public static string ApiKey = "AIzaSyBxaxrFliK7VuD_MUooG8BtcJ65-XPUu7A";


    public static uint MicroDuration { get; set; } = 100;
    public static uint SmallDuration { get; set; } = 300;
    public static uint MediumDuration { get; set; } = 600;
    public static uint LongDuration { get; set; } = 1200;
    public static uint ExtraLongDuration { get; set; } = 1800;
}
