using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Cookbook.Integrations.RabbitMQ;

public static class Consumer
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

            Console.WriteLine("[Consumer] Waiting for messages...");

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"[Consumer] Received message: {message}");
                Console.WriteLine("[Consumer] Press [enter] to exit.");
                return Task.CompletedTask;
            };

            await channel.BasicConsumeAsync("demo-queue", autoAck: true, consumer: consumer);

            Console.ReadLine();
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