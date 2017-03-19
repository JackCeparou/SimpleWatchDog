using System;
using System.Configuration;

namespace SimpleWatchDog
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var watchDog = new WatchDog(1000)
            {
                RunningProcessName = ConfigurationManager.AppSettings["RunningProcessName"],
                WatchProcessName = ConfigurationManager.AppSettings["WatchProcessName"],
                LaunchPath = ConfigurationManager.AppSettings["LaunchPath"],
            };

            watchDog.Start();

            Console.WriteLine("Watching {0} & {1}", ConfigurationManager.AppSettings["RunningProcessName"], ConfigurationManager.AppSettings["WatchProcessName"]);
            Console.WriteLine("Push any key to stop watching..");
            Console.ReadKey();
        }
    }
}