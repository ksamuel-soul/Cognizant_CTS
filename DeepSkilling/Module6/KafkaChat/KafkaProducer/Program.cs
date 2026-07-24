using Confluent.Kafka;

var config = new ProducerConfig
{
    BootstrapServers = "localhost:9092"
};

using var producer = new ProducerBuilder<Null, string>(config).Build();

Console.WriteLine("====== Kafka Chat Producer ======");

while (true)
{
    Console.Write("Enter Message : ");

    string? message = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(message))
        continue;

    try
    {
        await producer.ProduceAsync(
            "chat",
            new Message<Null, string>
            {
                Value = message
            });

        Console.WriteLine("Message Sent Successfully\n");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}