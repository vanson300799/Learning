using RabbitMQ;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;


var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "hello",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        //Task.Factory.StartNew(async () => {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        var chatHub = new ChatHub();
        //chatHub.SendMessage("son", message);
        //}, TaskCreationOptions.LongRunning);
    };

    channel.BasicConsume(queue: "hello",
                         autoAck: true,
                         consumer: consumer);
    Console.ReadLine();
}
