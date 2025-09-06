using RabbitMQ.Client;
using System.Text;

namespace Cookbook.Integrations.RabbitMQ;

public static class Producer
{
    public static async Task Run()
    {
        ConnectionFactory factory = new ConnectionFactory() { HostName = "localhost" };
        IConnection? connection = null;
        IChannel? channel = null;
        try
        {
            connection = await factory.CreateConnectionAsync();
            channel = await connection.CreateChannelAsync();

            await channel.QueueDeclareAsync(queue: "demo-queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            string message = "Hello RabbitMQ Demo";
            var body = Encoding.UTF8.GetBytes(message);

            var props = new BasicProperties();
            await channel.BasicPublishAsync(exchange: string.Empty,
                                 routingKey: "demo-queue",
                                 mandatory: false,
                                 basicProperties: props,
                                 body: body);

            Console.WriteLine($"[Producer] Sent: {message}");
            // Console.WriteLine($"[Producer] Press [enter] to exit.");
            // Console.ReadLine();
        }
        finally
        {
            if (channel != null)
            {
                await channel.DisposeAsync();
            }
            if (connection != null)
            {
                await connection.DisposeAsync();
            }
        }
    }
}