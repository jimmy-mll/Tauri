namespace Tauri.Services.Clipboard;

/// <summary>
/// Read and write to the system clipboard.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.clipboard</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
/// <example>
/// The APIs must be added to <a href="https://tauri.app/v1/api/config/#allowlistconfig.clipboard">tauri.allowlist.clipboard</a> in <c>tauri.conf.json</c>:
/// <code>
/// {
///     "tauri": {
///         "allowlist": {
///             "clipboard": {
///                 "all": true, // enable all Clipboard APIs
///                 "writeText": true,
///                 "readText": true
///             }
///         }
///     }
/// }
/// </code>
/// It is recommended to allowlist only the APIs you use for optimal bundle size and security.
/// </example>
public interface IClipboardService
{
    /// <summary>
    /// Gets the clipboard content as plain text.
    /// </summary>
    ValueTask<string?> ReadTextAsync();
    
    /// <summary>
    /// Writes plain text to the clipboard.
    /// </summary>
    ValueTask WriteTextAsync(string text);
}