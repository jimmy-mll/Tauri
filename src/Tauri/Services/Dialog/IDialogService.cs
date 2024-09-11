using OneOf;
using Tauri.Json.Nodes;
using Tauri.Models.Dialog;

namespace Tauri.Services.Dialog;

/// <summary>
/// Native system dialogs for opening and saving files.
/// </summary>
/// <remarks>
/// This package is also accessible with <c>window.__TAURI__.dialog</c> when <a href="https://tauri.app/v1/api/config/#buildconfig.withglobaltauri">build.withGlobalTauri</a>
/// in <c>tauri.conf.json</c> is set to <c>true</c>.
/// </remarks>
/// <example>
/// The APIs must be added to <a href="https://tauri.app/v1/api/config/#allowlistconfig.dialog">tauri.allowlist.dialog</a> in <c>tauri.conf.json</c>:
/// <code>
/// {
///     "tauri": {
///         "allowlist": {
///             "dialog": {
///                 "all": true, // enable all dialog APIs
///                 "ask": true, // enable dialog ask API
///                 "confirm": true, // enable dialog confirm API
///                 "message": true, // enable dialog message API
///                 "open": true, // enable dialog open API
///                 "save": true // enable dialog save API
///             }
///         }
///     }
/// }
/// </code>
/// It is recommended to allowlist only the APIs you use for optimal bundle size and security.
/// </example>
public interface IDialogService
{
    /// <summary>
    /// Shows a question dialog with <c>Yes</c> and <c>No</c> buttons.
    /// </summary>
    /// <param name="message">The message to show.</param>
    /// <param name="options">The dialog's options. If a string, it represents the dialog title.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving to a bool indicating whether <c>Yes</c> was clicked or not.</returns>
    ValueTask<bool> AskAsync(string message, OneOf<NullValue, string, ConfirmDialogOptions> options = default);
    
    /// <summary>
    /// Shows a question dialog with <c>Ok</c> and <c>Cancel</c> buttons.
    /// </summary>
    /// <param name="message">The message to show.</param>
    /// <param name="options">The dialog's options. If a string, it represents the dialog title.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving to a bool indicating whether <c>Ok</c> was clicked or not.</returns>
    ValueTask<bool> ConfirmAsync(string message, OneOf<NullValue, string, ConfirmDialogOptions> options = default);
    
    /// <summary>
    /// Shows a message dialog with an <c>Ok</c> button.
    /// </summary>
    /// <param name="message">The message to show.</param>
    /// <param name="options">The dialog's options. If a string, it represents the dialog title.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask MessageAsync(string message, OneOf<NullValue, string, MessageDialogOptions> options = default);
    
    /// <summary>
    /// Open a file/directory selection dialog.
    /// <para>
    /// The selected paths are added to the filesystem and asset protocol allowlist scopes.
    /// When security is more important than the easy of use of this API, prefer writing a dedicated command instead.
    /// Note that the allowlist scope change is not persisted, so the values are cleared when the application is restarted.
    /// You can save it to the filesystem using <a href="https://github.com/tauri-apps/plugins-workspace/tree/v1/plugins/persisted-scope">tauri-plugin-persisted-scope</a>.
    /// </para>
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// // Open a selection dialog for image files
    /// var selected = await Tauri.Dialog.OpenAsync(new OpenDialogOptions
    /// {
    ///     Multiple = true,
    ///     Filters = [
    ///         new DialogFilter
    ///         {
    ///             Name = "Image",
    ///             Extensions = ["png", "jpeg"]
    ///         }
    ///    ]
    /// });
    ///
    /// selected.Switch(
    ///     _ => {
    ///         // user cancelled the selection
    ///     },
    ///     path => {
    ///         // user selected a single directory
    ///     },
    ///     paths => {
    ///         // user selected multiple directories
    ///     });
    /// </code>
    /// <code>
    /// @inject ITauri Tauri
    /// // Open a selection dialog for directories
    /// var selected = await Tauri.Dialog.OpenAsync(new OpenDialogOptions
    /// {
    ///     Directory = true,
    ///     Multiple = true,
    ///     DefaultPath = await Tauri.Path.AppDirAsync()
    /// });
    ///
    /// selected.Switch(
    ///     _ => {
    ///         // user cancelled the selection
    ///     },
    ///     path => {
    ///         // user selected a single directory
    ///     },
    ///     paths => {
    ///         // user selected multiple directories
    ///     });
    /// </code>
    /// </example>
    /// <param name="options">The dialog's options.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving the selected path(s).</returns>
    ValueTask<OneOf<NullValue, string, string[]>> OpenAsync(OpenDialogOptions? options = null);
    
    /// <summary>
    /// Open a file/directory save dialog.
    /// <para>
    /// The selected path is added to the filesystem and asset protocol allowlist scopes.
    /// When security is more important than the easy of use of this API, prefer writing a dedicated command instead.
    /// Note that the allowlist scope change is not persisted, so the values are cleared when the application is restarted.
    /// You can save it to the filesystem using <a href="https://github.com/tauri-apps/plugins-workspace/tree/v1/plugins/persisted-scope">tauri-plugin-persisted-scope</a>.
    /// </para>
    /// </summary>
    /// <example>
    /// <code>
    /// @inject ITauri Tauri
    /// var filePath = await Tauri.Dialog.SaveAsync(new SaveDialogOptions
    /// {
    ///     Filters = [
    ///         new DialogFilter
    ///         {
    ///             Name = "Image",
    ///             Extensions = ["png", "jpeg"]
    ///         }
    ///     ]
    /// });
    /// </code>
    /// </example>
    /// <param name="options">The dialog's options.</param>
    /// <returns>A <see cref="ValueTask{TResult}"/> resolving the selected path.</returns>
    ValueTask<string?> SaveAsync(SaveDialogOptions? options = null);
}