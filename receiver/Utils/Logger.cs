using System;

namespace receiver.Utils
{
    public interface ILogger
    {
        void LoggingToConsole(int statusCode, ref string message);
    }

    public class Logger : ILogger
    {
        public void LoggingToConsole(int statusCode, ref string message)
        {
            if (statusCode == ReceiverConstants.Ok)
                message += "OK";
            else
            {
                message = CheckNonOkStatusCode(statusCode, ref message);
            }
            Console.WriteLine(message);
        }

        private static string CheckNonOkStatusCode(int statusCode, ref string message)
        {
            switch (statusCode)
            {
                case ReceiverConstants.Warning:
                    return message + "Warning";
                case ReceiverConstants.Error:
                    return message += "Error";
                default:
                    return message += "Not A valid Status Code";
            }
        }
    }
}