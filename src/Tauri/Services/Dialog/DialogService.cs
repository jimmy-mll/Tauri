using System.Text.Json;
using Microsoft.JSInterop;
using OneOf;
using Tauri.Json.Converters;
using Tauri.Json.Nodes;
using Tauri.Models.Dialog;

namespace Tauri.Services.Dialog;

/// <inheritdoc />
public sealed class DialogService(IJSRuntime jsRuntime) : IDialogService
{
    private static readonly JsonSerializerOptions SerializerOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new OpenDialogResultConverter() }
    };
    
    /// <inheritdoc />
    public ValueTask<bool> AskAsync(string message, OneOf<NullValue, string, ConfirmDialogOptions> options = default)
    {
        return options.Match(
            _ => jsRuntime.InvokeAsync<bool>("window.__TAURI__.dialog.ask", message),
            title => jsRuntime.InvokeAsync<bool>("window.__TAURI__.dialog.ask", message, title),
            dialogOptions => jsRuntime.InvokeAsync<bool>("window.__TAURI__.dialog.ask", message, dialogOptions)
        );
    }

    /// <inheritdoc />
    public ValueTask<bool> ConfirmAsync(string message, OneOf<NullValue, string, ConfirmDialogOptions> options = default)
    {
        return options.Match(
            _ => jsRuntime.InvokeAsync<bool>("window.__TAURI__.dialog.confirm", message),
            title => jsRuntime.InvokeAsync<bool>("window.__TAURI__.dialog.confirm", message, title),
            dialogOptions => jsRuntime.InvokeAsync<bool>("window.__TAURI__.dialog.confirm", message, dialogOptions)
        );
    }

    /// <inheritdoc />
    public ValueTask MessageAsync(string message, OneOf<NullValue, string, MessageDialogOptions> options = default)
    {
        return options.Match(
            _ => jsRuntime.InvokeVoidAsync("window.__TAURI__.dialog.message", message),
            title => jsRuntime.InvokeVoidAsync("window.__TAURI__.dialog.message", message, title),
            dialogOptions => jsRuntime.InvokeVoidAsync("window.__TAURI__.dialog.message", message, dialogOptions)
        );
    }

    /// <inheritdoc />
    public async ValueTask<OneOf<NullValue, string, string[]>> OpenAsync(OpenDialogOptions? options = null)
    {
        var contentVt = options is null
            ? jsRuntime.InvokeAsync<string>("window.__TAURI__.dialog.open")
            : jsRuntime.InvokeAsync<string>("window.__TAURI__.dialog.open", options);
        
        var content = contentVt.IsCompletedSuccessfully
            ? contentVt.Result
            : await contentVt;
        
        return JsonSerializer.Deserialize<OneOf<NullValue, string, string[]>>(content, SerializerOptions);
    }

    /// <inheritdoc />
    public ValueTask<string?> SaveAsync(SaveDialogOptions? options = null)
    {
        return options is null
            ? jsRuntime.InvokeAsync<string?>("window.__TAURI__.dialog.save")
            : jsRuntime.InvokeAsync<string?>("window.__TAURI__.dialog.save", options);
    }
}