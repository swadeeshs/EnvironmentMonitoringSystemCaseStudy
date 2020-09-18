using System;
using receiver.Data;
using receiver.Utils;


namespace receiver
{
     static class Program
    {
        static void Main()
        {
            Receiver receiver = new Receiver();

            string receivedData;
            
            var environmentData = new EnvironmentData();
            
            while ((receivedData = receiver.ReceiveViaConsole()) != null)
            {
                var isValid = receiver.ValidateReceivedData(receivedData, ref environmentData);
                if (!isValid) continue;
                Console.WriteLine(receivedData);
                var temperatureStatusCode =
                    receiver.CheckTemperatureAndReturnStatusCode(environmentData.Temperature);
                var humidityStatusCode = receiver.CheckHumidityAndReturnStatusCode(environmentData.Humidity);
                 var prefixMessage = "Temperature: ";
                 receiver.LoggingToConsole( temperatureStatusCode, ref prefixMessage);
                prefixMessage = "Humidity: ";
                receiver.LoggingToConsole( humidityStatusCode, ref prefixMessage);
                Console.WriteLine();
            }
        }
    }

    public class Receiver : IDataReceiver, IDataValidator, ILogger, IRangeChecker
    {
        private static DataReceiver _dataReceiver;
        private static DataValidator _dataValidator;
        private static RangeChecker _rangeChecker;
        private static Logger _logger;

        public Receiver()
        {
            _dataReceiver = new DataReceiver();
            _dataValidator = new DataValidator();
            _rangeChecker = new RangeChecker();
            _logger = new Logger();
        }

        public string ReceiveViaConsole()
        {
            return (_dataReceiver.ReceiveViaConsole());
        }

        public bool ValidateReceivedData(string receivedData, ref EnvironmentData environmentData)
        {
            return _dataValidator.ValidateReceivedData(receivedData, ref environmentData);
        }
        public void LoggingToConsole(int statusCode, ref string message)
        {
            _logger.LoggingToConsole(statusCode, ref message);
        }

        public int CheckTemperatureAndReturnStatusCode(double temperature)
        {
            return _rangeChecker.CheckTemperatureAndReturnStatusCode(temperature);
        }

        public int CheckHumidityAndReturnStatusCode(double humidity)
        {
            return _rangeChecker.CheckHumidityAndReturnStatusCode(humidity);
        }
    }

}
