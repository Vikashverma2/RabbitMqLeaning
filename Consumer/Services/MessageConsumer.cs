using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Consumer.Services;

public class MessageConsumer : IMessageConsumer
{
    public async Task StartConsuming()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost"
            
        };

        using var connection = await factory.CreateConnectionAsync();

        using var channel = await connection.CreateChannelAsync();

        string queueName = "test-queue";


        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (sender, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine($"📩 Message received: {message}");

            await Task.Yield();
        };


        await channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: true,
            consumer: consumer,
            cancellationToken: CancellationToken.None
        );

        Console.WriteLine("✅ Consumer started. Waiting for messages...");
        await Task.Delay(Timeout.Infinite);
    }
}
