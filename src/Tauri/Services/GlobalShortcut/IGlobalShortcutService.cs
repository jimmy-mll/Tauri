using Tauri.Models.GlobalShortcut;

namespace Tauri.Services.GlobalShortcut;

/// <summary>
/// Register global shortcuts.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.globalShortcut</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
/// <example>
/// The APIs must be added to <a href="https://tauri.app/v1/api/config/#allowlistconfig.globalShortcut">tauri.allowlist.globalShortcut</a> in <c>tauri.conf.json</c>:
/// <code>
/// {
///     "tauri": {
///         "allowlist": {
///             "globalShortcut": {
///                 "all": true // enable all app APIs
///             }
///         }
///     }
/// }
/// </code>
/// It is recommended to allowlist only the APIs you use for optimal bundle size and security.
/// </example>
public interface IGlobalShortcutService
{
    /// <summary>
    /// Determines whether the given shortcut is registered by this application or not.
    /// </summary>
    /// <param name="shortcut">Array of shortcut definitions, modifiers and key separated by <c>+</c> e.g. CmdOrControl+Q.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// var isRegistered = await Tauri.GlobalShortcut.IsRegisteredAsync("CommandOrControl+P");
    /// </code>
    /// </example>
    ValueTask<bool> IsRegisteredAsync(string shortcut);
    
    /// <summary>
    /// Register a global shortcut.
    /// </summary>
    /// <param name="shortcut">Shortcut definition, modifiers and key separated by <c>+</c> e.g. CmdOrControl+Q.</param>
    /// <param name="handler">Shortcut handler callback - takes the triggered shortcut as argument.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.GlobalShortcut.RegisterAsync("CommandOrControl+Shift+C", (shortcut) =>
    /// {
    ///     Console.WriteLine($"Shortcut {shortcut} triggered");
    /// });
    /// </code>
    /// </example>
    ValueTask RegisterAsync(string shortcut, ShortcutHandler handler);
    
    /// <summary>
    /// Register a collection of global shortcuts.
    /// </summary>
    /// <param name="shortcuts">Array of shortcut definitions, modifiers and key separated by <c>+</c> e.g. CmdOrControl+Q.</param>
    /// <param name="handler">Shortcut handler callback - takes the triggered shortcut as argument.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.GlobalShortcut.RegisterAllAsync(["CommandOrControl+Shift+C", "Ctrl+Alt+F12"], (shortcut) =>
    /// {
    ///     Console.WriteLine($"Shortcut {shortcut} triggered");
    /// });
    /// </code>
    /// </example>
    ValueTask RegisterAllAsync(string[] shortcuts, ShortcutHandler handler);
    
    /// <summary>
    /// Unregister a global shortcut.
    /// </summary>
    /// <param name="shortcut">Shortcut definition, modifiers and key separated by <c>+</c> e.g. CmdOrControl+Q.</param>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.GlobalShortcut.UnregisterAsync("CmdOrControl+Space");
    /// </code>
    /// </example>
    ValueTask UnregisterAsync(string shortcut);
    
    /// <summary>
    /// Unregisters all shortcuts registered by the application.
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.GlobalShortcut.UnregisterAllAsync();
    /// </code>
    /// </example>
    ValueTask UnregisterAllAsync();
}