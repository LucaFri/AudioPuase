using System;
using System.Globalization;
using System.Threading;

namespace AudioPause
{
    class Program
    {
        static void Main(string[] args)
        {
            int intForParse;
            int? second = args.Length > 0 
                 && !string.IsNullOrWhiteSpace(args[0])
                 && int.TryParse(args[0], NumberStyles.Integer, Thread.CurrentThread.CurrentCulture, out intForParse)
                 ? (int?)intForParse : null;
            int timeForSleep = second.HasValue ? second.Value : 150000;
            LFAudioManager.SetMasterVolumeMute(true);            
            Console.WriteLine($"Volume abbassato per {timeForSleep.ToString()}");
            Thread.Sleep(timeForSleep);
            LFAudioManager.SetMasterVolumeMute(false);
            Console.WriteLine("Volume ripristinato");
        }
    }
}
