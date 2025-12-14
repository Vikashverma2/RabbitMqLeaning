
# 🚀 RabbitMQ Messaging System

This project demonstrates asynchronous messaging using RabbitMQ with ASP.NET Web API (.NET 10).
It includes two independent services: a Producer API and a Consumer API.

The Producer sends messages to a RabbitMQ queue, while the Consumer reads and processes them.

Message acknowledgment (ACK) is used to ensure messages are removed only after successful processing.

This helps prevent message loss and improves reliability.
The project is simple and focused to learn only core RabbitMQ concepts.



## ⚙️ Tech Stack

- ASP.NET Web API (.NET 10) – RESTful backend framework
- RabbitMQ – Message broker for asynchronous communication
- RabbitMQ.Client – Official .NET client library
- C# – Backend programming language
- RabbitMQ Management Dashboard – Message monitoring and debugging


## 📁 Features

- Producer API to publish messages to RabbitMQ
- Consumer API to receive and process messages from the queue
- 🔄 Asynchronous Message Handling for non-blocking communication
- ✅ Manual Message Acknowledgment (ACK) to ensure reliable message processing
- 📊 Queue Monitoring using RabbitMQ Management Dashboard
- 🧩 Clean Controller–Service Architecture for better code organization
- 🎯 Learning-focused Implementation without databases or unnecessary abstractions

