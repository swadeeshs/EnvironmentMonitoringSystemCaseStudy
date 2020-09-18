using receiver.Data;
using System;

namespace receiver.Utils

{
    public class DataValidator
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
                    Console.WriteLine(environmentData);
                    isValid = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: "+e.Message+"\n");
                    isValid = false;
                }

            }
            else
            {
                Console.WriteLine("File Does not exist\n");
            }

            return isValid;
    
        }
    }
}