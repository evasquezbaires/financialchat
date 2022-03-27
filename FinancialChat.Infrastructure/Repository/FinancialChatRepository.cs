using FinancialChat.Domain.Contracts;
using FinancialChat.Domain.Entities;
using FinancialChat.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinancialChat.Domain.Constants;

namespace FinancialChat.Infrastructure.Repository
{
    /// <summary>
    /// Implementation of Financial chat Repository to handle communication with DB
    /// </summary>
    public class FinancialChatRepository : IFinancialChatRepository
    {
        private readonly FinancialChatDBContext _context;
        private readonly Lazy<DbSet<MessageChat>> _dbSetChat;
        private readonly Lazy<DbSet<UserIdentity>> _dbSetUser;

        /// <summary>
        /// Main constructor for repository
        /// </summary>
        /// <param name="context">The Context to connect to DB</param>
        public FinancialChatRepository(FinancialChatDBContext context)
        {
            _context = context;
            _dbSetChat = new Lazy<DbSet<MessageChat>>(() => _context.Set<MessageChat>());
            _dbSetUser = new Lazy<DbSet<UserIdentity>>(() => _context.Set<UserIdentity>());
        }

        /// <inheritdoc/>
        public async Task<int> AddMessageAsync(MessageChat entity)
        {
            await _dbSetChat.Value.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc />
        public async Task<IEnumerable<MessageChat>> GetMessagesAsync(MessageView filter)
        {
            var messages = await _dbSetChat.Value.ToListAsync();
            var messagesFilter = messages.Where(m => m.FromUser == filter.FromUser && m.ToUser == filter.ToUser)
                                        .OrderByDescending(m => m.CreatedDate)
                                        .Take(ChatMessage.TOP_COUNT)
                                        .OrderBy(m => m.CreatedDate);

            return messagesFilter;
        }

        /// <inheritdoc/>
        public async Task<int> AddUserAsync(UserIdentity entity)
        {
            await _dbSetUser.Value.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        /// <inheritdoc/>
        public async Task<string> FindUserAsync(string name, string password)
        {
            var user = await _dbSetUser.Value.FirstOrDefaultAsync(q => q.Name.Equals(name) && q.Password.Equals(password));
            return user?.Name;
        }

        /// <inheritdoc/>
        public async Task<string> FindUserByNameAsync(string name)
        {
            var user = await _dbSetUser.Value.FirstOrDefaultAsync(q => q.Name.Equals(name));
            return user?.Name;
        }
    }
}
