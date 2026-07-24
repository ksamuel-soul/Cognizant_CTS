using Confluent.Kafka;

var config = new ConsumerConfig
{
    BootstrapServers = "localhost:9092",
    GroupId = "chat-group",
    AutoOffsetReset = AutoOffsetReset.Earliest
};

using var consumer = new ConsumerBuilder<Ignore, string>(config).Build();

consumer.Subscribe("chat");

Console.WriteLine("====== Kafka Chat Consumer ======\n");

try
{
    while (true)
    {
        var result = consumer.Consume();

        Console.WriteLine($"Received : {result.Message.Value}");
    }
}
catch (OperationCanceledException)
{
    consumer.Close();
}