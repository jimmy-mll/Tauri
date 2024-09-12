using Microsoft.JSInterop;

namespace Tauri.Models.Event;

/// <summary>
/// Represents a JSON callback value with one parameter.
/// </summary>
/// <typeparam name="T">The type of the parameter.</typeparam>
/// <param name="callback">The callback function to be invoked.</param>
public sealed class EventCallback<T>(Func<Event<T>, ValueTask> callback)
{
    /// <summary>
    /// Invokes the callback asynchronously with the specified argument.
    /// </summary>
    /// <param name="arg">The argument to pass to the callback.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    [JSInvokable]
    public ValueTask InvokeAsync(Event<T> arg)
    {
        return callback(arg);
    }
    
    /// <summary>
    /// Implicitly converts a function to a <see cref="EventCallback{T}"/>.
    /// </summary>
    /// <param name="callback">The callback function to be converted.</param>
    /// <returns>A new instance of <see cref="EventCallback{T}"/>.</returns>
    public static implicit operator EventCallback<T>(Func<Event<T>, ValueTask> callback)
    {
        return new EventCallback<T>(callback);
    }
}