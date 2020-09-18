namespace receiver.Utils
{
    public class RangeChecker
    {
        public int CheckTemperatureAndReturnStatusCode(double temperature)
        {
            int temperatureStatusCode;

            if (CheckTemperatureIsInRange(temperature))
                temperatureStatusCode = ReceiverConstants.Ok;
            else if (CheckTemperatureIsInErrorRange(temperature))
                temperatureStatusCode = ReceiverConstants.Error;
            else
                temperatureStatusCode = ReceiverConstants.Warning;
            return temperatureStatusCode;
        }

        private static bool CheckTemperatureIsInRange(double temperature)
        {
            return (temperature > ReceiverConstants.TemperatureWarningLowerLimit && temperature < ReceiverConstants.TemperatureWarningUpperLimit);
        }

        private static bool CheckTemperatureIsInErrorRange(double temperature)
        {
            return (temperature <= ReceiverConstants.TemperatureErrorLowerLimit || temperature >= ReceiverConstants.TemperatureErrorUpperLimit);
        }

        public int CheckHumidityAndReturnStatusCode(double humidity)
        {
            int humidityStatusCode;
            if (humidity < ReceiverConstants.HumidityOkUpperLimit)
                humidityStatusCode = ReceiverConstants.Ok;
            else if (humidity >= ReceiverConstants.HumidityErrorLowerLimit)
                humidityStatusCode = ReceiverConstants.Error;
            else
                humidityStatusCode = ReceiverConstants.Warning;
            return humidityStatusCode;
        }
    }
}