using System.Collections.Generic;

namespace FinancialChat.API.Models
{
    public class ApiResponse
    {
        public object Data { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
