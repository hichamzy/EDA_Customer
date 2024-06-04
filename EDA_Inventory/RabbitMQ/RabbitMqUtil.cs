using RabbitMQ.Client;
using System.Text;

namespace EDA_Inventory.RabbitMQ
{
    public class RabbitMqUtil : IRabbitMqUtil
    {
        public async Task publishMessageQueue(string routingKey, string eventData)
        {
            ConnectionFactory factory = new()
            {
                UserName = "guest",
                Password = "guest",
                HostName = "localhost",
                VirtualHost = "/",
                Port = 15672,
        };

            try
            {
                IConnection connection = factory.CreateConnection();
                var channel = connection.CreateModel();
                var body = Encoding.UTF8.GetBytes(eventData);
                channel.BasicPublish(exchange: "topic.exchange", routingKey: routingKey, basicProperties: null, body: body);
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to RabbitMQ: {ex.Message}");
                throw;
            }
           
            await Task.CompletedTask;
        }

    }
}
