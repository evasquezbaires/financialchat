using FinancialChat.Domain.Constants;
using FinancialChat.Domain.Contracts;
using FinancialChat.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FinancialChat.Domain.Services
{
    /// <summary>
    /// Implementation to read and process content by Buffer
    /// </summary>
    public class BufferProcessService : IBufferProcessService
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Main constructor for the Buffer service
        /// </summary>
        /// <param name="configuration">The global system configuration</param>
        public BufferProcessService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<MessageChatModel>> ReadAndProcessContent(MessageChatModel source)
        {
            var content = await DownloadContent(source.Message);
            var result = new List<MessageChatModel>();

            using (var memoryStream = new MemoryStream(content))
            {
                using (var reader = new StreamReader(memoryStream, Encoding.UTF8, true))
                {
                    var cont = 0;
                    while (!reader.EndOfStream) {
                        var line = reader.ReadLine().Split(',');
                        cont++;
                        if (cont == 1) continue;

                        result.Add(new MessageChatModel
                        {
                            Message = string.Format(ChatMessage.STOCK_MESSAGE, line[0], line[6]),
                            FromUser = source.FromUser,
                            ToUser = source.ToUser
                        });
                    }
                }
            }

            return result;
        }

        private async Task<byte[]> DownloadContent(string stockCode)
        {
            var url = string.Format(_configuration["Bot:Uri"], stockCode.ToLower());
            var client = new HttpClient();
            var response = await client.GetAsync(new Uri(url));

            return await response.Content.ReadAsByteArrayAsync();
        }
    }
}
