using Tauri.Services.App;
using Tauri.Services.Cli;
using Tauri.Services.Clipboard;
using Tauri.Services.Dialog;

namespace Tauri;

/// <summary>
/// Represents the Tauri API.
/// </summary>
public interface ITauri
{
    /// <inheritdoc cref="IAppService" />
    IAppService App { get; }
    
    /// <inheritdoc cref="ICliService" />
    ICliService Cli { get; }
    
    /// <inheritdoc cref="IClipboardService" />
    IClipboardService Clipboard { get; }
    
    /// <inheritdoc cref="IDialogService" />
    IDialogService Dialog { get; }
}