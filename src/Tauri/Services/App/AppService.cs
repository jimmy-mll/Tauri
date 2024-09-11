using Microsoft.JSInterop;

namespace Tauri.Services.App;

/// <inheritdoc />
public sealed class AppService(IJSRuntime jsRuntime) : IAppService
{
    /// <inheritdoc />
    public ValueTask<string> GetNameAsync()
    {
        return jsRuntime.InvokeAsync<string>("window.__TAURI__.app.getName");
    }

    /// <inheritdoc />
    public ValueTask<string> GetTauriVersionAsync()
    {
        return jsRuntime.InvokeAsync<string>("window.__TAURI__.app.getTauriVersion");
    }

    /// <inheritdoc />
    public ValueTask<string> GetVersionAsync()
    {
        return jsRuntime.InvokeAsync<string>("window.__TAURI__.app.getVersion");
    }

    /// <inheritdoc />
    public ValueTask HideAsync()
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.app.hide");
    }

    /// <inheritdoc />
    public ValueTask ShowAsync()
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.app.show");
    }
}