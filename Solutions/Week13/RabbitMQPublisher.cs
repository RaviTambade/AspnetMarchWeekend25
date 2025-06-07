// File: RabbitMQPublisher.cs (in LoanBot.Infrastructure)
using LoanBot.Core.Models;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace LoanBot.Infrastructure
{
    public class RabbitMQPublisher
    {
        private readonly IModel _channel;

        public RabbitMQPublisher()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            var connection = factory.CreateConnection();
            _channel = connection.CreateModel();
            _channel.QueueDeclare(queue: "loan_applications", durable: false, exclusive: false, autoDelete: false);
        }

        public void Publish(LoanApplicationEvent appEvent)
        {
            var message = JsonConvert.SerializeObject(appEvent);
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "", routingKey: "loan_applications", basicProperties: null, body: body);
        }
    }

    public class RabbitMQConsumer
    {
        private readonly AppDbContext _context;

        public RabbitMQConsumer(AppDbContext context)
        {
            _context = context;
        }

        public void StartListening()
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "loan_applications", durable: false, exclusive: false, autoDelete: false);
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var appEvent = JsonConvert.DeserializeObject<LoanApplicationEvent>(message);

                if (appEvent != null)
                {
                    var application = new LoanApplication
                    {
                        Applicant = appEvent.Applicant,
                        LoanType = appEvent.LoanType,
                        Bank = appEvent.Bank,
                        Timestamp = appEvent.Timestamp
                    };

                    _context.LoanApplications.Add(application);
                    _context.SaveChanges();
                    Console.WriteLine($"[✔] Application saved for {application.Applicant}");
                }
            };

            channel.BasicConsume(queue: "loan_applications", autoAck: true, consumer: consumer);

            Console.WriteLine(" [*] Waiting for loan application events. Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}