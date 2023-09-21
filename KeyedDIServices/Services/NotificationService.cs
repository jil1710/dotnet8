namespace KeyedDIServices.Services
{
    public class SmsNotificationService : INotificationService
    {
        public string Notify(string message) => $"[SMS] : {message}";
    }

    public class EmailNotificationService : INotificationService
    {
        public string Notify(string message) => $"[Email] : {message}";
    }

    public class PushNotificationService : INotificationService
    {
        public string Notify(string message) => $"[Push] : {message}";
    }
}
