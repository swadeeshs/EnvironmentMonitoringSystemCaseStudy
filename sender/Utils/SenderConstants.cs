using System.IO;

namespace sender.Utils
{
    public static class SenderConstants
    {
        private static readonly string CurrentDirectory = Directory.GetCurrentDirectory();
        public static readonly string CsvFilePath = CurrentDirectory + @"\CsvFiles\environment-data.csv";
        public const int SenderWaitingTime = 1000;    //In Milliseconds
    }
}