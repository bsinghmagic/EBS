using System;

namespace WebClientUtility.Core
{
    public enum StatusCode
    {
        Fail = 0,
        Ignored = 1
    }
    public class AbortException : Exception
    {
        public AbortException(string message): base(message)
        {
        }

        public AbortException(string message, StatusCode statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public StatusCode StatusCode { get; } = StatusCode.Fail;
    }
}