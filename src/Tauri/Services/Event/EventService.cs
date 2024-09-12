using Microsoft.JSInterop;
using Tauri.Extensions;
using Tauri.Models.Event;

namespace Tauri.Services.Event;

/// <inheritdoc />
public sealed class EventService(IJSRuntime jsRuntime) : IEventService
{
    /// <inheritdoc />
    public ValueTask EmitAsync(EventName name)
    {
        var eventName = name.Match(
            tauriEvent => tauriEvent.ToSchemeName(),
            customEvent => customEvent);

        return jsRuntime.InvokeVoidAsync("window.__TAURI__.event.emit", eventName);
    }
    
    /// <inheritdoc />
    public ValueTask EmitAsync(EventName name, object payload)
    {
        var eventName = name.Match(
            tauriEvent => tauriEvent.ToSchemeName(),
            customEvent => customEvent);

        return jsRuntime.InvokeVoidAsync("window.__TAURI__.event.emit", eventName, payload);
    }

    /// <inheritdoc />
    public ValueTask EmitAsync<T>(EventName name, T payload)
    {
        var eventName = name.Match(
            tauriEvent => tauriEvent.ToSchemeName(),
            customEvent => customEvent);

        return jsRuntime.InvokeVoidAsync("window.__TAURI__.event.emit", eventName, payload);
    }
    
    /// <inheritdoc />
    public async ValueTask<UnlistenFn> ListenAsync<T>(EventName name, EventCallback<T> handler)
    {
        var eventName = name.Match(
            tauriEvent => tauriEvent.ToSchemeName(),
            customEvent => customEvent);
        
        var dotnetObjectRef = DotNetObjectReference.Create(handler);

        await jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.listen", dotnetObjectRef, eventName);
        
        return () => jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.unlisten", eventName);
    }

    /// <inheritdoc />
    public async ValueTask<UnlistenFn> OnceAsync<T>(EventName name, EventCallback<T> handler)
    {
        var eventName = name.Match(
            tauriEvent => tauriEvent.ToSchemeName(),
            customEvent => customEvent);
        
        var dotnetObjectRef = DotNetObjectReference.Create(handler);

        await jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.once", dotnetObjectRef, eventName);
        
        return () => jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.unlisten", eventName);
    }
}