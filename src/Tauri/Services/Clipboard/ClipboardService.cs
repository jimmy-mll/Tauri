using Microsoft.JSInterop;

namespace Tauri.Services.Clipboard;

/// <inheritdoc />
public sealed class ClipboardService(IJSRuntime jsRuntime) : IClipboardService
{
    /// <inheritdoc />
    public ValueTask<string?> ReadTextAsync()
    {
        return jsRuntime.InvokeAsync<string?>("window.__TAURI__.clipboard.readText");
    }

    /// <inheritdoc />
    public ValueTask WriteTextAsync(string text)
    {
        return jsRuntime.InvokeVoidAsync("window.__TAURI__.clipboard.writeText", text);
    }
}