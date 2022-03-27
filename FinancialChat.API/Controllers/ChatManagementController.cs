using FinancialChat.API.Models;
using FinancialChat.Domain.Constants;
using FinancialChat.Domain.Contracts;
using FinancialChat.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialChat.API.Controllers
{
    /// <summary>
    /// Handles operational functions about Messages in chatrooms
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ChatManagementController : ControllerBase
    {
        private readonly IChatManagementService _chatService;

        /// <summary>
        /// Main constructor of Chat controller
        /// </summary>
        /// <param name="chatService">The service management for all functions</param>
        public ChatManagementController(IChatManagementService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost("SendMessage")]
        public async Task<IActionResult> SaveMessageChat([FromBody] MessageChatModel modelRequest)
        {
            try
            {
                var result = !IsStockCommand(modelRequest.Message) ?
                    await _chatService.CreateMessageAsync(modelRequest) :
                    await _chatService.PublishMessageQueue(modelRequest);
                var response = new ApiResponse { Data = new { MessageId = result } };
                if (result > 0)
                    return Created(string.Empty, response);
                else
                    return NotFound(response);
            }
            catch(Exception ex)
            {
                return BadRequest(new ApiResponse { Errors = new List<string> { ex.Message } });
            }
        }

        [HttpPost("GetMessages")]
        public async Task<IActionResult> GetMessagesChat([FromBody] MessageViewModel modelRequest)
        {
            try
            {
                var result = await _chatService.ViewMessagesAsync(modelRequest);
                var response = new ApiResponse { Data = result };
                if (result != null && result.Count() > 0)
                    return Created(string.Empty, response);
                else
                    return NotFound(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse { Errors = new List<string> { ex.Message } });
            }
        }

        private bool IsStockCommand(string message)
        {
            return !string.IsNullOrEmpty(message) && message.Equals(ChatMessage.STOCK_COMMAND);
        }
    }
}
