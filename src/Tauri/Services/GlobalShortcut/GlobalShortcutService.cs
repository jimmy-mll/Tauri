using Microsoft.JSInterop;
using Tauri.Models.GlobalShortcut;

namespace Tauri.Services.GlobalShortcut;

/// <inheritdoc />
public sealed class GlobalShortcutService(IJSRuntime jsRuntime) : IGlobalShortcutService
{
    /// <inheritdoc />
    public ValueTask<bool> IsRegisteredAsync(string shortcut)
    {
        return jsRuntime.InvokeAsync<bool>("window.__TAURI__.globalShortcut.isRegistered", shortcut);
    }

    /// <inheritdoc />
    public ValueTask RegisterAsync(string shortcut, ShortcutHandler handler)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.globalShortcut.register", shortcut, DotNetObjectReference.Create(handler));
    }

    /// <inheritdoc />
    public ValueTask RegisterAllAsync(string[] shortcuts, ShortcutHandler handler)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.globalShortcut.registerAll", shortcuts, DotNetObjectReference.Create(handler));
    }

    /// <inheritdoc />
    public ValueTask UnregisterAsync(string shortcut)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.globalShortcut.unregister", shortcut);
    }

    /// <inheritdoc />
    public ValueTask UnregisterAllAsync()
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.globalShortcut.unregisterAll");
    }
}