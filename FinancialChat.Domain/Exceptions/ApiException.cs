﻿using System;

namespace FinancialChat.Domain.Exceptions
{
    public class ApiException : Exception
    {
        public ApiException(string message)
            : base(message)
        {
        }
    }
}