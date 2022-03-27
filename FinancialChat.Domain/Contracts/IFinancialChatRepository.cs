using FinancialChat.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Contracts
{
    /// <summary>
    /// Interface for Repository at Financial Chat transactions
    /// </summary>
    public interface IFinancialChatRepository
    {
        /// <summary>
        /// Save a new Message chat into repository
        /// </summary>
        /// <param name="entity">The message chat entity to save</param>
        /// <returns>Id of the new message saved</returns>
        Task<int> AddMessageAsync(MessageChat entity);

        /// <summary>
        /// Get a list of last messages
        /// </summary>
        /// <param name="filter">Filter for messages to obtain</param>
        /// <returns>The messages between two users</returns>
        Task<IEnumerable<MessageChat>> GetMessagesAsync(MessageView filter);

        /// <summary>
        /// Register a new user of system
        /// </summary>
        /// <param name="entity">The user entity to save</param>
        /// <returns>Id of the new user generated</returns>
        Task<int> AddUserAsync(UserIdentity entity);

        /// <summary>
        /// Gets a specific User by Login process
        /// </summary>
        /// <param name="name">Username to find the record</param>
        /// <param name="password">Passwor to match with the user</param>
        /// <returns>Name of the user found</returns>
        Task<string> FindUserAsync(string name, string password);

        /// <summary>
        /// Gets a specific User to check existence
        /// </summary>
        /// <param name="name">Username to find the record</param>
        /// <returns>Id of the user found</returns>
        Task<string> FindUserByNameAsync(string name);
    }
}
