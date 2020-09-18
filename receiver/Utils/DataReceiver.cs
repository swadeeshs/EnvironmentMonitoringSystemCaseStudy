using System;

namespace receiver.Utils
{
    public interface IDataReceiver
    {
        string ReceiveViaConsole();
    }

    public class DataReceiver : IDataReceiver
    {
        public string ReceiveViaConsole()
        {
            return Console.ReadLine();
        }
    }
}