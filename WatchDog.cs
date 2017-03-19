using System;
using System.Diagnostics;
using System.Timers;

namespace SimpleWatchDog
{
    public class WatchDog : IDisposable
    {
        public bool Launching { get; private set; }
        public string LaunchPath { get; set; }
        public int Interval { get; private set; }

        public string RunningProcessName { get; set; }
        public string WatchProcessName { get; set; }

        protected Timer timer;

        public WatchDog()
        {
            Launching = false;
        }

        public WatchDog(int interval) : this()
        {
            Interval = interval;
        }

        public void Start()
        {
            if (timer == null)
            {
                timer = new Timer(Interval);
                timer.Elapsed += Timer_Elapsed;
            }

            timer.Start();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (Launching) return;

            var diablo = Process.GetProcessesByName(RunningProcessName);
            if (diablo.Length == 0) return;

            var turbo = Process.GetProcessesByName(WatchProcessName);
            if (turbo.Length > 0) return;

            Launching = true;
            Console.WriteLine("{0} not launched !", WatchProcessName);
            Process.Start(LaunchPath);
            Launching = false;
        }

        public void Stop()
        {
            timer.Stop();
        }

        public void Dispose()
        {
            if (timer != null && timer.Enabled)
            {
                timer.Stop();
                timer.Dispose();
            }
        }
    }
}