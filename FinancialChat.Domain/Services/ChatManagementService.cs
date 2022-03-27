using AutoMapper;
using FinancialChat.Domain.Constants;
using FinancialChat.Domain.Contracts;
using FinancialChat.Domain.Entities;
using FinancialChat.Domain.Exceptions;
using FinancialChat.Domain.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Services
{
    /// <summary>
    /// Implementation for the Management of Chats
    /// </summary>
    public class ChatManagementService : IChatManagementService
    {
        private readonly IFinancialChatRepository _repository;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        /// <summary>
        /// Main constructor of Chat service
        /// </summary>
        /// <param name="repository">The repository for DB communication</param>
        /// <param name="mapper">The mapper instance</param>
        /// <param name="logger">The logger instance</param>
        public ChatManagementService(IFinancialChatRepository repository, IConfiguration configuration,
            IMapper mapper, ILogger<ChatManagementService> logger)
        {
            _repository = repository;
            _configuration = configuration;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<int> CreateMessageAsync(MessageChatModel chatModel)
        {
            if (chatModel == null) throw new ArgumentNullException(nameof(chatModel));
            if (chatModel.FromUser <= 0 || chatModel.ToUser <= 0) throw new ApiException(ErrorMessages.USER_NOT_SELECTED);
            if (string.IsNullOrEmpty(chatModel.Message)) throw new ApiException(ErrorMessages.MESSAGE_NULL);

            var entityMapped = _mapper.Map<MessageChat>(chatModel);
            return await _repository.AddMessageAsync(entityMapped);
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MessageChatModel>> ViewMessagesAsync(MessageViewModel filterModel)
        {
            if (filterModel == null) throw new ArgumentNullException(nameof(filterModel));
            if (filterModel.FromUser <= 0 || filterModel.ToUser <= 0) throw new ApiException(ErrorMessages.USER_NOT_SELECTED);

            var entityMapped = _mapper.Map<MessageView>(filterModel);
            var messages = await _repository.GetMessagesAsync(entityMapped);

            return _mapper.Map<IEnumerable<MessageChatModel>>(messages);
        }

        public async Task<int> PublishMessageQueue(MessageChatModel chatModel)
        {
            chatModel.ToUser = int.Parse(_configuration["Bot:DefaultUserId"]);
            chatModel.Message = chatModel.Message.Replace(ChatMessage.STOCK_COMMAND, "");

            //TODO: Service bus communication
            return 0;
        }
    }
}
