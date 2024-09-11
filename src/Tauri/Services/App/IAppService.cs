using System.Runtime.Versioning;

namespace Tauri.Services.App;

/// <summary>
/// Get application metadata.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.app</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
/// <example>
/// The APIs must be added to <a href="https://tauri.app/v1/api/config/#allowlistconfig.app">tauri.allowlist.app</a> in <c>tauri.conf.json</c>:
/// <code>
/// {
///     "tauri": {
///         "allowlist": {
///             "app": {
///                 "all": true, // enable all app APIs
///                 "show": true,
///                 "hide": true
///             }
///         }
///     }
/// }
/// </code>
/// It is recommended to allowlist only the APIs you use for optimal bundle size and security.
/// </example>
public interface IAppService
{
    /// <summary>
    /// Gets the application name.
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// var appName = await Tauri.App.GetNameAsync();
    /// </code>
    /// </example>
    ValueTask<string> GetNameAsync();
    
    /// <summary>
    /// Gets the Tauri version.
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// var tauriVersion = await Tauri.App.GetTauriVersionAsync();
    /// </code>
    /// </example>
    ValueTask<string> GetTauriVersionAsync();
    
    /// <summary>
    /// Gets the application version.
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// var appVersion = await Tauri.App.GetVersionAsync();
    /// </code>
    /// </example>
    ValueTask<string> GetVersionAsync();
    
    /// <summary>
    /// Hides the application on macOS.
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.App.HideAsync();
    /// </code>
    /// </example>
    [SupportedOSPlatform("macos")]
    ValueTask HideAsync();
    
    /// <summary>
    /// Shows the application on macOS.
    /// </summary>
    /// <remarks>
    /// This function does not automatically focus any specific app window.
    /// </remarks>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// await Tauri.App.ShowAsync();
    /// </code>
    /// </example>
    [SupportedOSPlatform("macos")]
    ValueTask ShowAsync();
}