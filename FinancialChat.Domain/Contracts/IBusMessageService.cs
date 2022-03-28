using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Contracts
{
    /// <summary>
    /// Interface to operate with Bus message queues
    /// </summary>
    public interface IBusMessageService
    {
        /// <summary>
        /// Allow to send messages to a queue
        /// </summary>
        /// <param name="message">Json message to send at the Queue</param>
        Task SendMessage(string message);

        /// <summary>
        /// Get a message from the queue bus
        /// </summary>
        /// <returns>The message found to consume</returns>
        Task<string> ReceiveMessage();

        /// <summary>
        /// Get a list of pending messages from the queue bus
        /// </summary>
        /// <returns>The messages found to consume</returns>
        Task<List<string>> ReceiveMessages();
    }
}
