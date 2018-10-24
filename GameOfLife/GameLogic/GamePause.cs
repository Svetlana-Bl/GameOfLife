using System;
using System.Threading;

namespace GameOfLife
{
    public class GamePause
    {
        public static int On()
        {
            new Thread(Stop).Start();
            return Thread.CurrentThread.ManagedThreadId;
        }

        private static void Stop()
        {
            while (true)
            {
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.S:
                        StartAllGames.StopIterations();
                        break;

                    case ConsoleKey.C:
                        StartAllGames.ContinueIterations();
                        break;
                }
            }
        }
    }
}
