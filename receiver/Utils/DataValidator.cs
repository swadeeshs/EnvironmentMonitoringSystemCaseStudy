using receiver.Data;
using System;

namespace receiver.Utils

{
    public interface IDataValidator
    {
        bool ValidateReceivedData(string receivedData, ref EnvironmentData environmentData);
    }

    public class DataValidator : IDataValidator
    {

        public bool ValidateReceivedData(string receivedData, ref EnvironmentData environmentData)
        {
            
            var isValid = false;

            var environmentDataString = receivedData.Split(',');
            if (!receivedData.Equals("File Does not exist"))
            {
                try
                {
                    environmentData.Temperature = double.Parse(environmentDataString[0]);
                    environmentData.Humidity = double.Parse(environmentDataString[1]);
                    isValid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception occurred with the message: " + e.Message);
                    isValid = false;
                }

            }
            else
            {
                Console.WriteLine("File Does not exist");
            }

            return isValid;
    
        }
    }
}