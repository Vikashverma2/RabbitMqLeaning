using System;

namespace Producer.Services;

public interface IMessagePublisher
{
    Task SendMessage(string message);
}
