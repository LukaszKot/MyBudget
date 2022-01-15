using System;

namespace MyBudget.App.Exceptions
{
    public class DomainException : Exception
    {
        public DomainError ErrorType { get; init; }
        public int StatusCode { get; init;  }
        public DomainException(DomainError errorType, int statusCode = 400) : base(errorType.ToString())
        {
            ErrorType = errorType;
            StatusCode = statusCode;
        }
        
        public DomainException(DomainError errorType, string message, int statusCode = 400) : base(message)
        {
            ErrorType = errorType;
            StatusCode = statusCode;
        }

        public DomainException(DomainError errorType, string message, Exception innerException, int statusCode = 400) : base(
            message, innerException)
        {
            ErrorType = errorType;
            StatusCode = statusCode;
        }
    }
}