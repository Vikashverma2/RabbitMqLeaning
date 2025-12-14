using System;
using System.Text;
using RabbitMQ.Client;

namespace Producer.Services;

public class MessagePublisher : IMessagePublisher
{
    public async Task SendMessage(string message)
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
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

        var body = Encoding.UTF8.GetBytes(message);

        await channel.BasicPublishAsync(
            exchange: "",
            routingKey: queueName,
            body: body
        );

        Console.WriteLine($"message send: {message}");
    }

}
