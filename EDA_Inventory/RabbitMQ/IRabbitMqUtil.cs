
namespace EDA_Inventory.RabbitMQ
{
    public interface IRabbitMqUtil
    {
        Task publishMessageQueue(string routingKey, string eventData);
    }
}