namespace FinancialChat.Domain.Constants
{
    public static class ErrorMessages
    {
        public const string USER_NOT_SELECTED = "Should select first a user before to Send message";
        public const string MESSAGE_NULL = "Should write first a message before to Send chat";
        public const string USER_EXISTS = "Already exists a user with the same name.";
        public const string USER_NOT_EXISTS = "The user entered Not exists.";
    }
}
