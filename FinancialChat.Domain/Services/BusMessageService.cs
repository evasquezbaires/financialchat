using Azure.Messaging.ServiceBus;
using FinancialChat.Domain.Constants;
using FinancialChat.Domain.Contracts;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Services
{
    /// <summary>
    /// Implementation of the Bus message service to handle queues
    /// </summary>
    public class BusMessageService : IBusMessageService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Main constructor of the Message service queue
        /// </summary>
        /// <param name="configuration">The global system configuration</param>
        public BusMessageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task SendMessage(string message)
        {
            var connectionString = _configuration["Bot:Bus.Connection"];
            var queueName = _configuration["Bot:Bus.Queue"];

            await using var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(queueName);
            var busMessage = new ServiceBusMessage(message);

            await sender.SendMessageAsync(busMessage);
        }

        /// <inheritdoc/>
        public async Task<string> ReceiveMessage()
        {
            var connectionString = _configuration["Bot:Bus.Connection"];
            var queueName = _configuration["Bot:Bus.Queue"];

            await using var client = new ServiceBusClient(connectionString);
            var receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });
            var receivedMessage = await receiver.ReceiveMessageAsync();

            return receivedMessage.Body.ToString();
        }

        /// <inheritdoc/>
        public async Task<List<string>> ReceiveMessages()
        {
            var connectionString = _configuration["Bot:Bus.Connection"];
            var queueName = _configuration["Bot:Bus.Queue"];
            var result = new List<string>();

            await using var client = new ServiceBusClient(connectionString);
            var receiver = client.CreateReceiver(queueName, new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete });
            var receivedMessages = await receiver.ReceiveMessagesAsync(ChatMessage.MAX_QUEUE);

            foreach(var message in receivedMessages)
            {
                result.Add(message.Body.ToString());
            }

            return result;
        }
    }
}
