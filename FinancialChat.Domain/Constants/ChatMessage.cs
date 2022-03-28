namespace FinancialChat.Domain.Constants
{
    public static class ChatMessage
    {
        public const int TOP_COUNT = 50;
        public const string STOCK_COMMAND = "/stock=";
        public const string STOCK_MESSAGE = "{0} quote is ${1} per share";
        public const int MAX_QUEUE = 1000;
    }
}
