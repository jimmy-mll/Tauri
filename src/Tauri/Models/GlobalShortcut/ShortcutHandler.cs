using Microsoft.JSInterop;

namespace Tauri.Models.GlobalShortcut;

/// <summary>
/// Represents a JSON callback value with one parameter.
/// </summary>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class ShortcutHandler(Func<string, ValueTask> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified argument.
    /// </summary>
    /// <param name="arg">The argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask InvokeAsync(string arg)
    {
        return callback(arg);
    }
    
    /// <summary>
    /// Implicitly converts a function to a <see cref="ShortcutHandler"/>.
    /// </summary>
    /// <param name="callback">The callback function to be converted.</param>
    /// <returns>A new instance of <see cref="ShortcutHandler"/>.</returns>
    public static implicit operator ShortcutHandler(Func<string, ValueTask> callback)
    {
        return new ShortcutHandler(callback);
    }
}