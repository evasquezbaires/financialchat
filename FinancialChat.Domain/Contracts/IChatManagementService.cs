﻿using FinancialChat.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Contracts
{
    /// <summary>
    /// Interface to operate the Chat functions
    /// </summary>
    public interface IChatManagementService
    {
        /// <summary>
        /// Send a message via chatroom between users
        /// </summary>
        /// <param name="chatModel">The message chat model to send</param>
        /// <returns>Id of the new message saved</returns>
        Task<int> CreateMessageAsync(MessageChatModel chatModel);

        /// <summary>
        /// Gets a list of messages shared between two users
        /// </summary>
        /// <param name="filterModel">Filter to apply about what messages Load</param>
        /// <returns>Messages chat found</returns>
        Task<IEnumerable<MessageChatModel>> ViewMessagesAsync(MessageViewModel filterModel);

        /// <summary>
        /// Publish a message in service bus
        /// </summary>
        /// <param name="chatModel">The message chat model to publish</param>
        /// <returns>Id of the new message published in the queue</returns>
        Task<int> PublishMessageQueue(MessageChatModel chatModel);
    }
}
