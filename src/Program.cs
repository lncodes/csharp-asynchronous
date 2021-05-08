using System;
using System.Threading.Tasks;

namespace Lncodes.Example.Async
{
    public class Program
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected Program() { }

        /// <summary>
        /// Main Program
        /// </summary>
        /// <returns cref=Task></returns>
        static async Task Main()
        {
            var timerController = new TimerController(delay: 1000, duration: 10000);
            Console.WriteLine("!!! PRESS ENTER TO STOP THE TIMER !!!");
            await timerController.StartAsync();
        }
    }
}