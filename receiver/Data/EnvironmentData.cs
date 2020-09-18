namespace receiver.Data
{
    public class EnvironmentData
    {
        internal double Temperature { get; set; }
        internal double Humidity { get; set; }

        public override string ToString()
        {
            return "Temperature: " + this.Temperature + "\nHumidity: " + this.Humidity;
        }
    }
   
}