using System;

namespace receiver.Utils
{
    public class Logger
    {
        public void LoggingToConsole(int statusCode, ref string message)
        {
            if (statusCode == ReceiverConstants.Ok)
                message += "OK";
            else
            {
                message = PrintNonOkStatusCode(statusCode, ref message);
            }
            Console.WriteLine(message);
        }

        private static string PrintNonOkStatusCode(int statusCode, ref string message)
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