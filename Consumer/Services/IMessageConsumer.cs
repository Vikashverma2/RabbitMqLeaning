using System;

namespace Consumer.Services;

public interface IMessageConsumer
{
    Task StartConsuming();

}
