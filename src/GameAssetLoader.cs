using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lncodes.Example.Asynchronous;

public sealed class GameAssetLoader
{
    /// <summary>
    /// Loads multiple game assets asynchronously.
    /// </summary>
    /// <param name="cancellationToken">Token to cancel the loading process.</param>
    public async Task LoadGameAssetsAsync(CancellationToken cancellationToken)
    {
        try
        {
            await LoadAssetAsync("Character.png", cancellationToken);
            await LoadAssetAsync("Background.png", cancellationToken);
            await LoadAssetAsync("BattleTheme.mp3", cancellationToken);

            Console.WriteLine("All game assets loaded.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Game asset loading was canceled.");
        }
    }

    /// <summary>
    /// Simulates loading a single asset asynchronously.
    /// </summary>
    /// <param name="assetName">Name of the asset to load.</param>
    /// <param name="cancellationToken">Token to cancel the operation.</param>
    private async Task LoadAssetAsync(string assetName, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Loading {assetName}...");
        await Task.Delay(2000, cancellationToken);
        Console.WriteLine($"{assetName} loaded.");
        Console.WriteLine();
    }
}