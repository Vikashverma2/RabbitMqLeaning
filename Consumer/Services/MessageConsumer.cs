using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer.Services;

public class MessageConsumer : IMessageConsumer
{
    public async Task StartConsuming()
    {
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
        };


        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();


        String queueName = "test-queue";

        await channel.QueueDeclareAsync(
            queue: queueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null
        );

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (sender, e) =>
        {
            var body = e.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);


            Console.WriteLine($"📩 Message received: {message}");

             await Task.CompletedTask;
        };


        consumer.ReceivedAsync += async (sender, eventArgs) =>
        {
            var body = eventArgs.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            Console.WriteLine("📩 Message received:");
            Console.WriteLine(message);
            
             await Task.Yield();
        };  
     
       await channel.BasicConsumeAsync(
            queue: queueName,
            autoAck: true,
            consumer: consumer
        );

         Console.WriteLine("✅ Consumer started. Waiting for messages...");
        await Task.Delay(Timeout.Infinite);

    }

}
