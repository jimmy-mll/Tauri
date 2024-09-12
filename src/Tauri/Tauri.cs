﻿using Microsoft.JSInterop;
using Tauri.Services.App;
using Tauri.Services.Cli;
using Tauri.Services.Clipboard;
using Tauri.Services.Dialog;
using Tauri.Services.Event;

namespace Tauri;

/// <inheritdoc />
public sealed class Tauri : ITauri
{
    private readonly Lazy<IAppService> _app;
    private readonly Lazy<ICliService> _cli;
    private readonly Lazy<IClipboardService> _clipboard;
    private readonly Lazy<IDialogService> _dialog;
    private readonly Lazy<IEventService> _event;
    
    /// <inheritdoc />
    public IAppService App =>
        _app.Value;
    
    /// <inheritdoc />
    public ICliService Cli =>
        _cli.Value;
    
    /// <inheritdoc />
    public IClipboardService Clipboard =>
        _clipboard.Value;
    
    /// <inheritdoc />
    public IDialogService Dialog =>
        _dialog.Value;
    
    /// <inheritdoc />
    public IEventService Event =>
        _event.Value;
    
    public Tauri(IJSRuntime jsRuntime)
    {
        _app = new Lazy<IAppService>(() => new AppService(jsRuntime));
        _cli = new Lazy<ICliService>(() => new CliService(jsRuntime));
        _clipboard = new Lazy<IClipboardService>(() => new ClipboardService(jsRuntime));
        _dialog = new Lazy<IDialogService>(() => new DialogService(jsRuntime));
        _event = new Lazy<IEventService>(() => new EventService(jsRuntime));
    }
}