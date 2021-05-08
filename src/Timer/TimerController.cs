using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lncodes.Example.Async
{
    public sealed class TimerController
    {
        private readonly int _delay;
        private readonly double _duration;
        private CancellationTokenSource _cencelTokenSource = new CancellationTokenSource();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="duration"></param>
        public TimerController(int delay, double duration) =>
            (_delay, _duration) = (delay, duration);

        /// <summary>
        /// Method For Starting Timer
        /// </summary>
        /// <returns cref="Task"></returns>
        public async Task StartAsync() =>
            await Task.WhenAny(new[] { TimerAsync(), Task.Run(CencelTimer) });

        /// <summary>
        /// Method For Async Timer
        /// </summary>
        /// <returns cref="Task">A Task That Represent Timer Async</returns>
        private async Task TimerAsync()
        {
            try
            {
                var durationRef = _duration;
                Console.WriteLine("Timer Start");
                while (durationRef > 0)
                {
                    await Task.Delay(_delay, _cencelTokenSource.Token);
                    Console.WriteLine($"Timer updated and will end on : {durationRef/1000}");
                    durationRef -= _delay;
                }
                Console.WriteLine("Timer Finish");
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine(ex);
                _cencelTokenSource = new CancellationTokenSource();
            }
        }

        /// <summary>
        /// Method for cencel timer when ENTER key pressed
        /// </summary>
        private void CencelTimer()
        {
            while (Console.ReadKey().Key == ConsoleKey.Enter) 
                _cencelTokenSource.Cancel();
        }
    }
}