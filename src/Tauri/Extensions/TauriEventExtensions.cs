using Tauri.Models.Event;

namespace Tauri.Extensions;

/// <summary>
/// Provides extension methods for converting between <see cref="TauriEvent"/> and their corresponding scheme names.
/// </summary>
public static class TauriEventExtensions
{
    /// <summary>
    /// Converts a <see cref="TauriEvent"/> to its corresponding scheme name.
    /// </summary>
    /// <param name="tauriEvent">The <see cref="TauriEvent"/> to convert.</param>
    /// <returns>The scheme name corresponding to the specified <see cref="TauriEvent"/>.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the <see cref="TauriEvent"/> is out of range.</exception>
    public static string ToSchemeName(this TauriEvent tauriEvent)
    {
        return tauriEvent switch
        {
            TauriEvent.WindowResized => "tauri://resize",
            TauriEvent.WindowMoved => "tauri://move",
            TauriEvent.WindowCloseRequested => "tauri://close-requested",
            TauriEvent.WindowCreated => "tauri://window-created",
            TauriEvent.WindowDestroyed => "tauri://destroyed",
            TauriEvent.WindowFocus => "tauri://focus",
            TauriEvent.WindowBlur => "tauri://blur",
            TauriEvent.WindowScaleFactorChanged => "tauri://scale-change",
            TauriEvent.WindowThemeChanged => "tauri://theme-changed",
            TauriEvent.WindowFileDrop => "tauri://file-drop",
            TauriEvent.WindowFileDropHover => "tauri://file-drop-hover",
            TauriEvent.WindowFileDropCancelled => "tauri://file-drop-cancelled",
            TauriEvent.Menu => "tauri://menu",
            TauriEvent.CheckUpdate => "tauri://update",
            TauriEvent.UpdateAvailable => "tauri://update-available",
            TauriEvent.InstallUpdate => "tauri://update-install",
            TauriEvent.StatusUpdate => "tauri://update-status",
            TauriEvent.DownloadProgress => "tauri://update-download-progress",
            _ => throw new ArgumentOutOfRangeException(nameof(tauriEvent))
        };
    }

    /// <summary>
    /// Converts a scheme name to its corresponding <see cref="TauriEvent"/>.
    /// </summary>
    /// <param name="eventName">The scheme name to convert.</param>
    /// <returns>The <see cref="TauriEvent"/> corresponding to the specified scheme name.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the scheme name is out of range.</exception>
    public static TauriEvent ToTauriEvent(this string eventName)
    {
        return eventName switch
        {
            "tauri://resize" => TauriEvent.WindowResized,
            "tauri://move" => TauriEvent.WindowMoved,
            "tauri://close-requested" => TauriEvent.WindowCloseRequested,
            "tauri://window-created" => TauriEvent.WindowCreated,
            "tauri://destroyed" => TauriEvent.WindowDestroyed,
            "tauri://focus" => TauriEvent.WindowFocus,
            "tauri://blur" => TauriEvent.WindowBlur,
            "tauri://scale-change" => TauriEvent.WindowScaleFactorChanged,
            "tauri://theme-changed" => TauriEvent.WindowThemeChanged,
            "tauri://file-drop" => TauriEvent.WindowFileDrop,
            "tauri://file-drop-hover" => TauriEvent.WindowFileDropHover,
            "tauri://file-drop-cancelled" => TauriEvent.WindowFileDropCancelled,
            "tauri://menu" => TauriEvent.Menu,
            "tauri://update" => TauriEvent.CheckUpdate,
            "tauri://update-available" => TauriEvent.UpdateAvailable,
            "tauri://update-install" => TauriEvent.InstallUpdate,
            "tauri://update-status" => TauriEvent.StatusUpdate,
            "tauri://update-download-progress" => TauriEvent.DownloadProgress,
            _ => throw new ArgumentOutOfRangeException(nameof(eventName))
        };
    }
}