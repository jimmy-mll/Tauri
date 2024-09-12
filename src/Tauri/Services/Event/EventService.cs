using Microsoft.JSInterop;
using Tauri.Models.Event;

namespace Tauri.Services.Event;

/// <inheritdoc />
public sealed class EventService(IJSRuntime jsRuntime) : IEventService
{
    /// <inheritdoc />
    public ValueTask EmitAsync(EventName name)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.event.emit", name.ToString());
    }
    
    /// <inheritdoc />
    public ValueTask EmitAsync(EventName name, object payload)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.event.emit", name.ToString(), payload);
    }

    /// <inheritdoc />
    public ValueTask EmitAsync<T>(EventName name, T payload)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.event.emit", name.ToString(), payload);
    }
    
    /// <inheritdoc />
    public async ValueTask<UnlistenFn> ListenAsync<T>(EventName name, EventCallback<T> handler)
    {
        var eventName = name.ToString();
        
        var dotnetObjectRef = DotNetObjectReference.Create(handler);

        await jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.listen", dotnetObjectRef, eventName);
        
        return () =>
        {
            using (dotnetObjectRef)
            {
                return jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.unlisten", eventName);   
            }
        };
    }

    /// <inheritdoc />
    public async ValueTask<UnlistenFn> OnceAsync<T>(EventName name, EventCallback<T> handler)
    {
        var eventName = name.ToString();
        
        var dotnetObjectRef = DotNetObjectReference.Create(handler);

        await jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.once", dotnetObjectRef, eventName);
        
        return () =>
        {
            using (dotnetObjectRef)
            {
                return jsRuntime.InvokeVoidAsync("window.__TAURI__.blazor.event.unlisten", eventName);
            }
        };
    }
}