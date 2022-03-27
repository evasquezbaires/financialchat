using System;

#nullable disable

namespace FinancialChat.Domain.Entities
{
    public partial class MessageChat
    {
        public MessageChat()
        {
            
        }

        public int Id { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
