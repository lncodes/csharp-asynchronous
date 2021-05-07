using System;
using System.Threading.Tasks;

namespace Lncodes.Example.Async
{
    public class Program
    {
        static async Task Main()
        {
            //Create TimerController Instance
            var timerController = new TimerController(delay: 1000, duration: 10000);
            Console.WriteLine("!!! PRESS ENTER TO STOP THE TIMER !!!");
            await timerController.StartAsync();
        }
    }
}