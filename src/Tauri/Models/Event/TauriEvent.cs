namespace Tauri.Models.Event;

public enum TauriEvent
{
    WindowResized,
    WindowMoved,
    WindowCloseRequested,
    WindowCreated,
    WindowDestroyed,
    WindowFocus,
    WindowBlur,
    WindowScaleFactorChanged,
    WindowThemeChanged,
    WindowFileDrop,
    WindowFileDropHover,
    WindowFileDropCancelled,
    Menu,
    CheckUpdate,
    UpdateAvailable,
    InstallUpdate,
    StatusUpdate,
    DownloadProgress,
}