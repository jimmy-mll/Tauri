using Tauri.Models.Event;

namespace Tauri.Services.Event;

/// <summary>
/// The event system allows you to emit events to the backend and listen to events from it.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.event</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
public interface IEventService
{
    /// <summary>
    /// Emits an event to the backend and all Tauri windows.
    /// </summary>
    /// <param name="name">Event name. Must include only alphanumeric characters, <c>-</c>, <c>/</c>, <c>:</c> and <c>_</c>.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.Event.EmitAsync("frontend-loaded");
    /// </code>
    /// </example>
    ValueTask EmitAsync(EventName name);
    
    /// <summary>
    /// Emits an event to the backend and all Tauri windows.
    /// </summary>
    /// <param name="name">Event name. Must include only alphanumeric characters, <c>-</c>, <c>/</c>, <c>:</c> and <c>_</c>.</param>
    /// <param name="payload">The payload to send with the event.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.Event.EmitAsync("frontend-loaded", new { loggedIn = true, token = "authToken" });
    /// </code>
    /// </example>
    ValueTask EmitAsync(EventName name, object payload);
    
    /// <summary>
    /// Emits an event to the backend and all Tauri windows.
    /// </summary>
    /// <param name="name">Event name. Must include only alphanumeric characters, <c>-</c>, <c>/</c>, <c>:</c> and <c>_</c>.</param>
    /// <param name="payload">The payload to send with the event.</param>
    /// <typeparam name="T">The type of the payload.</typeparam>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.Event.EmitAsync("frontend-loaded", new FrontendLoadedPayload { LoggedIn = true, Token = "authToken" });
    /// </code>
    /// </example>
    ValueTask EmitAsync<T>(EventName name, T payload);
    
    /// <summary>
    /// Listen to an event.
    /// </summary>
    /// <remarks>
    /// The event can be either global or window-specific.
    /// See <a href="https://tauri.app/v1/api/js/event#windowlabel">windowLabel</a> to check the event source.
    /// </remarks>
    /// <param name="name">Event name. Must include only alphanumeric characters, <c>-</c>, <c>/</c>, <c>:</c> and <c>_</c>.</param>
    /// <param name="handler">Event handler callback.</param>
    /// <typeparam name="T">The type of the payload event.</typeparam>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> resolving to a function to unlisten to the event.
    /// Note that removing the listener is required if your listener goes out of scope e.g. the component is unmounted.
    /// </returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// class LoadedPayload
    /// {
    ///     public bool LoggedIn { get; set; }
    /// 
    ///     public string Token { get; set; }
    /// }
    /// var unlisten = await Tauri.Event.ListenAsync&lt;LoadedPayload&gt;("frontend-loaded", async (e) =>
    /// {
    ///     Console.WriteLine($"App is loaded, loggedIn: {event.Payload.LoggedIn}, token: {event.Payload.Token}");
    /// });
    /// // you need to call unlisten if your handler goes out of scope e.g. the component is unmounted
    /// await unlisten();
    /// </code>
    /// </example>
    ValueTask<UnlistenFn> ListenAsync<T>(EventName name, EventCallback<T> handler);
    
    /// <summary>
    /// Listen to an one-off event.
    /// </summary>
    /// <remarks>
    /// See <a href="https://tauri.app/v1/api/js/event#listen">listen</a> for more information.
    /// </remarks>
    /// <param name="name">Event name. Must include only alphanumeric characters, <c>-</c>, <c>/</c>, <c>:</c> and <c>_</c>.</param>
    /// <param name="handler">Event handler callback.</param>
    /// <typeparam name="T">The type of the payload event.</typeparam>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> resolving to a function to unlisten to the event.
    /// Note that removing the listener is required if your listener goes out of scope e.g. the component is unmounted.
    /// </returns>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// class LoadedPayload
    /// {
    ///     public bool LoggedIn { get; set; }
    /// 
    ///     public string Token { get; set; }
    /// }
    /// var unlisten = await Tauri.Event.OnceAsync&lt;LoadedPayload&gt;("frontend-loaded", async (e) =>
    /// {
    ///     Console.WriteLine($"App is loaded, loggedIn: {event.Payload.LoggedIn}, token: {event.Payload.Token}");
    /// });
    /// // you need to call unlisten if your handler goes out of scope e.g. the component is unmounted
    /// await unlisten();
    /// </code>
    /// </example>
    ValueTask<UnlistenFn> OnceAsync<T>(EventName name, EventCallback<T> handler);
}