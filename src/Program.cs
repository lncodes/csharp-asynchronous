using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lncodes.Example.Asynchronous;

internal static class Program
{
    /// <summary>
    /// Entry point of the application.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    private static async Task Main()
    {
        var gameAssetLoader = new GameAssetLoader();
        var cancelTokenSource = new CancellationTokenSource();
        Console.WriteLine("Press ENTER to stop loading game data.");
        await Task.WhenAny(
                gameAssetLoader.LoadGameAssetsAsync(cancelTokenSource.Token),
                Task.Run(() => CancelTimer(cancelTokenSource))
            );
    }

    /// <summary>
    /// Listens for the ENTER key press to cancel the game asset loading.
    /// </summary>
    /// <param name="cancelTokenSource">The cancellation token source to stop the loading process.</param>
    private static void CancelTimer(CancellationTokenSource cancelTokenSource)
    {
        while (Console.ReadKey().Key == ConsoleKey.Enter)
            cancelTokenSource.Cancel();
    }
}