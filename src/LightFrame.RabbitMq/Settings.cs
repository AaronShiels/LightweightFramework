namespace LightFrame.RabbitMq
{
    internal class Settings
    {
        public ServiceBusSettings ServiceBus { get; set; }
        public ApplicationSettings Application { get; set; }

        public class ServiceBusSettings
        {
            public string Host { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class ApplicationSettings
        {
            public string Name { get; set; }
        }
    }
}