using FinancialChat.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Contracts
{
    /// <summary>
    /// Interface to operate with Buffer content
    /// </summary>
    public interface IBufferProcessService
    {
        /// <summary>
        /// Download a CSV content from Internet and process their data
        /// </summary>
        /// <param name="source">Source data to build the final response</param>
        /// <returns>A list of Message elements</returns>
        Task<IEnumerable<MessageChatModel>> ReadAndProcessContent(MessageChatModel source);
    }
}
