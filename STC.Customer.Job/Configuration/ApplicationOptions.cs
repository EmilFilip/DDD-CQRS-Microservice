using STC.Customer.Infrastructure.Configuration;

namespace STC.Customer.Job.Configuration
{
    public class ApplicationOptions
    {
        public RabbitMqOptions RabbitMQ { get; } = new RabbitMqOptions();
        public string ServiceName { get; set; }
    }
}
