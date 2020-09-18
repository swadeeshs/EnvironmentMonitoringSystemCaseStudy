using System;
using receiver.Data;
using receiver.Utils;

namespace receiver
{
     static class Program
    {
        private static readonly DataReceiver DataReceiver;
        private static readonly DataValidator DataValidator;
        private static readonly RangeChecker RangeChecker;
        private static readonly Logger Logger;
        

        static Program()
        {
            DataReceiver = new DataReceiver();          
            DataValidator = new DataValidator();
            RangeChecker = new RangeChecker();
            Logger = new Logger();

        }
         static void Main()
        {
            string receivedData;
            var environmentData = new EnvironmentData();
            while ((receivedData = DataReceiver.ReceiveViaConsole()) != null)
            {
                var isValid = DataValidator.ValidateReceivedData(receivedData, ref environmentData);
                if (!isValid) continue;
                var temperatureStatusCode =
                    RangeChecker.CheckTemperatureAndReturnStatusCode(environmentData.Temperature);
                var humidityStatusCode = RangeChecker.CheckHumidityAndReturnStatusCode(environmentData.Humidity);
                 var prefixMessage = "Temperature: ";
                Logger.LoggingToConsole( temperatureStatusCode, ref prefixMessage);
                prefixMessage = "Humidity: ";
                Logger.LoggingToConsole( humidityStatusCode, ref prefixMessage);
                Console.WriteLine();
            }
        }
    }
}
