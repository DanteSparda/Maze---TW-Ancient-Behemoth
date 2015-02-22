using System;
using System.Diagnostics;
using System.Threading;
namespace StartMap
{
    class GameClock
    {
        
        public void GameClockDisplay()
        {
            //хронометър
            Stopwatch timer = new Stopwatch();
            Stopwatch doorSwap = new Stopwatch();
            timer.Start();
            doorSwap.Start();
            do
            {
                Console.WriteLine("{0}:{1}:{2}",timer.Elapsed.Minutes, timer.Elapsed.Seconds, timer.Elapsed.Milliseconds);
                Console.WriteLine("{0}:{1}:{2}", doorSwap.Elapsed.Minutes, doorSwap.Elapsed.Seconds, doorSwap.Elapsed.Milliseconds);
                Thread.Sleep(60);
                Console.Clear();
                if (doorSwap.Elapsed.Seconds == 2)
                {
                    Console.WriteLine(123);
                    doorSwap.Restart();
                    doorSwap.Start();
                }
            } while (true);
        }
        public void GameTimerDisplay()
        {
            int timerMin = 2;
            int timerSec = 60;
            do
            {
                if (timerSec == 0)
                {
                    Console.WriteLine("{0}:{1}", timerMin, timerSec);
                    --timerMin;
                    timerSec = 60;
                }
                else
                {
                    Console.WriteLine("{0}:{1}", timerMin, timerSec);
                }
                --timerSec;
                if (timerSec == 0 && timerMin == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Time is over.");
                    break;
                }
                Thread.Sleep(1000);
                Console.Clear();
            } while (true);
        }
    }
}