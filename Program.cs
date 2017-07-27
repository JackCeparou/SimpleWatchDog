using SimpleWatchDog.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace SimpleWatchDog
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var watchDogConfig = ConfigurationManager.GetSection("WatchDogConfig") as WatchDogConfig;
            var watchDogs = new List<WatchDog>();

            foreach (WatchDogElement dogConfig in watchDogConfig.WatchDogs)
            {
                var watchDog = CreateWatchDog(dogConfig);

                watchDog.Start();
                Console.WriteLine("Watching {0} & {1} each {2}ms", dogConfig.RunningProcessName, dogConfig.WatchProcessName, dogConfig.Timer);

                watchDogs.Add(watchDog);
            }

            Console.WriteLine("Push any key to stop watching..");
            Console.ReadKey();
        }

        private static WatchDog CreateWatchDog(WatchDogElement dog)
        {
            return new WatchDog(dog.Timer)
            {
                RunningProcessName = dog.RunningProcessName,
                WatchProcessName = dog.WatchProcessName,
                LaunchPath = dog.LaunchPath,
            };
        }
    }
}